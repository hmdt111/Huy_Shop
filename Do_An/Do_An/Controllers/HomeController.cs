
using Do_An.Models;
using Do_An.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Do_An.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<HomeController> _logger;
		private readonly UserManager<AppUserModel> _userManager;
		public HomeController(ILogger<HomeController> logger, DataContext context, UserManager<AppUserModel> userManager)
        {
            _logger = logger;
            _dataContext = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var products = _dataContext.Products.Include("Category").Include("Brand").ToList();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statuscode)
        {
            if(statuscode == 404)
            {
                return View("NotFound");
            }
            else
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
           
        }
        [Authorize]
        public async Task<IActionResult> AddWishlist(long Id,WishlistModel wishlist)
        {
            var user = await _userManager.GetUserAsync(User);
            var wishlistProduct = new WishlistModel
            {
                ProductId = Id,
                UserId = user.Id,
            };
            _dataContext.Wishlists.Add(wishlistProduct);
            try
            {
                await _dataContext.SaveChangesAsync();
                return Ok(new { success = true, message = "Thêm yêu thích thành công" });
            }catch (Exception)
            {
                return StatusCode(500, "Có lỗi xảy ra khi thêm yêu thích");
            }
        }

		public async Task<IActionResult> Wishlist()
        {
            var wishlist_product = await (from w in _dataContext.Wishlists
                                          join p in _dataContext.Products on w.ProductId equals p.Id
                                          join u in _dataContext.Users on w.UserId equals u.Id
                                          select new { User = u, Product = p, Wishlists = w }).ToListAsync();

            return View(wishlist_product);
        }
		public async Task<IActionResult> DeleteWishlist(int Id)
        {
            WishlistModel wishList = await _dataContext.Wishlists.FindAsync(Id);
                _dataContext.Wishlists.Remove(wishList);

            await _dataContext.SaveChangesAsync();

            TempData["success"] = "Sản phẩm yêu thích đã xóa thành công";
            return RedirectToAction("Wishlist");
        }
       




	}
}
