using Microsoft.AspNetCore.Mvc;
using Kiosk.Models;

namespace Kiosk.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICANSBMPSContext _context;

        public HomeController(ICANSBMPSContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}