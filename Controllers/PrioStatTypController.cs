using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMT.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMT.Controllers
{
    [Authorize]
    public class PrioStatTypController : Controller
    {
        private readonly IServicePrioStatTypAsync _service;
        private string message;

        public PrioStatTypController(IServicePrioStatTypAsync service)
        {
            _service = service;
        }

        public string Create(string Nom)
        {
            return Nom;
        }

        public async Task<IActionResult> Type()
        {
            ViewData["Message"] = message;
            return View(await _service.GetListTypeAsync());
        }

        public async Task<IActionResult> Priorite()
        {
            ViewData["Message"] = message;
            return View(await _service.GetListPrioriteAsync());
        }

        public async Task<IActionResult> Statut()
        {
            ViewData["Message"] = message;
            return View(await _service.GetListStatutAsync());
        }

        public async Task<IActionResult> DeletePriorite(string id)
        {
            message = "Priorité a été supprimé pas";
            await _service.DisablePriorite(id);
            return RedirectToAction(nameof(Priorite));
        }

        public async Task<IActionResult> DeleteStatut(string id)
        {
            message = "Priorité a été supprimé pas";
            await _service.DisasbleStatut(id);
            return RedirectToAction(nameof(Statut));
        }

        public async Task<IActionResult> PrioStatTyp(string id)
        {
            message = "Priorité a été supprimé pas";
            await _service.DisableType(id);
            return RedirectToAction(nameof(Type));
        }

        public async Task<IActionResult> CreatePriorite(string Nom)
        {
            if(Nom == null || Nom == "")
            {
                message = "Remplissez le champ pour valider la création de la priorité";
            }
            else
            {
                message = "Priorité a été supprimé pas";
                await _service.CreatePrioriteAsync(Nom);
            }
            return RedirectToAction(nameof(Priorite));
        }

        public async Task<IActionResult> CreateStatut(string Nom)
        {
            if (Nom == null || Nom == "")
            {
                message = "Remplissez le champ pour valider la création du statut";
            }
            else
            {
                message = "Priorité a été supprimé pas";
                await _service.CreateStatutAsync(Nom);
            }
            return RedirectToAction(nameof(Statut));
        }

        public async Task<IActionResult> CreateType(string Nom)
        {
            if (Nom == null || Nom == "")
            {
                message = "Remplissez le champ pour valider la création du type";
            }
            else
            {
                message = "Priorité a été supprimé pas";
                await _service.CreateTypeAsync(Nom);
            }
            return RedirectToAction(nameof(Type));
        }
    }
}
