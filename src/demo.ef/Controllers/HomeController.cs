using demo.ef.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace demo.ef.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View(_context.Users.ToList());
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            if (!_context.Users.Any())
            {
                for (int i = 0; i < 5; i++)
                {
                    _context.Users.Add(new User { FirstName = "User", LastName = "number " + i });
                }
                _context.SaveChanges();
            }
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}