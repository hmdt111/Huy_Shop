
using System.Net;
using System.Net.Mail;

namespace Do_An.Areas.Admin.Repository
{
    public class EmailSender : IEmailSender
    {
        


        public Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("huy8x11@gmail.com", "ymdhhvjgrlpzwdrh"),


            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("huy8x11@gmail.com", "Cửa hàng Huy_Shop"),
                Subject = subject,
                Body = message,
                IsBodyHtml = true // ✅ Quan trọng! Đặt true để hỗ trợ HTML
            };

            mailMessage.To.Add(email);

            return client.SendMailAsync(mailMessage);
        }
    }
}
