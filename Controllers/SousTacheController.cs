using Microsoft.AspNetCore.Mvc;
using PMT.Interfaces;
using PMT.Models;
using System;
using System.Threading.Tasks;

namespace PMT.Controllers
{
    public class SousTacheController : Controller
    {
        private readonly ISousTacheServiceAsync _service;

        public SousTacheController(ISousTacheServiceAsync service)
        {
            _service = service;
        }

        public async Task<IActionResult> Create(string id)
        {
            ViewData["IdTacheParent"] = id;
            ViewData["Types"] = await _service.ListeTypeAsync();
            ViewData["Responsable"] = await _service.GetUserAsync();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(SousTache model)
        {
            model.CreateurTache = User.Identity.Name;

            if (ModelState.IsValid)
            {
                await _service.AddSousTacheAsync(model);
                return RedirectToAction("Detail", new { id = model.SousTacheID });
            }

            ViewData["IdTacheParent"] = model.SousTacheID;
            ViewData["Types"] = await _service.ListeTypeAsync();
            ViewData["Responsable"] = await _service.GetUserAsync();
            return View(model);
        }

        public async Task<IActionResult> Delete(string id)
            => View(await _service.GetSousTacheAsync(id));

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Delete(SousTache model)
        {
            string id_ = await _service.DeleteSousTacheAsync(model.ID);
            return RedirectToAction("Detail", new { id = id_ });
        }

        public async Task<IActionResult> Update(string id, string idParent)
        {
            ViewData["IdTacheParent"] = idParent;
            ViewData["Types"] = await _service.ListeTypeAsync();
            ViewData["Responsable"] = await _service.GetUserAsync();
            return View(await _service.GetSousTacheAsync(id));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(SousTache model)
        {
            string id = model.SousTacheID;
            string idST = model.ID;
            if (ModelState.IsValid)
            {
                model.CreateurTache = User.Identity.Name;
                var model_sous = await _service.UpdateSousTacheAsync(model, model.SousTacheID);
                await _service.UpdateSousTacheParentAsync(model_sous);
                return RedirectToAction("Detail", new { id = model.SousTacheID });
            }
            await _service.UpdateSousTacheAsync(model, model.ID);

            ViewData["IdTacheParent"] = model.SousTacheID;
            ViewData["Types"] = await _service.ListeTypeAsync();
            ViewData["Responsable"] = await _service.GetUserAsync();
            return View(model);
        }

        public async Task<IActionResult> Detail(string id)
        {
            var model = await _service.GetSousTacheAsync(id);
            if (model.SousTacheID is null && model.TacheID != null)
            {
                return RedirectToAction("Details", "Tache", new {id = model.TacheID});
            }
            return View(model);
        }
    }
}
