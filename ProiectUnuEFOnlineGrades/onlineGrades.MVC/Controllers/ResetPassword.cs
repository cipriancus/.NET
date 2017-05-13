using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using onlineGrades.Infrastructure.Business;
using System.ComponentModel.DataAnnotations;
using onlineGrades.MVC.Models;
using onlineGrades.Core.Entity;
using System.Web.Mvc;
using onlineGrades.Core.Session_Data;
using Newtonsoft.Json;
using onlineGrades.Web.Controllers.Dashboard;


namespace onlineGrades.Web.Controllers
{
    public class ResetPassword : Controller
    {
        private IResetPassworBusiness ResetBusiness;
        private IMailBusiness MailBusiness;
        private IRegisterBusiness RegisterBusiness;


        public ResetPassword(IResetPassworBusiness ResetBusiness, IMailBusiness MailBusiness,  IRegisterBusiness RegisterBusiness)
        {
            this.ResetBusiness = ResetBusiness;
            this.RegisterBusiness = RegisterBusiness;
            this.MailBusiness = MailBusiness;

        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendResetMail(ResetPasswordViewModel viewModel)
        {
            User user = ResetBusiness.getUser(viewModel.Email,viewModel.TipCont);

            if (user != null)
            {
                if (viewModel.TipCont.CompareTo("student") == 0 && user is Student)
                {
                    Student student = (Student)user;
                    student.ResetUUID = Guid.NewGuid();
                    user = student;
                    RegisterBusiness.editStudent(student);
                } else
                if (viewModel.TipCont.CompareTo("profesor") == 0 && user is Profesor)
                {
                    Profesor profesor = (Profesor)user;
                    profesor.ResetUUID = Guid.NewGuid();
                    user = profesor;
                    RegisterBusiness.editProfesor(profesor);
                }
                else
                {
                    return View("/Views/Error.cshtml");
                }
                MailBusiness.sendResetMail(user);


                return View("/Views/Home/Login.cshtml");
            }
            return View("/Views/Error.cshtml");
        }
        

        public ActionResult NewPassword(NewPasswordViewModel viewModel)
        {
            if (viewModel.Parola == viewModel.ParolaC)
            {
                Guid id = JsonConvert.DeserializeObject<Guid>((string)System.Web.HttpContext.Current.Session["register-id"]);
                if (id != null)
                {
                    User user = ResetBusiness.verifyID(id);

                    if (user  != null)
                    {
                        user.Password=Cryptography.Sha256Password(viewModel.Parola);

                        if ( user is Student)
                        {
                            Student student = (Student)user;
                            student.ResetUUID = new Guid();
                            user = student;
                            RegisterBusiness.editStudent(student);
                            return View("/Views/Studenti/StudentiDashboard.cshtml");

                        }
                        else
                        if (user is Profesor)
                        {
                            Profesor profesor = (Profesor)user;
                            profesor.ResetUUID = new Guid();
                            user = profesor;
                            RegisterBusiness.editProfesor(profesor);
                            return View("/Views/Profesori/ProfesoriDashboard.cshtml");

                        }
                        else
                        {
                            return View("/Views/Error.cshtml");
                        }
                    }
                }
            }
            return View("/Views/Error.cshtml");
        }

    }
}
