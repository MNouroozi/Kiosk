using Kiosk.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kiosk.Controllers
{
    public class PersonelLocationController : Controller
    {
        private readonly ICANSBMPSContext _context;

        public PersonelLocationController(ICANSBMPSContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
