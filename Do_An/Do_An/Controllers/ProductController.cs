using Do_An.Pattern;
using Do_An.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Do_An.Controllers
{
	public class ProductController : Controller
	{
        private readonly DataContext _dataContext;
        private readonly ProductProxy _productProxy;

        public ProductController(DataContext dataContext)
        {
            _dataContext = dataContext;
            _productProxy = new ProductProxy(_dataContext);
        }
        public IActionResult Index()
		{
			return View();
		}
        public async Task<IActionResult> Details(int Id)
        {
            if (Id == null) return RedirectToAction("Index");

            // Sử dụng Proxy để lấy thông tin sản phẩm
            var product = await _productProxy.GetProductByIdAsync(Id);

            // Nếu không tìm thấy sản phẩm, trả về trang 404
            if (product == null)
            {
                return NotFound();
            }

            var relatedProducts = await _dataContext.Products
                                        .Where(p => p.CategoryId == product.CategoryId && p.Id != product.Id)
                                        .Take(4).ToListAsync();
            ViewBag.RelatedProducts = relatedProducts;

            return View(product);
        }
        
        public async Task<IActionResult> Search(string searchTerm)
        {
            var products = await _dataContext.Products.Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm)).ToListAsync();
            ViewBag.Keyword = searchTerm;
            return View(products);
        }


        
    }
}
