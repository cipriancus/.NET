using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using onlineGrades.Infrastructure.Business;
using System.ComponentModel.DataAnnotations;
using onlineGrades.MVC.Models;
using onlineGrades.Core.Entity;
using onlineGrades.Core.Session_Data;
using Newtonsoft.Json;
using System.Web.Mvc;
using onlineGrades.Web.Controllers.Dashboard;

namespace onlineGrades.Web.Controllers
{
    public class LoginController : Controller
    {
        private ILoginBusiness LoginBusiness;

        public LoginController(ILoginBusiness LoginBusiness)
        {
            this.LoginBusiness = LoginBusiness;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUser(LoginViewModel viewModel)
        {
            object user = LoginBusiness.verifyLogin(viewModel.Username,viewModel.Password);

            if (user != null)
            {
                if (user is Student)
                {
                    SessionData sessionData = new SessionData();
                    sessionData.student = (Student)user;
                    System.Web.HttpContext.Current.Session["register-id"] = JsonConvert.SerializeObject(sessionData);
                    return View("/Views/Studenti/StudentiDashboard.cshtml");
                }
                else if (user is Profesor)
                {
                    SessionData sessionData = new SessionData();
                    sessionData.profesor = (Profesor)user;
                    System.Web.HttpContext.Current.Session["register-id"] = JsonConvert.SerializeObject(sessionData);
                    return View("/Views/Profesori/ProfesoriDashboard.cshtml");
                }
            }
            else
            {
                return View("/Views/Error.cshtml");
            }
            return View();
        }
    }
}
