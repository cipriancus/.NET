using System;
using Newtonsoft.Json;
using System.Web.Mvc;
using onlineGrades.Infrastructure.Business;

namespace onlineGrades.Web.Controllers
{
    [Route("/confirm-register")]
    public class ConfirmRegisterController : Controller
    {
        private IRegisterBusiness RegisterBusiness;
        
        public ConfirmRegisterController(IRegisterBusiness RegisterBusiness)
        {
            this.RegisterBusiness = RegisterBusiness;
        }

        // GET confirm-register/5
        [AcceptVerbs("GET")]//[HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            if (RegisterBusiness.confirmUser(id) == true)
            {
                return View("/Views/Home/Login.cshtml");
            }
            return View("/Views/Error.cshtml");
        }
    }
}
