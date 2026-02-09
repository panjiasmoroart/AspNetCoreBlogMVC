using AspNetCoreBlogMVC.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreBlogMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;

		public AccountController(UserManager<IdentityUser> userManager,
			SignInManager<IdentityUser> signInManager)
		{
			this.userManager = userManager;
		}


		[HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var identityUser = new IdentityUser
                {
					UserName = registerViewModel.Username,
					Email = registerViewModel.Email
				};

                var identityResult = await userManager.CreateAsync(identityUser, registerViewModel.Password);
                if (identityResult.Succeeded)
                {
					// assign this user the "User" role
                    var roleIdentityResult = await userManager.AddToRoleAsync(identityUser, "User");
                    if (roleIdentityResult.Succeeded)
                    {
						// Show success notification
						return RedirectToAction("Register");
					}
				}
			}

			// Show error notification
			return View();
		}

	}
}
