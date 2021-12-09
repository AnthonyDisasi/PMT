using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PMT.Models;
using PMT.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMT.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IServiceTechnicien _service;
        private UserManager<User_App> userManager;
        private SignInManager<User_App> signInManager;

        public AccountController(UserManager<User_App> userManager,
            SignInManager<User_App> signInManager,
            IServiceTechnicien service)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _service = service;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
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
                        return RedirectToAction(nameof(Profil));
                    }
                }
                ModelState.AddModelError(nameof(LoginModel.Username), "Le mot de passe ou le 'username' sont invalides");
            }
            return View(login);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Redirect("Login");
        }

        public async Task<IActionResult> Profil()
            => View(await _service.GetUserByUsername(User.Identity.Name));

        public async Task<IActionResult> EditProfil()
        {
            var model = await _service.GetUserByUsername(User.Identity.Name);
            var technicien = new technicienModel
            {
                ID = model.ID,
                Nom = model.Nom,
                Postnom = model.Postnom,
                Prenom = model.Prenom,
                Titre = model.Titre,
                Username = model.Username,
                Mail = model.Mail,
                Password = model.Password,
                ConfirmPassword = model.Password
            };
            ViewData["technicienID"] = model.ID;
            return View(technicien);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfil(technicienModel model)
        {
            if (model.ID != model.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var technicien = new Technicien
                {
                    ID = model.ID,
                    Nom = model.Nom,
                    Postnom = model.Postnom,
                    Prenom = model.Prenom,
                    Mail = model.Mail,
                    Password = model.Password,
                    Titre = model.Titre,
                    Username = model.Username,
                    EstActif = true
                };

                ViewBag.Message = await _service.Update(technicien, technicien.ID);
                return RedirectToAction(nameof(Profil));
            }

            ViewData["technicienID"] = model.ID;
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
