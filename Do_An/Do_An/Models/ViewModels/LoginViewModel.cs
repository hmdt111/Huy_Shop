using System.ComponentModel.DataAnnotations;

namespace Do_An.Models.ViewModels
{
	public class LoginViewModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Vui lòng nhập Tên đăng nhập")]
		public string Username { get; set; }
		[DataType(DataType.Password), Required(ErrorMessage = "Vui lòng nhập Mật Khẩu")]
		public string Password { get; set; }

		public string ReturnUrl { get; set; }	
		
	}
}
