using Microsoft.AspNetCore.Mvc;

namespace demo.ef.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "demo.mvc";
            ViewBag.Message2 = "view bag message";
            return View();
        }
    }
}