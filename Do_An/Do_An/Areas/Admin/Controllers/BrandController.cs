using Do_An.Models;
using Do_An.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Do_An.Areas.Admin.Controllers
{
    [Route("Admin/Brand")]
    [Area("Admin")]
    [Authorize(Roles = "Admin,Sales")]

    public class BrandController : ControllerTemplateMethod
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<BrandController> _logger;
        public BrandController(DataContext dataContext, ILogger<BrandController> logger)
        {
            _logger = logger;
            PrintInformation();
            _dataContext = dataContext;
        }
        [Route("Index")]
        public async Task<IActionResult> Index(int pg = 1)
        {
            List<BrandModel> brand = _dataContext.Brands.ToList();
            const int pageSize = 10;
            if (pg < 1)
            {
                pg = 1;
            }
            int resCount = brand.Count;
            var pager = new Paginate(resCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = brand.Skip(recSkip).Take(pager.PageSize).ToList();
            ViewBag.Pager = pager;
            return View(data);
           
        }
        [HttpGet]
		[Route("Create")]
		public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public async Task<IActionResult> Create(BrandModel brand)
        {

            if (ModelState.IsValid)
            {
                brand.Slug = brand.Name.Replace(" ", "-");
                var slug = await _dataContext.Brands.FirstOrDefaultAsync(p => p.Slug == brand.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "Thương hiệu đã tồn tại");
                    return View(brand);
                }



                _dataContext.Add(brand);
                await _dataContext.SaveChangesAsync();
                TempData["success"] = "Thêm thương hiệu thành công";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Thông tin thương hiệu sai";
                List<string> errors = new List<string>();
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                    string errorMessage = string.Join("\n", errors);
                    return BadRequest(errorMessage);
                }
            }
            return View(brand);
        }
        [HttpGet]
		[Route("Edit/{Id}")]
		public async Task<IActionResult> Edit(int Id)
        {
            BrandModel brand = await _dataContext.Brands.FindAsync(Id);
            return View(brand);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{Id}")]
        public async Task<IActionResult> Edit(BrandModel brand)
        {

            if (ModelState.IsValid)
            {
                brand.Slug = brand.Name.Replace(" ", "-");
                var slug = await _dataContext.Brands.FirstOrDefaultAsync(p => p.Slug == brand.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "Thương hiệu đã tồn tại");
                    return View(brand);
                }



                _dataContext.Update(brand);
                await _dataContext.SaveChangesAsync();
                TempData["success"] = "Cập nhật thương hiệu thành công";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Thông tin thương hiệu sai";
                List<string> errors = new List<string>();
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                    string errorMessage = string.Join("\n", errors);
                    return BadRequest(errorMessage);
                }
            }
            return View(brand);
        }


        [Route("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            BrandModel brand = await _dataContext.Brands.FindAsync(Id);

            _dataContext.Brands.Remove(brand);
            await _dataContext.SaveChangesAsync();
            TempData["success"] = "Thương hiệu đã xóa thành công";
            return RedirectToAction("Index");
        }


        protected override void PrintRoutes()
        {
            _logger.LogInformation($@"{GetType().Name} " +
                $"Routes: \n" +
                $"GET : /Admin/Category \n" +
                $"GET : /Admin/Category/Create \n" +
                $"POST: /Admin/Category/Create \n" +
                $"GET : /Admin/Category/Edit/Id \n" +
                $"PUT: /Admin/Category/Edit/Id \n" +
                $"DELETE: /Admin/Category/Delete/Id \n");
        }

        protected override void PrintDIs()
        {
            _logger.LogInformation($@"Dependencies: " +
                "AppDbContext context \n" +
                "ILogger<CategoryController> _logger");
        }

    }
}
