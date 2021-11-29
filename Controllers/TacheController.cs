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
    public class TacheController : Controller
    {
        private readonly IServiceTache _service;

        public TacheController(IServiceTache service)
        {
            _service = service;
        }

        public async Task<ActionResult> Index()
            => View(await _service.Get());

        public async Task<ActionResult> Details(string id)
            => View(await _service.Get(id));

        public async Task<ActionResult> Create()
        {
            ViewData["Priorites"] = await _service.ListePriorite();
            ViewData["Statuts"] = await _service.ListStatut();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Tache model)
        {
            if (ModelState.IsValid)
            {
                //anthony.disasi
                //await _service.Create(model, User.Identity.Name);
                await _service.Create(model, "anthony.disasi");
                return RedirectToAction(nameof(Index));
            }

            ViewData["Priorites"] = await _service.ListePriorite();
            ViewData["Statuts"] = await _service.ListStatut();
            return View(model);
        }

        public async Task<IActionResult> Edit(string id)
        {
            ViewData["Priorites"] = await _service.ListePriorite();
            ViewData["Statuts"] = await _service.ListStatut();
            return View(await _service.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Tache model)
        {
            if (ModelState.IsValid)
            {
                await _service.Update(model);
                return RedirectToAction(nameof(Index));

            }
            ViewData["Priorites"] = await _service.ListePriorite();
            ViewData["Statuts"] = await _service.ListStatut();
            return View(model);
        }

        public async Task<ActionResult> Delete(string id)
            => View(await _service.Get(id));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Tache model)
        {
            await _service.Delete(model.ID);
            return RedirectToAction(nameof(Index));
        }
    }
}
