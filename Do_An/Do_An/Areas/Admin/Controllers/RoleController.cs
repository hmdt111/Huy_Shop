using Do_An.Models;
using Do_An.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Text;

namespace Do_An.Areas.Admin.Controllers
{
    [Route("Admin/Role")]
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {

        private readonly DataContext _dataContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleController(DataContext dataContext, RoleManager<IdentityRole> roleManager)
        {
            _dataContext = dataContext;
            _roleManager = roleManager;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {

            return View(await _dataContext.Roles.OrderByDescending(p => p.Id).ToListAsync());
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
        public async Task<IActionResult> Create(IdentityRole model)
        {
            if(!_roleManager.RoleExistsAsync(model.Name).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(model.Name)).GetAwaiter().GetResult();
            }
            return Redirect("Index");
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            var role = await _roleManager.FindByIdAsync(id);
            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(IdentityRole model,string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                var role = await _roleManager.FindByIdAsync(id);
                if (role == null)
                {
                    return NotFound();
                }
                role.Name = model.Name;
                try
                {
                    await _roleManager.UpdateAsync(role);
                    TempData["success"] = "Cập nhật thành công role";
                    return RedirectToAction("Index");
                }catch (Exception ex)
                {
                    ModelState.AddModelError("", "Xảy ra lỗi khi cập nhật");
                }
               
            }
            return View(model ?? new IdentityRole { Id = id });
        }


        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            var role = await _roleManager.FindByIdAsync(id);
            if(role == null)
            {
                return NotFound();
            }

            try
            {
                await _roleManager.DeleteAsync(role);
                TempData["success"] = "Xóa thành công role";
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Xảy ra lỗi khi xóa");
            }

            return Redirect("Index");
        }
    }
}
