using FullWebProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace FullWebProject.Controllers
{
    public class HospitalController : Controller
    {
        private readonly IMyService _service;

        public HospitalController(IMyService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            ViewBag.MyMessage = "Scheduled: " + _service.IsScheduled();
            return View();
        }
    }
}