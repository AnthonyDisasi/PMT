using Microsoft.AspNetCore.Mvc;
using PMT.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMT.Controllers
{
    public class PrioStatController : Controller
    {
        private readonly IServicePrioStatAsync service;

        public PrioStatController(IServicePrioStatAsync service)
        {
            this.service = service;
        }

        public IActionResult Priorite()
        {
            return View();
        }

        public IActionResult Statut()
        {
            return View();
        }
    }
}
