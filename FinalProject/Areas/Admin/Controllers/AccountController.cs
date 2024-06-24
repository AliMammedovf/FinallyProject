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

		public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
		{
			_roleManager = roleManager;
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public IActionResult Login()
		{
			return View();
		}

		//public async Task<IActionResult> CreateRoles()
		//{
		//	IdentityRole role = new IdentityRole("SuperAdmin");
		//	IdentityRole role2 = new IdentityRole("Admin");
		//	IdentityRole role3 = new IdentityRole("Member");

		//	await _roleManager.CreateAsync(role);
		//	await _roleManager.CreateAsync(role2);
		//	await _roleManager.CreateAsync(role3);

		//	return Ok("Rollar yarandi!");
		//}

		//public async Task<IActionResult> CreateAdmin()
		//{
		//	AppUser admin = new AppUser()
		//	{
		//		FullName = "Eli Memmedov",
		//		UserName ="SuperAdmin1",
		//		Email = "elmemmedov871@gmail.com"
		//	};

		//	await _userManager.CreateAsync(admin, "Admin123@");
		//	await _userManager.AddToRoleAsync(admin, "SuperAdmin");

		//	return Ok("Admin yarandi!");
		//}

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

			var user= await _userManager.FindByEmailAsync(vm.Email);

			if (user is not null)
			{
				var token=await _userManager.GeneratePasswordResetTokenAsync(user);
				
				var resetTokenLink= Url.Action("ResetPassword","Account", new {email=vm.Email, token}, Request.Scheme);
			}
			else
			{
				ModelState.AddModelError("Email", "Email is not valid!");
				return View();
			}

			return View("");
		}

		public IActionResult ResetPassword(string email, string token)
		{
			if(email==null || token==null) NotFound();

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ResetPassword(ResetPasswordVm vm)
		{
            if (!ModelState.IsValid)
                return View();

			var user= await _userManager.FindByEmailAsync(vm.Email);	

			if (user is not null)
			{
				var result = await _userManager.ResetPasswordAsync(user, vm.Token, vm.NewPassword);

				if (!result.Succeeded)
				{
					foreach (var error in result.Errors)
					{
						ModelState.AddModelError("",error.Description);
						return View();
					}
				}
			}

			return RedirectToAction("Login","Account");
        }
	
	}
}
