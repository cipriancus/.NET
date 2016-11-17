using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FullWebProject.Services;

namespace FullWebProject.Controllers
{
    public class TextController : Controller
    {
        private ITextService textService;

        public TextController(ITextService textService)
        {
            this.textService = textService;
        }
        public IActionResult Index()
        {
            ViewData["Message"] = "TextController works";
            ViewBag.MyMessage = "ViewBag of Index in TextController";

            return View();
        }

        public IActionResult Search()
        {
            string text="John is going to the supermarket";
            char ch = 'i';
            ViewData["Text"] = text;
            ViewData["SpecialCh"] =ch;
            ViewData["No"] = textService.ExtractSpecialCharacterFrom(ch,text);
            ViewBag.MyMessage = "ViewBag of Search in TextController";

            return View();
        }
    }
}
