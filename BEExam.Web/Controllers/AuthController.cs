using BEExam.Core.Entities;
using BEExam.Web.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using NuGet.Packaging.Signing;

namespace BEExam.Web.Controllers
{
    public class AuthController : Controller
    {
        private UserManager<User> _userManager { get; }
        private SignInManager<User> _signInManager { get; }

        public AuthController(UserManager<User> userManager,SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Username of password is wrong!");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password,false,false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username of password is wrong!");
                return View(model);
            }

            if (TempData["ReturnUrl"] != null)
                return LocalRedirect(TempData["ReturnUrl"].ToString());
                
            return RedirectToAction(nameof(Index),"Home");
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = new User(model.Name, model.Surname,model.Email);
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
                return View(model);
            }

            return RedirectToAction(nameof(Login));
        }





    }
}
