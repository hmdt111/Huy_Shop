using Do_An.Pattern;
using Do_An.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Do_An.Areas.Admin.Controllers
{
	[Route("Admin/Order")]
	[Area("Admin")]
    [Authorize(Roles = "Admin,Sales")]
    public class OrderController : Controller
    {
		private readonly DataContext _dataContext;
		public OrderController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		[Route("Index")]
		public async Task<IActionResult> Index()
		{

			return View(await _dataContext.Orders.OrderByDescending(p => p.Id).ToListAsync());
		}
		[Route("ViewOrder/{orderCode}")]

		public async Task<IActionResult> ViewOrder(string orderCode)
        {
			var detailsOrder = await _dataContext.OrderDetails.Include(o => o.Product).Where(od => od.OrderCode == orderCode).ToListAsync();
            return View(detailsOrder);
        }

		[HttpPost]
		[Route("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder(string ordercode, int status)
        {
            var order = await _dataContext.Orders.FirstOrDefaultAsync(o => o.OrderCode == ordercode);

            if (order == null)
            {
                return NotFound();
            }

            // Dựa vào status, thay đổi trạng thái của đơn hàng
            IOrderState newState = status switch
            {
                1 => new NewOrderState(),      // Trạng thái "Mới"
                0 => new ProcessedOrderState(), // Trạng thái "Đã xử lý"
                _ => order.CurrentState,       // Giữ nguyên trạng thái nếu status không hợp lệ
            };

            order.SetState(newState);

            try
            {
                // Cập nhật trạng thái và lưu vào cơ sở dữ liệu
                await order.UpdateOrderStatus();
                await _dataContext.SaveChangesAsync();
                return Ok(new { success = true, message = "Cập nhật trạng thái thành công" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Có lỗi xảy ra khi cập nhật trạng thái");
            }
        }

        //public async Task<IActionResult> UpdateOrder(string ordercode,int status)
        //{
        //	var order = await _dataContext.Orders.FirstOrDefaultAsync(o => o.OrderCode == ordercode);

        //	if(order == null)
        //	{
        //		return NotFound();
        //	}
        //	order.Status = status;
        //	try
        //	{
        //		await _dataContext.SaveChangesAsync();
        //		return Ok(new {success = true, message = "Cập nhật status thành công"});
        //	}catch (Exception ex)
        //	{
        //		return StatusCode(500, "Có lỗi xảy ra khi cập nhật");
        //	}

        //}

    }
}
