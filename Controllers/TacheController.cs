﻿using Microsoft.AspNetCore.Authorization;
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

        public async Task<IActionResult> Index()
            => View(await _service.Get());
        public async Task<IActionResult> IndexTache()
            => View(await _service.GetWhereDateFinMax());
        public async Task<IActionResult> Details(string id)
            => View(await _service.Get(id));

        public async Task<IActionResult> Create()
        {
            ViewData["Priorites"] = await _service.ListePriorite();
            ViewData["Statuts"] = await _service.ListStatut();
            ViewData["Types"] = await _service.ListeType();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tache model)
        {
            //model.ParentID = "45ea0b4d-1fed-4620-b1d1-72a001ad93cc";
            if (ModelState.IsValid)
            {
                await _service.Create(model, User.Identity.Name);
                return RedirectToAction(nameof(IndexTache));
            }

            ViewData["Priorites"] = await _service.ListePriorite();
            ViewData["Statuts"] = await _service.ListStatut();
            ViewData["Types"] = await _service.ListeType();
            return View(model);
        }
        
        public async Task<IActionResult> CreateSousTache(string id)
        {
            ViewData["IdParent"] = id;
            ViewData["Priorites"] = await _service.ListePriorite();
            ViewData["Statuts"] = await _service.ListStatut();
            ViewData["Types"] = await _service.ListeType();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreateSousTache(Tache tache)
        {
            if (ModelState.IsValid)
            {
                var model = await _service.Create(tache, User.Identity.Name);
                await _service.AddSousTacheAsync(model, tache.TacheID);
                return RedirectToAction("IndexTache");
            }
            if(tache.TacheID != null)
            {

                ViewData["IdParent"] = tache.TacheID;
            }
            ViewData["Priorites"] = await _service.ListePriorite();
            ViewData["Statuts"] = await _service.ListStatut();
            ViewData["Types"] = await _service.ListeType();
            return View(tache);
        }

        public async Task<IActionResult> TacheParent(string id)
            => View(await _service.Get(id));

        public async Task<IActionResult> Edit(string id)
        {
            ViewData["Priorites"] = await _service.ListePriorite();
            ViewData["Types"] = await _service.ListeType();
            ViewData["Statuts"] = await _service.ListStatut();
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
                return RedirectToAction(nameof(IndexTache));

            }
            ViewData["Priorites"] = await _service.ListePriorite();
            ViewData["Statuts"] = await _service.ListStatut();
            ViewData["Types"] = await _service.ListeType();
            return View(model);
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
    }
}
