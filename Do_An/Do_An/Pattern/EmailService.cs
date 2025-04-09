using Do_An.Areas.Admin.Repository;
using Do_An.Models;
using System.Text;

namespace Do_An.Pattern
{
    public class EmailService
    {
        private readonly IEmailSender _emailSender;

        public EmailService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public void SendOrderConfirmation(string userEmail, string orderCode, List<CartItemModel> cartItems)
        {
            StringBuilder emailContent = new StringBuilder();
            emailContent.AppendLine("<h2>Đặt hàng thành công!</h2>");
            emailContent.AppendLine($"<p>Mã đơn hàng: <strong>{orderCode}</strong></p>");
            emailContent.AppendLine("<table border='1' cellpadding='5' cellspacing='0'>");
            emailContent.AppendLine("<tr><th>Sản phẩm</th><th>Số lượng</th><th>Giá</th><th>Thành tiền</th></tr>");

            decimal totalAmount = 0;
            var culture = new System.Globalization.CultureInfo("vi-VN");

            foreach (var cart in cartItems)
            {
                decimal totalItemPrice = cart.Price * cart.Quantity;
                totalAmount += totalItemPrice;
                emailContent.AppendLine($"<tr><td>{cart.ProductName}</td><td>{cart.Quantity}</td><td>{string.Format(culture, "{0:C}", cart.Price)}</td><td>{string.Format(culture, "{0:C}", totalItemPrice)}</td></tr>");
            }

            emailContent.AppendLine("</table>");
            emailContent.AppendLine($"<h3>Tổng tiền: {string.Format(culture, "{0:C}", totalAmount)}</h3>");
            emailContent.AppendLine("<p>Cảm ơn bạn đã mua hàng!</p>");

            _emailSender.SendEmailAsync(userEmail, "Xác nhận đơn hàng", emailContent.ToString()).Wait();
        }
    }
}
