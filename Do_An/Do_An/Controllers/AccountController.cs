using Do_An.Areas.Admin.Repository;
using Do_An.Models;
using Do_An.Models.ViewModels;
using Do_An.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Do_An.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUserModel> _userManager;
        private SignInManager<AppUserModel> _signInManager;
		private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly DataContext _dataContext;

        public AccountController(UserManager<AppUserModel> userManager, SignInManager<AppUserModel> signInManager, IEmailSender emailSender, RoleManager<IdentityRole> roleManager, DataContext dataContext)
        {
			_userManager = userManager;
            _signInManager = signInManager;
			_emailSender = emailSender;
            _roleManager = roleManager;
            _dataContext = dataContext;

		}
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }
        public async Task<IActionResult> NewPass(AppUserModel user,string token)
        {
            var checkuser = await _userManager.Users
                .Where(u => u.Email == user.Email)
                .Where(u => u.Token == user.Token).FirstOrDefaultAsync();
            if(checkuser != null)
            {
                ViewBag.Email = checkuser.Email;
                ViewBag.Token = token;
            }
            else
            {
                TempData["error"] = "Không tìm được email hoặc token không đúng";
                return RedirectToAction("ForgetPass", "Account");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateNewPassword(AppUserModel user,string token)
        {
            var checkUser = await _userManager.Users
                .Where(u => u.Email == user.Email)
                .Where(u => u.Token == user.Token).FirstOrDefaultAsync();

            if(checkUser != null)
            {
                string newToken = Guid.NewGuid().ToString();
                
                var passwordHasher = new PasswordHasher<AppUserModel>();
                var passwordHash = passwordHasher.HashPassword(checkUser,user.PasswordHash);
                checkUser.PasswordHash =  passwordHash;
                checkUser.Token = newToken;
                
                await _userManager.UpdateAsync(checkUser);
                TempData["success"] = "Cập nhật thành công mật khẩu";
                return RedirectToAction("Login", "Account");
            }
            else
            {
                TempData["error"] = "Lỗi không cập nhật thành công";
                return RedirectToAction("ForgetPass", "Account");
            }
            return View();
        }
        public async Task<IActionResult> ForgetPass(string returnUrl)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendGmailForgotPass(AppUserModel user)
        {
            var checkMail = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (checkMail == null)
            {
                TempData["error"] = "Không có Email";
                return RedirectToAction("ForgetPass", "Account");
            }
            else
            {
                string token = Guid.NewGuid().ToString();
                checkMail.Token = token;
                _dataContext.Update(checkMail);
                await _dataContext.SaveChangesAsync();
                var url = $"{Request.Scheme}://{Request.Host}/Account/NewPass?email="+checkMail.Email+"&token="+token;
                var receiver = checkMail.Email;
                var subject = "Thay đổi mật khẩu cho : " + checkMail.Email;
                var message = $"Bấm vào đây để đổi mật khẩu : {url}";

                await _emailSender.SendEmailAsync(receiver, subject, message);
               
            }
            TempData["success"] = "Đã gởi email cài lại mật khẩu thành công";
            return RedirectToAction("ForgetPass", "Account");
        }
        [HttpPost]		
		public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            var user = await _userManager.FindByNameAsync(loginVM.Username);
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(loginVM.Username, loginVM.Password, false, false);
               

                if (result.Succeeded)
                {
					if (!user.EmailConfirmed)
					{
						// If email is not confirmed, log them out and return a message
						await _signInManager.SignOutAsync();
						TempData["error"] = "Vui lòng xác nhận email của bạn trước khi đăng nhập.";
						return RedirectToAction("Login");
					}
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
			if (ModelState.IsValid)
			{
				// Create the new user
				AppUserModel newUser = new AppUserModel { UserName = user.Username, Email = user.Email,RoleId = "4a0a9d06-7b35-49f4-b1e2-b0ad38a45f44" };

				IdentityResult result = await _userManager.CreateAsync(newUser, user.Password);
                var createUser = await _userManager.FindByEmailAsync(newUser.Email);
                var userId = createUser.Id;
                var role = _roleManager.FindByIdAsync(newUser.RoleId);
                var addToRoleResult = await _userManager.AddToRoleAsync(createUser, role.Result.Name);

                if (result.Succeeded)
				{
					// Generate email confirmation token
					var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);

					// Generate confirmation link
					var confirmationLink = Url.Action("ConfirmEmail", "Account",
						new { userId = newUser.Id, token = token }, Request.Scheme);

					// Send confirmation email
					await _emailSender.SendEmailAsync(user.Email, "Confirm your email",
						$"Please confirm your email by clicking <a href='{confirmationLink}'>here</a>.");

					// Set success message and return a view notifying the user
					TempData["success"] = "Tạo tài khoản thành công. Vui lòng kiểm tra email của bạn để xác nhận tài khoản.";
					return View("EmailConfirmationNotification", user);  // Redirect to the confirmation view
				}

				// Add errors to ModelState if creation failed
				foreach (IdentityError error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}

			return View(user);  // Return the view with the user model if the form is invalid
		}
        [HttpPost]
        public async Task<IActionResult> ResendConfirmationEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return RedirectToAction("Index", "Home"); // Redirect if user not found
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = Url.Action("ConfirmEmail", "Account",
                new { userId = user.Id, token = token }, Request.Scheme);

            await _emailSender.SendEmailAsync(user.Email, "Confirm your email",
                $"Please confirm your email by clicking <a href='{confirmationLink}'>here</a>.");

            TempData["success"] = "Đã gửi lại email xác nhận. Vui lòng kiểm tra hộp thư của bạn.";
            return RedirectToAction("EmailConfirmationNotification", new { email = user.Email });
        }
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("Index", "Home"); // or a 400 BadRequest page
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                TempData["success"] = "Email đã được xác nhận thành công!";
                return RedirectToAction("Login", "Account");
            }

            TempData["error"] = "Lỗi xác nhận email.";
            return RedirectToAction("Login", "Account");
        }

        public async Task<IActionResult> Logout(string returnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            await HttpContext.SignOutAsync();
            return Redirect(returnUrl);
        }

        public async Task LoginGoogle()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme,
                new AuthenticationProperties
                {
                    RedirectUri = Url.Action("GoogleResponse")
                });
        }

        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (!result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            var claims = result.Principal.Identities.FirstOrDefault().Claims.Select(claim => new
            {
                claim.Issuer,
                claim.OriginalIssuer,
                claim.Type,
                claim.Value,
            });
            var email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            string userName = email.Split('@')[0];
            var existingUser = await _userManager.FindByEmailAsync(email);
            if (existingUser == null)
            {
                var passwordHasher = new PasswordHasher<AppUserModel>();
                var hashedPassword = passwordHasher.HashPassword(null, "123456789");

                var newUser = new AppUserModel { UserName = userName, Email = email, RoleId = "4a0a9d06-7b35-49f4-b1e2-b0ad38a45f44" };
                newUser.PasswordHash = hashedPassword;
                var createUserResult = await _userManager.CreateAsync(newUser);
                if (!createUserResult.Succeeded)
                {
                    TempData["error"] = "Đăng ký tài khoản thất bại,Vui lòng thử lại sau";
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    await _signInManager.SignInAsync(newUser,isPersistent: false);
                    TempData["success"] = "Đăng ký tài khoản thành công";
                    return RedirectToAction("Index", "Home");    
                }
            }
            else
            {
                await _signInManager.SignInAsync(existingUser, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            
        }


    }
}
