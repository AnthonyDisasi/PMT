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
    public class TacheController : Controller
    {
        private readonly IServiceTache _service;

        public TacheController(IServiceTache service)
        {
            _service = service;
        }
        /// <summary>
        /// IndexTache qui renvoit vers la liste de toute les tâches
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> IndexTache()
            => View(await _service.Get());

        public async Task<IActionResult> Details(string id)
        {
            ViewData["Responsable"] = await _service.GetUser();
            return View(await _service.Get(id));
        }

        public async Task<IActionResult> DetailSoustache(string id)
            => View(await _service.GetSoustacheAsync(id));

        public async Task<IActionResult> Create()
        {
            ViewData["Types"] = await _service.ListeType();
            ViewData["Responsable"] = await _service.GetUser();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tache model)
        {
            if (ModelState.IsValid)
            {
                await _service.Create(model, User.Identity.Name);
                return RedirectToAction(nameof(IndexTache));
            }
            ViewData["Types"] = await _service.ListeType();
            ViewData["Responsable"] = await _service.GetUser();
            return View(model);
        }
        
        public async Task<IActionResult> CreateSousTache(string id)
        {
            ViewData["IdParent"] = id;
            ViewData["Types"] = await _service.ListeType();
            ViewData["Responsable"] = await _service.GetUser();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreateSousTache(SousTache soustache)
        {
            if (ModelState.IsValid)
            {
                soustache.CreateurTache = User.Identity.Name;
                 await _service.AddSousTacheAsync(soustache, soustache.TacheID);
                return RedirectToAction("Details", new {id = soustache.TacheID});
            }
            ViewData["IdParent"] = soustache.TacheID;
            ViewData["Types"] = await _service.ListeType();
            ViewData["Responsable"] = await _service.GetUser();
            return View(soustache);
        }

        public async Task<IActionResult> Edit(string id)
        {
            ViewData["Types"] = await _service.ListeType();
            ViewData["Responsable"] = await _service.GetUser();
            return View(await _service.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Tache model)
        {
            model.EstActif = true;
            if (ModelState.IsValid)
            {
                model.CreateurTache = User.Identity.Name;
                await _service.Update(model);
                return RedirectToAction("Details", new {id = model.ID});

            }
            ViewData["Types"] = await _service.ListeType();
            ViewData["Responsable"] = await _service.GetUser();
            return View(model);
        }

        public async Task<IActionResult> EditSousTache(string id, string Tacheid)
        {
            ViewData["TacheId"] = Tacheid;
            ViewData["Types"] = await _service.ListeType();
            ViewData["Responsable"] = await _service.GetUser();
            return View(await _service.GetSoustacheAsync(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSousTache(SousTache sousTache)
        {
            string idParent = sousTache.TacheID;
            string idt = sousTache.ID;
            if (ModelState.IsValid)
            {
                sousTache.CreateurTache = User.Identity.Name;
                var model = await _service.UpdateSousTache(sousTache, idParent);
                await _service.UpdateSousTacheAsync(model);
                return RedirectToAction("Details", new {id = idParent});
            }
            ViewData["TacheId"] = sousTache.TacheID;
            ViewData["Types"] = await _service.ListeType();
            ViewData["Responsable"] = await _service.GetUser();
            return View(sousTache);
        }

        public async Task<IActionResult> Delete(string id)
            => View(await _service.Get(id));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Tache model)
        {
            await _service.Delete(model.ID);
            return RedirectToAction(nameof(IndexTache));
        }

        public async Task<IActionResult> DeleteSousTache(string id)
            => View(await _service.GetSoustacheAsync(id));


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSousTache(SousTache sousTache)
        {
            await _service.DeleteSousTacheAsync(sousTache.ID);
            return RedirectToAction(nameof(IndexTache));
        }

        public async Task<IActionResult> ListAffectationEtDetailsTache(string id)
        {
            ViewData["ListTech"] = await _service.ListUser();
            return View(await _service.Get(id));
        }

        [HttpGet]
        public async Task<IActionResult> AddCommentaire(string idTache, string commentaire)
        {
            await _service.AddNote(commentaire, idTache, User.Identity.Name);
            return RedirectToAction("Details", new { id = idTache });
        }

        [HttpGet]
        public async Task<IActionResult> AddNote(string idSousTache, string commetaire)
        {
            await _service.AddCommentaire(commetaire, idSousTache, User.Identity.Name);
            return RedirectToAction("DetailSoustache", new { id = idSousTache });
        }
    }
}
