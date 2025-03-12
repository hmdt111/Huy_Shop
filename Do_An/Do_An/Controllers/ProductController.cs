using Do_An.Pattern;
using Do_An.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Do_An.Controllers
{
	public class ProductController : Controller
	{
        private readonly DataContext _dataContext;
        private readonly ProductProxy _productProxy;

        public ProductController(DataContext dataContext)
        {
            _dataContext = dataContext;
            _productProxy = new ProductProxy(_dataContext);
        }
        public IActionResult Index()
		{
			return View();
		}
        public async Task<IActionResult> Details(int Id)
        {
            if (Id == null) return RedirectToAction("Index");

            // Sử dụng Proxy để lấy thông tin sản phẩm
            var product = await _productProxy.GetProductByIdAsync(Id);

            // Nếu không tìm thấy sản phẩm, trả về trang 404
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }



        //public async Task<IActionResult> Details(int Id)
        //{
        //	if(Id == null) return RedirectToAction("Index");
        //          var productsById = _dataContext.Products.Where(p => p.Id== Id).FirstOrDefault();
        //          return View(productsById);
        //}
    }
}
