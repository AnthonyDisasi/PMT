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
        private readonly IServicePrioStatTypTitAsync _service;
        private string message;

        public PrioStatTypController(IServicePrioStatTypTitAsync service)
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

        public async Task<IActionResult> Titre()
        {
            ViewData["Message"] = message;
            return View(await _service.GetTitreAsync());
        }

        public async Task<IActionResult> DeleteTitre(string id)
        {
            message = "Titre a été supprimé pas";
            await _service.DisableTitreAsync(id);
            return RedirectToAction(nameof(Titre));
        }

        public async Task<IActionResult> DeleteType(string id)
        {
            message = "Type a été supprimé pas";
            await _service.DisableType(id);
            return RedirectToAction(nameof(Type));
        }

        public async Task<IActionResult> CreateType(string Nom)
        {
            if (Nom == null || Nom == "")
            {
                message = "Remplissez le champ pour valider la création du type";
            }
            else
            {
                await _service.CreateTypeAsync(Nom);
            }
            return RedirectToAction(nameof(Type));
        }

        public async Task<IActionResult> CreateTitre(string Nom)
        {
            if (Nom == null || Nom == "")
            {
                message = "Remplissez le champ pour valider la création du type";
            }
            else
            {
                await _service.CreateTitreAsync(Nom);
            }
            return RedirectToAction(nameof(Titre));
        }
    }
}
