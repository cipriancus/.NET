using System;
using onlineGrades.Infrastructure.Business;
using Newtonsoft.Json;
using System.Web.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace onlineGrades.Web.Controllers
{
    [Route("/reset-password")]
    public class ConfirmResetPassword : Controller
    {
        private IResetPassworBusiness ResetBusiness;

        public ConfirmResetPassword(IResetPassworBusiness ResetBusiness)
        {
            this.ResetBusiness = ResetBusiness;
        }

        [AcceptVerbs("GET")]//[HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            if (id != null && ResetBusiness.verifyID(id) != null)//validare id
            {
                System.Web.HttpContext.Current.Session["register-id"] = JsonConvert.SerializeObject(id);
                return View("/Views/Home/ResetPassword.cshtml");
            }  
            return View("/Views/Error.cshtml");
        }
    }
}
