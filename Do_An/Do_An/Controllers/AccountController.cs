﻿using Do_An.Models;
using Do_An.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Do_An.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUserModel> _userManager;
        private SignInManager<AppUserModel> _signInManager;

        public AccountController(UserManager<AppUserModel> userManager, SignInManager<AppUserModel> signInManager)
        {
			_userManager = userManager;
            _signInManager = signInManager;

		}
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }
        [HttpPost]		
		public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(loginVM.Username, loginVM.Password, false, false);
                if (result.Succeeded)
                {
                    return Redirect(loginVM.ReturnUrl ?? "/");
                }
                ModelState.AddModelError("", "Sai tên tài khoản hoặc mật khẩu");
            }
            return View(loginVM);
        }




		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
       
		public async Task<IActionResult> Create(UserModel user)
		{
            if(ModelState.IsValid)
            {
                AppUserModel newUser = new AppUserModel { UserName = user.Username, Email=user.Email};
                IdentityResult result = await _userManager.CreateAsync(newUser,user.Password);
                if(result.Succeeded)
                {
                    TempData["success"] = "Tạo tài khoản thành công.";
                    return Redirect("/account/login");
                }
                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
			return View(user);
		}

        public async Task<IActionResult> Logout(string returnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

	}
}
