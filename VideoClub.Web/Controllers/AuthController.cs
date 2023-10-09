using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VideoClub.Core.Entities;
using VideoClub.Web.Models;

namespace VideoClub.Web.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _singInManager;

        public AuthController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> rolemanager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = rolemanager;
            _singInManager = signInManager;
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }

            return returnUrl;
        }

        [HttpGet]
        public ActionResult LogIn(string returnUrl)
        {
            var model = new LogInModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> LogIn(LogInModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _userManager.FindByNameAsync(model.Email);
            if (model.Password == null) model.Password = "";
            if (user != null)
            {
                var signInResult = await SignIn(user, model.Password);
                if (signInResult)
                {
                    return Redirect(GetRedirectUrl(model.ReturnUrl));
                }
            }

            // user authN failed
            ModelState.AddModelError("", "Invalid email or password");
            return View();
        }

        public async Task<ActionResult> LogOut()
        {
            await _singInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                Name = model.Name,
                Surname = model.Surname
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (user.Email == "admin@email.com")
                await _userManager.AddToRoleAsync(user, "Admin");
            else
               await _userManager.AddToRoleAsync(user, "User");

            if (result.Succeeded)
            {
                var signInResult = await SignIn(user, model.Password);
                if (signInResult)
                {
                    return RedirectToAction("index", "home");
                }
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View();
        }

        private async Task<bool> SignIn(ApplicationUser user, string password)
        {
            var result = await _singInManager.CheckPasswordSignInAsync(user, password, true);

            if (result.Succeeded) {
                await _singInManager.SignInAsync(user, isPersistent: false);
                return true;
            }
            return result.Succeeded;
        }
    }
}
