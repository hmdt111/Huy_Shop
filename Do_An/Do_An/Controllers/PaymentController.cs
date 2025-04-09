using Do_An.Models;
using Do_An.Models.Vnpay;
using Do_An.Services.Momo;
using Do_An.Services.Vnpay;
using Microsoft.AspNetCore.Mvc;

namespace Do_An.Controllers
{
    public class PaymentController : Controller
    {
        private IMomoService _momoService;
        private readonly IVnPayService _vnPayService;
        public PaymentController(IMomoService momoService, IVnPayService vnPayService)
        {
            _momoService = momoService;
            _vnPayService = vnPayService;
            
        }
        [HttpPost]
        public async Task<IActionResult> CreatePaymentMomo(OrderInfo model)
        {
            var response = await _momoService.CreatePaymentAsync(model);
            return Redirect(response.PayUrl);
        }
        


        [HttpGet]
        public IActionResult PaymentCallBack()
        {
            var response = _momoService.PaymentExecuteAsync(HttpContext.Request.Query);
            return View(response);
        }

        [HttpPost]
        public IActionResult CreatePaymentUrlVnpay(PaymentInformationModel model)
        {
            var url = _vnPayService.CreatePaymentUrl(model, HttpContext);

            return Redirect(url);
        }




    }
}
