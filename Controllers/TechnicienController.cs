using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class TechnicienController : Controller
    {
        private readonly IServiceTechnicien service;

        public TechnicienController(IServiceTechnicien service)
        {
            this.service = service;
        }


        public async Task<IActionResult> Index()
        {
            return View(await service.Get());
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id != null)
            {
                ViewBag.TachesList = await service.GetTaches(id);
                return View(await service.Get(id));
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> Profil()
            => View(await service.GetIdUser(User.Identity.Name));

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(technicienModel model)
        {
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
                    Username = model.Username
                };

                await service.Create(technicien);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await service.Get(id);
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
            if (model == null)
            {
                return NotFound();
            }

            ViewData["technicienID"] = id;
            return View(technicien);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(technicienModel model)
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

                ViewBag.Message = await service.Update(technicien, technicien.ID);
                return RedirectToAction(nameof(Index));
            }

            ViewData["technicienID"] = model.ID;
            return View(model);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await service.Get(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(await service.Get(id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMethod(Technicien model)
        {
            ViewBag.Message = await service.Delete(model.ID);
            return RedirectToAction(nameof(Index));
        }
    }
}
