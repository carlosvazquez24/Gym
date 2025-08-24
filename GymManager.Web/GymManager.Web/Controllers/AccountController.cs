using GymManager.Core.Members;
using GymManager.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using LoginModel = GymManager.Web.Models.LoginModel;

namespace GymManager.Web.Controlers
{
    public class AccountController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        //Constructor
        public AccountController(SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

            //Ensure that there's no users
            if (!_userManager.Users.Any())
            {
                //There's no users, make one
                var result = _userManager.CreateAsync(new IdentityUser
                {
                    Email = "carlosEliam@gmail.com",
                    EmailConfirmed = true,
                    UserName = "carlosEliam@gmail.com"


                }, "Tacos123*").Result;
            }


        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            //Get the url to return in case of success
            string returnUrl = string.IsNullOrEmpty(Request.Query["returnUrl"]) ? Url.Content("~/") : Request.Query["returnUrl"];

            //Validate the ModelState
            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    return LocalRedirect(returnUrl);
                }

                if (result.IsLockedOut)
                {
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View();

                }
            }

            return View();
        }

    }
}
