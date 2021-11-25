using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PMT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMT.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<User_App> userManager;
        private SignInManager<User_App> signInManager;

        public AccountController(UserManager<User_App> userManager,
            SignInManager<User_App> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel login, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                User_App user = await userManager.FindByNameAsync(login.Username);
                if(user != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, login.Password, false, false);
                    if (result.Succeeded)
                    {
                        HttpContext.Session.SetString("identifiant", user.Id);
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError(nameof(LoginModel.Username), "Le mot de passe ou le 'username' sont invalides");
            }
            return View(login);
        }

        public async Task<IActionResult> Logout(string returnUrl)
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl ?? "Login");
        }
    }
}
