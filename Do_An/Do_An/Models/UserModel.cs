using System.ComponentModel.DataAnnotations;

namespace Do_An.Models
{
	public class UserModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Không được để trống Tên đăng nhập")]
		public string Username { get; set; }
		[DataType(DataType.Password), Required(ErrorMessage = "Không được để trống Mật Khẩu")]
		public string Password { get; set; }
		[Required(ErrorMessage = "Không được để trống Email"),EmailAddress]
		public string Email { get; set; }
	}
}
