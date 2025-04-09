using Do_An.Models;
using Do_An.Pattern;
using Do_An.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Do_An.Controllers
{
	public class CategoryController : Controller
	{
		private readonly DataContext _dataContext;

		public CategoryController(DataContext dataContext) 
		{ 
			_dataContext = dataContext; 
		}
        public async Task<IActionResult> Index(string Slug = "")
        {
            CategoryModel category = _dataContext.Categories.FirstOrDefault(c => c.Slug == Slug);
            if (category == null) return RedirectToAction("Index");

            var products = await _dataContext.Products
                .Where(p => p.CategoryId == category.Id)
                .OrderByDescending(p => p.Id)
                .ToListAsync();

            var productCollection = new ProductCollection();
            foreach (var product in products)
            {
                productCollection.AddProduct(product);
            }

            var iterator = productCollection.CreateIterator();
            var productList = new List<ProductModel>();

            while (iterator.HasNext())
            {
                productList.Add(iterator.Next());
            }
            ViewBag.Slug = Slug;    
            return View(productList); // Truyền danh sách sản phẩm vào View
        }



        //public async  Task<IActionResult> Index(string Slug = "")
        //{
        //	CategoryModel category = _dataContext.Categories.Where(c => c.Slug == Slug).FirstOrDefault();
        //	if(category == null) return RedirectToAction("Index");

        //	var productByCategory = _dataContext.Products.Where(p => p.CategoryId == category.Id);
        //	return View(await productByCategory.OrderByDescending(p => p.Id).ToListAsync());
        //}
    }
}
