using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace onlineGrades.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public ActionResult Login()
        {
            ViewData["Message"] = "Your login page.";

            return View();
        }

        public ActionResult Register()
        {
            ViewData["Message"] = "Your register page.";

            return View();
        }
        public ActionResult ForgotPassword()
        {
            ViewData["Message"] = "Your Forgot Password page.";

            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}
