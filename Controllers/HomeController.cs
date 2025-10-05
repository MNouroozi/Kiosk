using Microsoft.AspNetCore.Mvc;
using Kiosk.Models;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public JsonResult Search(string trackingCode)
        {
            if (string.IsNullOrEmpty(trackingCode))
                return Json(new List<EntityHistoryTracking>());

            var result = _context.EntityHistoryTrackings
                .Where(h => h.ExportEntityNumber != null && h.ExportEntityNumber.Contains(trackingCode))
                .ToList();

            return Json(result);
        }

        [HttpGet]
        public JsonResult GetTrackingHistory(int etc, int fec)
        {
            try
            {
                // لاگ برای دیباگ
                Console.WriteLine($"Searching for ETC: {etc}, FEC: {fec}");

                var history = _context.EntityHistoryTrackingViews
                    .Where(h => h.EntityTypeCode == etc && h.EntityCode == fec)
                    .OrderByDescending(h => h.ReceiveDate)
                    .AsNoTracking()
                    .ToList();

                // لاگ تعداد رکوردهای یافت شده
                Console.WriteLine($"Found {history.Count} records");

                return Json(history);
            }
            catch (Exception ex)
            {
                // لاگ خطا
                Console.WriteLine($"Error: {ex.Message}");
                return Json(new { error = ex.Message });
            }
        }
    }
}