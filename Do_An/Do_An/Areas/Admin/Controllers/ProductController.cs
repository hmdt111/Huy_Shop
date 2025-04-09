using Do_An.Areas.Admin.Models;
using Do_An.Models;
using Do_An.Pattern;
using Do_An.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Do_An.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Sales,Admin")]
    public class ProductController : Controller
    {
        // Dùng Facade pattern


        private readonly DataContext _dataContext;
        private readonly ProductFacade _productFacade;

        public ProductController(ProductFacade productFacade, DataContext dataContext)
        {
            _productFacade = productFacade;
            _dataContext = dataContext;
            CategorySingleton.Instance.Init(_dataContext);
            BrandSingleton.Instance.Init(_dataContext);
        }

        // Hiển thị danh sách sản phẩm (có phân trang nếu cần)
        public async Task<IActionResult> Index(int pg = 1)
        {
            List<ProductModel> products = await _productFacade.GetProductsAsync();
            const int pageSize = 10;
            if (pg < 1) pg = 1;

            int resCount = products.Count;
            var pager = new Paginate(resCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = products.Skip(recSkip).Take(pager.PageSize).ToList();
            ViewBag.Pager = pager;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            // Sử dụng dữ liệu từ Singleton hoặc DataContext theo nhu cầu
            ViewBag.Categories = new SelectList(CategorySingleton.Instance.listCategory, "Id", "Name");
            ViewBag.Brands = new SelectList(BrandSingleton.Instance.listBrand, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductModel product)
        {
            var (isSuccess, message, _) = await _productFacade.CreateProductAsync(product);
            if (isSuccess)
            {
                TempData["success"] = message;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = message;
                // Nếu lỗi, hiển thị lại View với thông báo lỗi
                return View(product);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            var product = await _productFacade.GetProductsAsync().ContinueWith(t => t.Result.FirstOrDefault(p => p.Id == id));
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.Categories = new SelectList(_dataContext.Categories, "Id", "Name", product.CategoryId);
            ViewBag.Brands = new SelectList(_dataContext.Brands, "Id", "Name", product.BrandId);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, ProductModel product)
        {
            var (isSuccess, message) = await _productFacade.EditProductAsync(product);
            if (isSuccess)
            {
                TempData["success"] = message;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = message;
                return View(product);
            }
        }

        public async Task<IActionResult> Delete(long id)
        {
            var (isSuccess, message) = await _productFacade.DeleteProductAsync(id);
            if (!isSuccess)
            {
                TempData["error"] = message;
            }
            else
            {
                TempData["success"] = message;
            }
            return RedirectToAction("Index");
        }
    }












    //      //Cách bình thường
    //      private readonly DataContext _dataContext;
    //      private readonly IWebHostEnvironment _webHostEnvironment;
    //      public ProductController(DataContext dataContext, IWebHostEnvironment webHostEnvironment)
    //      {
    //          _dataContext = dataContext;

    //          _webHostEnvironment = webHostEnvironment;
    //	CategorySingleton.Instance.Init(_dataContext);
    //	BrandSingleton.Instance.Init(_dataContext);
    //}

    //public async Task<IActionResult> Index(int pg = 1)

    //      {
    //          List<ProductModel> product = _dataContext.Products.Include(c => c.Category).Include(b => b.Brand).ToList();
    //          const int pageSize = 10;
    //          if (pg < 1)
    //          {
    //              pg = 1;
    //          }
    //          int resCount = product.Count;
    //          var pager = new Paginate(resCount, pg, pageSize);
    //          int recSkip = (pg - 1) * pageSize;
    //          var data = product.Skip(recSkip).Take(pager.PageSize).ToList();
    //          ViewBag.Pager = pager;
    //          return View(data);



    //      }

    //[HttpGet]
    //      public IActionResult Create()
    //      {
    //          ViewBag.Categories = new SelectList(CategorySingleton.Instance.listCategory, "Id", "Name");
    //          ViewBag.Brands = new SelectList(BrandSingleton.Instance.listBrand, "Id", "Name");
    //          return View();
    //      }
    //      [HttpPost]
    //      [ValidateAntiForgeryToken]
    //      public async Task<IActionResult> Create(ProductModel product)
    //      {
    //          ViewBag.Categories = new SelectList(_dataContext.Categories, "Id", "Name", product.CategoryId);
    //          ViewBag.Brands = new SelectList(_dataContext.Brands, "Id", "Name", product.BrandId);
    //          if (ModelState.IsValid)
    //          {
    //              product.Slug = product.Name.Replace(" ", "-");
    //              var slug = await _dataContext.Products.FirstOrDefaultAsync(p => p.Slug == product.Slug);
    //              if (slug != null)
    //              {
    //                  ModelState.AddModelError("", "Sản phẩm đã tồn tại");
    //                  return View(product);
    //              }

    //              if (product.ImageUpload != null)
    //              {
    //                  string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/products");
    //                  string imageName = Guid.NewGuid().ToString() + "_" + product.ImageUpload.FileName;
    //                  string filePath = Path.Combine(uploadsDir, imageName);

    //                  FileStream fs = new FileStream(filePath, FileMode.Create);
    //                  await product.ImageUpload.CopyToAsync(fs);
    //                  fs.Close();
    //                  product.Image = imageName;
    //              }

    //              _dataContext.Add(product);
    //              await _dataContext.SaveChangesAsync();
    //              TempData["success"] = "Thêm sản phẩm thành công";
    //              return RedirectToAction("Index");
    //          }
    //          else
    //          {
    //              TempData["error"] = "Thông tin sản phẩm sai";
    //              List<string> errors = new List<string>();
    //              foreach (var value in ModelState.Values)
    //              {
    //                  foreach (var error in value.Errors)
    //                  {
    //                      errors.Add(error.ErrorMessage);
    //                  }
    //                  string errorMessage = string.Join("\n", errors);
    //                  return BadRequest(errorMessage);
    //              }
    //          }
    //          return View(product);
    //      }
    //      [HttpGet]
    //      public async Task<IActionResult> Edit(long Id)
    //      {
    //          ProductModel product = await _dataContext.Products.FindAsync(Id);
    //          ViewBag.Categories = new SelectList(_dataContext.Categories, "Id", "Name", product.CategoryId);
    //          ViewBag.Brands = new SelectList(_dataContext.Brands, "Id", "Name", product.BrandId);

    //          return View(product);
    //      }

    //      [HttpPost]
    //      [ValidateAntiForgeryToken]
    //      public async Task<IActionResult> Edit(long Id, ProductModel product)
    //      {
    //          ViewBag.Categories = new SelectList(_dataContext.Categories, "Id", "Name", product.CategoryId);
    //          ViewBag.Brands = new SelectList(_dataContext.Brands, "Id", "Name", product.BrandId);
    //          var existed_product = _dataContext.Products.Find(product.Id);
    //          if (ModelState.IsValid)
    //          {
    //              product.Slug = product.Name.Replace(" ", "-");


    //              if (product.ImageUpload != null)
    //              {

    //                  //Cập nhật ảnh mới
    //                  string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/products");
    //                  string imageName = Guid.NewGuid().ToString() + "_" + product.ImageUpload.FileName;
    //                  string filePath = Path.Combine(uploadsDir, imageName);
    //                  //Xóa ảnh cũ
    //                  string oldFileImage = Path.Combine(uploadsDir, existed_product.Image);
    //                  try
    //                  {
    //                      if (System.IO.File.Exists(oldFileImage))
    //                      {
    //                          System.IO.File.Delete(oldFileImage);
    //                      }

    //                  }
    //                  catch (Exception ex)
    //                  {
    //                      ModelState.AddModelError("", "Có lỗi xảy ra khi xóa ảnh");
    //                  }
    //                  FileStream fs = new FileStream(filePath, FileMode.Create);
    //                  await product.ImageUpload.CopyToAsync(fs);
    //                  fs.Close();
    //                  existed_product.Image = imageName;



    //              }
    //              existed_product.Name = product.Name;
    //              existed_product.Description = product.Description;
    //              existed_product.Price = product.Price;
    //              existed_product.CategoryId = product.CategoryId;
    //              existed_product.BrandId = product.BrandId;

    //              _dataContext.Update(existed_product);
    //              await _dataContext.SaveChangesAsync();
    //              TempData["success"] = "Cập nhật sản phẩm thành công";
    //              return RedirectToAction("Index");
    //          }
    //          else
    //          {
    //              TempData["error"] = "Thông tin sản phẩm sai";
    //              List<string> errors = new List<string>();
    //              foreach (var value in ModelState.Values)
    //              {
    //                  foreach (var error in value.Errors)
    //                  {
    //                      errors.Add(error.ErrorMessage);
    //                  }
    //                  string errorMessage = string.Join("\n", errors);
    //                  return BadRequest(errorMessage);
    //              }
    //          }
    //          return View(product);
    //      }

    //      public async Task<IActionResult> Delete(int Id)
    //      {
    //          ProductModel product = await _dataContext.Products.FindAsync(Id);
    //          if(product == null)
    //          {
    //              return NotFound();
    //          }
    //          string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/products");
    //          string oldFileImage = Path.Combine(uploadsDir, product.Image);
    //          try
    //          {
    //              if (System.IO.File.Exists(oldFileImage))
    //              {
    //                  System.IO.File.Delete(oldFileImage);
    //              }

    //          }
    //          catch (Exception ex)
    //          {
    //              ModelState.AddModelError("", "Có lỗi xảy ra khi xóa ảnh");
    //          }
    //          _dataContext.Products.Remove(product);
    //          await _dataContext.SaveChangesAsync();
    //          TempData["success"] = "Sản phẩm đã xóa thành công";
    //          return RedirectToAction("Index");
    //      }
}

