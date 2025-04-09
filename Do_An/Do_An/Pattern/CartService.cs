namespace Do_An.Pattern
{
    public class CartService
    {
        public void ClearCart(HttpContext httpContext)
        {
            httpContext.Session.Remove("Cart");
            Console.WriteLine("CartService: Giỏ hàng đã được xóa sau khi đặt hàng thành công.");
        }
    }
}
