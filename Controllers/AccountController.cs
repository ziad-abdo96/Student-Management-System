using FirstProject.Models.Entities;
using FirstProject.ViewModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace FirstProject.Controllers
{
	public class AccountController : Controller
	{
		UserManager<ApplicationUser> _userManager;
		SignInManager<ApplicationUser> _signInManager;

		
		public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}


		[HttpGet]
		public ActionResult Register()
		{
			return View();
		}
		
		[HttpPost]
		public async Task<ActionResult> Register(RegisterUserViewModel registerUserVM)
		{
			if (ModelState.IsValid)
			{

				ApplicationUser appUser = new ApplicationUser();

				appUser.UserName = registerUserVM.UserName;
				appUser.PasswordHash = registerUserVM.Password;
				appUser.Address = registerUserVM.Address;


				IdentityResult result = await _userManager.CreateAsync(appUser, registerUserVM.Password);

				if (result.Succeeded)
				{

					IdentityResult AddRole = await _userManager.AddToRoleAsync(appUser, "Admin");

					if(!AddRole.Succeeded)
					{
						foreach(var error in AddRole.Errors)
						{
							ModelState.AddModelError("", error.Description);
						}
						return View(registerUserVM);
					}

					await _signInManager.SignInAsync(appUser, false);

					return RedirectToAction("Index", "Department");
				}
				

				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}


			return View("Register", registerUserVM);
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View("Login");
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginUserViewModel userViewModel)
		{
			if(ModelState.IsValid)
			{
				ApplicationUser appUser = await _userManager.FindByNameAsync(userViewModel.UserName);
				if(appUser != null)
				{
					bool isPasswordFound = await _userManager.CheckPasswordAsync(appUser, userViewModel.Password);

					if (isPasswordFound)
					{
						List<Claim> claims = new List<Claim>();

						claims.Add(new Claim("UserAddress", appUser.Address));
						await _signInManager.SignInWithClaimsAsync(appUser, userViewModel.RemeberMe, claims);
						return RedirectToAction("Index", "Department");
					}
				}
				ModelState.AddModelError("", "Username OR Password is wrong");

			}

			return View("Login", userViewModel);
		}

		public async Task<IActionResult> SignOut()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Login");
		}
	}
}
