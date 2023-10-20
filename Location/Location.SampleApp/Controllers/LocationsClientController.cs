using Microsoft.AspNetCore.Mvc;

namespace Location.SampleApp.Controllers
{
    public class LocationsClientController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int SehirId)
        {
            ViewBag.SehirId = SehirId;
            return View();
        }
        public IActionResult PlainHtml()
        {
            return View();
        }
    }
}
