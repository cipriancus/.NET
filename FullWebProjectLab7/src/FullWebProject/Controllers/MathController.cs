using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FullWebProject.Services;

namespace FullWebProject.Controllers
{
    public class MathController : Controller
    {
        private IMathService mathService; 

        public MathController(IMathService mathService)
        {
            this.mathService = mathService;
        }

        public IActionResult Index([FromServices] IMathService mathService)
        {
            ViewData["Message"] = "Rezultat"+mathService.ComputeVat((double)500, 20);
            ViewBag.MyMessage = "ViewBag of Index in MathController";
            return View();
        }

        public IActionResult ItWorks()
        {
            ViewData["Number 1"] =1000;
            ViewData["VAT"] = 24;
            ViewData["Result"] =mathService.ComputeVat((double)500, 24);
            ViewBag.MyMessage = "ViewBag of ItWorks in MathController";

            return View();
        }
    }
}
