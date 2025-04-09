using Do_An.Models;

namespace Do_An.Pattern
{
    public class CheckoutRequest
    {
        public string UserEmail { get; set; }
        public List<CartItemModel> CartItems { get; set; }
        public HttpContext HttpContext { get; set; }
    }
}
