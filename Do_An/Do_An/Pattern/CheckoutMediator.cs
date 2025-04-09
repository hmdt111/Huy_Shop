using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Do_An.Pattern
{
    public class CheckoutMediator : IMediator
    {
        private readonly OrderService _orderService;
        private readonly EmailService _emailService;
        private readonly CartService _cartService;

        public CheckoutMediator(OrderService orderService, EmailService emailService, CartService cartService)
        {
            _orderService = orderService;
            _emailService = emailService;
            _cartService = cartService;
        }
        public void Notify(object sender, string ev, object data = null)
        {
            if (ev == "Checkout")
            {
                Console.WriteLine("Mediator: Bắt đầu xử lý thanh toán...");

                var checkoutData = (CheckoutRequest)data;
                var orderCode = _orderService.CreateOrder(checkoutData.UserEmail, checkoutData.CartItems);

                if (orderCode != null)
                {
                    _emailService.SendOrderConfirmation(checkoutData.UserEmail, orderCode, checkoutData.CartItems);
                    _cartService.ClearCart(checkoutData.HttpContext);
                }
            }

        }
    }
}
