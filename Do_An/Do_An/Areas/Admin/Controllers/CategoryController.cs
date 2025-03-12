using Do_An.Areas.Admin.Models;
using Do_An.Models;
using Do_An.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Do_An.Areas.Admin.Controllers
{
	[Route("Admin/Category")]
	[Area("Admin")]
    [Authorize(Roles = "Admin,Sales")]
    public class CategoryController : ControllerTemplateMethod
	{
		private readonly DataContext _dataContext;
        private readonly ILogger<CategoryController> _logger;
		public CategoryController(DataContext dataContext, ILogger<CategoryController> logger)
		{
			_dataContext = dataContext;
            _logger = logger;
            PrintInformation();
		}
		[Route("Index")]
		public async Task<IActionResult> Index(int pg=1)
		{
		    List<CategoryModel> category = _dataContext.Categories.ToList();
            const int pageSize = 10;
            if(pg < 1)
            {
                pg =1;
            }
            int resCount = category.Count;
            var pager = new Paginate(resCount,pg,pageSize);
            int recSkip = (pg-1) * pageSize;
            var data = category.Skip(recSkip).Take(pager.PageSize).ToList();
            ViewBag.Pager = pager;
			return View(data);
		}
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public async Task<IActionResult> Create(CategoryModel category)
        {
           
            if (ModelState.IsValid)
            {
                category.Slug = category.Name.Replace(" ", "-");
                var slug = await _dataContext.Categories.FirstOrDefaultAsync(p => p.Slug == category.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "Danh mục đã tồn tại");
                    return View(category);
                }

               

                _dataContext.Add(category);
                await _dataContext.SaveChangesAsync();
                TempData["success"] = "Thêm danh mục thành công";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Thông tin danh mục sai";
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
            return View(category);
        }
        [HttpGet]
        [Route("Edit/{Id}")]
		public async Task<IActionResult> Edit(int Id)
        {
            CategoryModel category = await _dataContext.Categories.FindAsync(Id);
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{Id}")]
        public async Task<IActionResult> Edit(CategoryModel category)
        {

            if (ModelState.IsValid)
            {
                category.Slug = category.Name.Replace(" ", "-");
                var slug = await _dataContext.Categories.FirstOrDefaultAsync(p => p.Slug == category.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "Danh mục đã tồn tại");
                    return View(category);
                }



                _dataContext.Update(category);
                await _dataContext.SaveChangesAsync();
                TempData["success"] = "Cập nhật danh mục thành công";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Thông tin danh mục sai";
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
            return View(category);
        }
        [Route("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            CategoryModel category = await _dataContext.Categories.FindAsync(Id);
           
            _dataContext.Categories.Remove(category);
            await _dataContext.SaveChangesAsync();
            TempData["success"] = "Danh mục đã xóa thành công";
            return RedirectToAction("Index");
        }

        protected override void PrintRoutes()
        {
            _logger.LogDebug($@"{GetType().Name} " +
                $"Routes: \n" +
                $"GET : /Admin/Brand \n" +
                $"GET : /Admin/Brand/Create \n" +
                $"POST: /Admin/Brand/Create \n" +
                $"GET : /Admin/Brand/Edit/Id \n" +
                $"PUT: /Admin/Brand/Edit/Id \n" +
                $"DELETE: /Admin/Brand/Delete/Id \n");
        }

        protected override void PrintDIs()
        {
            _logger.LogDebug($@"Dependencies: " +
                "AppDbContext context \n" +
                "ILogger<BrandController> _logger");
        }
    }
}
