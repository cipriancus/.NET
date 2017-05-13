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
using onlineGrades.Web.Controllers.Dashboard;
using System.Web.Mvc;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace onlineGrades.Web.Controllers
{
    public class RegisterController : Controller
    {

        private IRegisterBusiness RegisterBusiness;
        private IMailBusiness MailBusiness;

        public RegisterController(IRegisterBusiness RegisterBusiness,IMailBusiness MailBusiness)
        {
            this.RegisterBusiness = RegisterBusiness;
            this.MailBusiness = MailBusiness;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register(RegisterViewModel viewModel)
        {
            if (viewModel.Password == viewModel.Re_Password)
            {
                User user = new User();
                user.Nume = viewModel.Nume;  
                user.Nume = viewModel.Nume;
                user.Prenume = viewModel.Prenume;
                user.InitialaTata = viewModel.InitialaTata;
                user.Email = viewModel.Email;
                user.DataNasterii = viewModel.DataNasterii;
                user.Mama = viewModel.Mama;
                user.Tata = viewModel.Tata;
                user.Nationalitate = viewModel.Nationalitate;
                user.Cetatenie = viewModel.Cetatenie;
                user.Username = viewModel.Username;
                user.Password = Cryptography.Sha256Password(viewModel.Password);
                user.RegisterUUID = Guid.NewGuid();
                       
                if (viewModel.TipCont.CompareTo("student")==0)
                {
                    Student student = new Student(user);
                    student.AnUniversitar = 0;
                    RegisterBusiness.registerStudent(student);
                }else{
                    Profesor profesor = new Profesor(user);
                    RegisterBusiness.registerProfesor(profesor);
                }
                MailBusiness.sendRegisterMail(user);
            }
            else
            {
                return View("/Views/Error.cshtml");
            }
            return View("/Views/Home/Login.cshtml");
        }
    }
}
