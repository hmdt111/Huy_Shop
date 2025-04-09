using Microsoft.AspNetCore.Mvc;

namespace Do_An.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
