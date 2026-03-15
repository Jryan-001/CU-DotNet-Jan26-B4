using Microsoft.AspNetCore.Mvc;

namespace FinTrackPro.Controllers
{
    public class MarketController : Controller
    {

        [HttpGet("Analyze/{ticker}/{days:int?}")]
        public IActionResult Analyze(string ticker, int? days)
        {
            if (days == null)
            {
                days = 30;
            }
            ViewBag.Ticker = ticker;
            ViewBag.Days = days;
            return View();
        }
        public IActionResult Summary()
        {
            ViewBag.MarketStatus = "Open";
            ViewData["TopGainer"] = "TS";
            ViewData["Volume"] = 1500000;
            return View();
        }
    }
}
