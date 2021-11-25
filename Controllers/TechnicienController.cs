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
    public class TechnicienController : Controller
    {
        private readonly IServiceTechnicien service;

        public TechnicienController(IServiceTechnicien service)
        {
            this.service = service;
        }


        public async Task<ActionResult> Index()
        {
            return View(await service.Get());
        }

        public async Task<ActionResult> Details(string id)
        {
            if(id == null)
            {
                ViewBag.TachesList = await service.GetTaches(id);
                return View(await service.Get(id));
            }
            else
            {
                return NotFound();
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Technicien model)
        {
            if (ModelState.IsValid)
            {
                await service.Create(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<ActionResult> Edit(string id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var model = await service.Get(id);
            if(model == null)
            {
                return NotFound();
            }

            return View(await service.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, Technicien model)
        {
            if(id != model.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                ViewBag.Message = await service.Update(model, id);
            }
            return View(model);
        }

        public async Task<ActionResult> Delete(string id)
        {
            if(id == null)
            {
                return NotFound();
            }
            
            var model = await service.Get(id);
            if(model == null)
            {
                return NotFound();
            }

            return View(await service.Get(id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteMethod(string id)
        {
            ViewBag.Message = await service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
