using Do_An.Models;
using Do_An.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Do_An.Controllers
{
	public class BrandController : Controller
	{
		private readonly DataContext _dataContext;
		public BrandController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		public async Task<IActionResult> Index(string Slug = "")
		{
			BrandModel brand = _dataContext.Brands.Where(c => c.Slug == Slug).FirstOrDefault();
			if (brand == null) return RedirectToAction("Index");

			var productByBrand = _dataContext.Products.Where(p => p.BrandId == brand.Id);
            ViewBag.Slug = Slug;
            return View(await productByBrand.OrderByDescending(p => p.Id).ToListAsync());
		}
	}
}
