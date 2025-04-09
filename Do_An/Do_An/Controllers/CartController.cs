using Do_An.Models;
using Do_An.Models.ViewModels;
using Do_An.Pattern;
using Do_An.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Do_An.Controllers
{
	public class CartController : Controller
	{
		private readonly DataContext _dataContext;
       
        public CartController(DataContext dataContext)
		{
			_dataContext = dataContext;
           
        }
        //Giỏ hàng dùng Builder Pattern
        public IActionResult Index()
        {
            CartBuilder cartBuilder = new(HttpContext.Session);
            CartItemViewModel cartVM = new()
            {
                CartItems = cartBuilder.GetCart(),
                GrandTotal = cartBuilder.GetCart().Sum(x => x.Quantity * x.Price)
            };
            return View(cartVM);
        }
        public IActionResult Checkout()
        {
            return View("~/Views/Checkout/Index.cshtml");
        }


        public async Task<IActionResult> Add(long Id)
        {
            ProductModel product = await _dataContext.Products.FindAsync(Id);
            CartBuilder cartBuilder = new CartBuilder(HttpContext.Session);
            cartBuilder.AddItem(product).Save(HttpContext.Session);
            cartBuilder.Save(HttpContext.Session);
            TempData["success"] = "Thêm vào giỏ hàng thành công";
            return Redirect(Request.Headers["Referer"].ToString());
        }

        
        public IActionResult Increase(int Id)
        {
            
            CartBuilder cartBuilder = new CartBuilder(HttpContext.Session);
            cartBuilder.IncreaseQuantity(Id).Save(HttpContext.Session);
            cartBuilder.Save(HttpContext.Session);
            TempData["success"] = "Tăng số lượng thành công";

            return RedirectToAction("Index");


        }

        public IActionResult Decrease(int Id)
        {
            CartBuilder cartBuilder = new CartBuilder(HttpContext.Session);
            cartBuilder.DecreaseQuantity(Id).Save(HttpContext.Session);
            cartBuilder.Save(HttpContext.Session);
            TempData["success"] = "Giảm số lượng thành công";
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int Id)
        {
            CartBuilder cartBuilder = new CartBuilder(HttpContext.Session);
            cartBuilder.RemoveItem(Id).Save(HttpContext.Session);
            cartBuilder.Save(HttpContext.Session);
            TempData["success"] = "Xóa sản phẩm thành công";
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            CartBuilder cartBuilder = new CartBuilder(HttpContext.Session);
            cartBuilder.ClearCart().Save(HttpContext.Session);
            cartBuilder.Save(HttpContext.Session);
            TempData["success"] = "Xóa giỏ hàng thành công";
            return RedirectToAction("Index");
        }








        //Giỏ hành cũ 
        //public IActionResult Index()
        //{
        //    List<CartItemModel> cartItems = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
        //    CartItemViewModel cartVM = new()
        //    {
        //        CartItems = cartItems,
        //        GrandTotal = cartItems.Sum(x => x.Quantity * x.Price)
        //    };
        //    return View(cartVM);
        //}

        //public IActionResult Checkout()
        //{
        //    return View("~/Views/Checkout/Index.cshtml");
        //}
        //public async Task<IActionResult> Add(long Id)
        //{
        //    ProductModel product = await _dataContext.Products.FindAsync(Id);
        //    List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
        //    CartItemModel cartItems = cart.Where(p => p.ProductId == Id).FirstOrDefault();
        //    if (cartItems == null)
        //    {
        //        cart.Add(new CartItemModel(product));
        //    }
        //    else
        //    {
        //        cartItems.Quantity += 1;

        //    }
        //    HttpContext.Session.SetJson("Cart", cart);
        //    TempData["success"] = "Thêm vào giỏ hàng thành công";
        //    return Redirect(Request.Headers["Referer"].ToString());
        //}

        //public async Task<IActionResult> Decrease(int Id)
        //{
        //    List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart");
        //    CartItemModel cartItem = cart.Where(c => c.ProductId == Id).FirstOrDefault();
        //    if (cartItem.Quantity > 1)
        //    {
        //        --cartItem.Quantity;
        //    }
        //    else
        //    {
        //        cart.RemoveAll(p => p.ProductId == Id);
        //    }
        //    if (cart.Count == 0)
        //    {
        //        HttpContext.Session.Remove("Cart");
        //    }
        //    else
        //    {
        //        HttpContext.Session.SetJson("Cart", cart);
        //    }
        //    TempData["success"] = "Giảm số lượng thành công";
        //    return RedirectToAction("Index");
        //}

        //public async Task<IActionResult> Increase(int Id)
        //{
        //    List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart");
        //    CartItemModel cartItem = cart.Where(c => c.ProductId == Id).FirstOrDefault();
        //    if (cartItem.Quantity >= 1)
        //    {
        //        ++cartItem.Quantity;
        //    }
        //    else
        //    {
        //        cart.RemoveAll(p => p.ProductId == Id);
        //    }
        //    if (cart.Count == 0)
        //    {
        //        HttpContext.Session.Remove("Cart");
        //    }
        //    else
        //    {
        //        HttpContext.Session.SetJson("Cart", cart);
        //    }
        //    TempData["success"] = "Tăng số lượng thành công";
        //    return RedirectToAction("Index");
        //}

        //public async Task<IActionResult> Remove(int Id)
        //{
        //    List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart");
        //    cart.RemoveAll(p => p.ProductId == Id);
        //    if (cart.Count == 0)
        //    {
        //        HttpContext.Session.Remove("Cart");
        //    }
        //    else
        //    {
        //        HttpContext.Session.SetJson("Cart", cart);
        //    }
        //    TempData["success"] = "Xóa sản phẩm thành công";
        //    return RedirectToAction("Index");
        //}

        //public async Task<IActionResult> Clear()
        //{
        //    HttpContext.Session.Remove("Cart");
        //    TempData["success"] = "Xóa giỏ hàng thành công";
        //    return RedirectToAction("Index");
        //}

    }
}
