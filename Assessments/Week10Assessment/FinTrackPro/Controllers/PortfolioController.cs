using FinTrackPro.Models;
using Microsoft.AspNetCore.Mvc;
//using NuGet.ContentModel;

namespace FinTrackPro.Controllers
{
    public class PortfolioController : Controller
    {
        private static List<Stocks> assets = new List<Stocks>()
        {
            new Stocks
            {
                Id = 1,
                Name = "Tata",
                Price = 900,
                Quantity=1000
            },
            new Stocks
            {
                Id = 2,
                Name = "Anthropic",
                Price = 2000,
                Quantity=100000
            }
        };
        public IActionResult Index()
        {
            double total = 0;
            foreach(var s in assets)
            {
                total+=s.Price * s.Quantity;
            }
            ViewData["Total"] = total;

            return View(assets);
        }
        [HttpGet]
        [Route("Asset/Info/{id:int}")]
        public IActionResult Details(int id)
        {
            Stocks asset = null;
            foreach(var s in assets)
            {
                if(s.Id == id)
                {
                    asset = s;
                    break;
                }
            }
            return View(asset);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Stocks asset = null;
            double total = 0;
            foreach (var s in assets)
            {
                if (s.Id == id)
                {
                    asset = s;
                    break;
                }
            }
            if (asset != null)
            {
                assets.Remove(asset);
            }

            TempData["Success"] = "Successfully Deleted..";
            return RedirectToAction("Index");
        }
    }
}
