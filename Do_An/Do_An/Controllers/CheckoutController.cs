using Do_An.Areas.Admin.Repository;
using Do_An.Models;
using Do_An.Pattern;
using Do_An.Repository;
using Do_An.Services.Vnpay;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;

namespace Do_An.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IEmailSender _emailSender;
        private readonly IVnPayService _vnPayService;
        private readonly ILogger<CheckoutController> _logger;
        private readonly IMediator _mediator;

        public CheckoutController(DataContext dataContext, IEmailSender emailSender, IVnPayService vnPayService, ILogger<CheckoutController> logger, IMediator mediator)
        {
            _dataContext = dataContext;
            _emailSender = emailSender;
            _vnPayService = vnPayService;
            _logger = logger;
            _mediator = mediator;
        }

        //Checkout co mediator
        public async Task<IActionResult> Checkout()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            if (userEmail == null)
            {
                return RedirectToAction("Login", "Account");
            }

            List<CartItemModel> cartItems = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();

            var checkoutRequest = new CheckoutRequest
            {
                UserEmail = userEmail,
                CartItems = cartItems,
                HttpContext = HttpContext
            };

            _mediator.Notify(this, "Checkout", checkoutRequest);

            TempData["Success"] = "Mua hàng thành công";
            return RedirectToAction("Index", "Cart");
        }


        ///Check out cũ

        //public async Task<IActionResult> Checkout()
        //{
        //    var userEmail = User.FindFirstValue(ClaimTypes.Email);
        //    if (userEmail == null)
        //    {
        //        return RedirectToAction("Login", "Account");
        //    }
        //    else
        //    {
        //        var orderCode = Guid.NewGuid().ToString();
        //        var orderItem = new OrderModel();
        //        orderItem.OrderCode = orderCode;
        //        orderItem.UserName = userEmail;
        //        orderItem.Status = 1;
        //        orderItem.CreatedDate = DateTime.Now;
        //        _dataContext.Add(orderItem);
        //        _dataContext.SaveChanges();
        //        List<CartItemModel> cartItems = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
        //        StringBuilder emailContent = new StringBuilder();
        //        emailContent.AppendLine("<h2>Đặt hàng thành công!</h2>");
        //        emailContent.AppendLine($"<p>Mã đơn hàng: <strong>{orderCode}</strong></p>");
        //        emailContent.AppendLine("<table border='1' cellpadding='5' cellspacing='0'>");
        //        emailContent.AppendLine("<tr><th>Sản phẩm</th><th>Số lượng</th><th>Giá</th><th>Thành tiền</th></tr>");
        //        decimal totalAmount = 0;
        //        var culture = new System.Globalization.CultureInfo("vi-VN");
        //        foreach (var cart in cartItems)
        //        {
        //            var orderDetails = new OrderDetails();
        //            orderDetails.UserName = userEmail;
        //            orderDetails.OrderCode = orderCode;
        //            orderDetails.ProductId = cart.ProductId;
        //            orderDetails.Price = cart.Price;
        //            orderDetails.Quantity = cart.Quantity;
        //            _dataContext.Add(orderDetails);
        //            _dataContext.SaveChanges();
        //            decimal totalItemPrice = cart.Price * cart.Quantity;
        //            totalAmount += totalItemPrice;
        //            emailContent.AppendLine($"<tr><td>{cart.ProductName}</td><td>{cart.Quantity}</td><td>{string.Format(culture, "{0:C}", cart.Price)}</td><td>{string.Format(culture, "{0:C}", totalItemPrice)}</td></tr>");
        //        }
        //        emailContent.AppendLine("</table>");
        //        emailContent.AppendLine($"<h3>Tổng tiền: {string.Format(culture, "{0:C}", totalAmount)}</h3>");
        //        emailContent.AppendLine("<p>Cảm ơn bạn đã mua hàng!</p>");
        //        HttpContext.Session.Remove("Cart");
        //        await _emailSender.SendEmailAsync(userEmail, "Xác nhận đơn hàng", emailContent.ToString());
        //        TempData["Success"] = "Mua hàng thành công";
        //        return RedirectToAction("Index", "Cart");
        //    }
        //    return View();
        //}



        [HttpGet]
        public async Task<IActionResult> PaymentCallbackVnpay()
        {
           
            var response = _vnPayService.PaymentExecute(Request.Query);
            if (response.VnPayResponseCode == "00")
            {
                var newVnpayInsert = new VnpayModel
                {
                    OrderId = response.OrderId,
                    PaymentMethod = response.PaymentMethod,
                    OrderDescription = response.OrderDescription,
                    TransactionId = response.TransactionId,
                    PaymentId = response.PaymentId,
                    DateCreated = DateTime.Now,
                };
                _dataContext.Add(newVnpayInsert);
                await _dataContext.SaveChangesAsync();

                await Checkout();
            }
            else
            {
                TempData["success"] = "Giao dịch Vnpay thành công.";
                return RedirectToAction("Index", "Cart");
            }
            return View(response);

            
        }
    }
}
