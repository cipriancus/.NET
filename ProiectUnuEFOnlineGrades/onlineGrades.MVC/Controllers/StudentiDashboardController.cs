using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace onlineGrades.Web.Controllers.Dashboard
{
    public class StudentiDashboardController : Controller
    {
        // GET: /<controller>/
        public ActionResult Index()
        {
            return View();
        }
    }
}
