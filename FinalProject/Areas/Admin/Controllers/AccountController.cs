using FinalProject.Business.Services.Abstarct;
using FinalProject.Core.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace FinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly SignInManager<AppUser> _signInManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly IEmailService _emailService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, IEmailService emailService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> CreateRoles()
        {
            IdentityRole role = new IdentityRole("SuperAdmin");
            IdentityRole role2 = new IdentityRole("Admin");
            IdentityRole role3 = new IdentityRole("Member");

            await _roleManager.CreateAsync(role);
            await _roleManager.CreateAsync(role2);
            await _roleManager.CreateAsync(role3);

            return Ok("Rollar yarandi!");
        }

        public async Task<IActionResult> CreateAdmin()
        {
            AppUser admin = new AppUser()
            {
                FullName = "Eli Memmedov",
                UserName = "SuperAdmin1",
                Email = "elmemmedov871@gmail.com"
            };

            await _userManager.CreateAsync(admin, "Admin123@");
            await _userManager.AddToRoleAsync(admin, "SuperAdmin");

            return Ok("Admin yarandi!");
        }

        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginVm vm)
        {
            if (!ModelState.IsValid)
                return View();

            AppUser admin = await _userManager.FindByEmailAsync(vm.Email);

            if (admin == null)
            {
                ModelState.AddModelError("", "Email or Password is not valid!");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(admin, vm.Password, vm.IsPersistent, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Email or Password is not valid!");
                return View();
            }


            return RedirectToAction("Index", "Dashboard");


        }

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVm vm)
        {
            if (!ModelState.IsValid)
                return View();

            var user = await _userManager.FindByEmailAsync(vm.Email);

            if (user is not null)
            {
                var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

                var resetTokenLink = Url.Action("ResetPassword", "Account", new { email = vm.Email, token = resetToken }, Request.Scheme);


                string emailBody = @$"<!DOCTYPE html>
<html lang=""en"">
<head>
  <meta charset=""UTF-8"">
  <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
  <title>Reset Your Password</title>
  <style>
    /* Reset CSS for email */
    body, html {{
      margin: 0;
      padding: 0;
      font-family: Arial, sans-serif;
    }}
    
    /* Container styles */
    .container {{
      max-width: 600px;
      margin: 20px auto;
      padding: 20px;
      border: 1px solid #ccc;
      border-radius: 8px;
      background-color: #f9f9f9;
    }}
    
    /* Header styles */
    .header {{
      background-color: #007bff;
      color: #fff;
      text-align: center;
      padding: 10px;
      border-top-left-radius: 8px;
      border-top-right-radius: 8px;
    }}
    
    /* Content styles */
    .content {{
      padding: 20px;
    }}
    
    /* Button styles */
    .btn {{
      display: inline-block;
      background-color: #007bff;
      color: #fff;
      text-decoration: none;
      padding: 10px 20px;
      border-radius: 5px;
    }}
    
    /* Footer styles */
    .footer {{
      margin-top: 20px;
      font-size: 12px;
      text-align: center;
      color: #555;
    }}
  </style>
</head>
<body>
  <div class=""container"">
    <div class=""header"">
      <h2>Reset Your Password</h2>
    </div>
    <div class=""content"">
      <p>Dear [{user.UserName}],</p>
      <p>We received a request to reset the password associated with your account. To proceed with the password reset process, please click on the following button:</p>
      <p style=""text-align: center;"">
        <a class=""btn"" href=""{resetTokenLink}"">Reset Password</a>
      </p>
      <p>If you did not request a password reset, you can safely ignore this email. The link is valid for [X hours/days].</p>
      <p>Please do not hesitate to contact our support team if you encounter any issues or need further assistance.</p>
    </div>
    <div class=""footer"">
      <p>Best regards,<br>[Ali]</p>
    </div>
  </div>
</body>
</html>
";


                _emailService.SendEmail(user.Email ?? "", "Forget password mail", emailBody);

            }
            else
            {
                ModelState.AddModelError("Email", "Email is not valid!");
                return View();
            }

            return RedirectToAction("ForgotPassword");
        }

        public IActionResult ResetPassword(string email, string token)
        {
            if (email == null || token == null) NotFound();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordVm vm)
        {
            if (!ModelState.IsValid)
                return View();

            var user = await _userManager.FindByEmailAsync(vm.Email);

            if (user is not null)
            {
                var result = await _userManager.ResetPasswordAsync(user, vm.Token, vm.NewPassword);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                        return View();
                    }
                }
            }

            return RedirectToAction("Login", "Account");
        }

    }
}
