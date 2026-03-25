using GlobalMartMVCDI.Models;
using GlobalMartMVCDI.Models.ViewModel;
using GlobalMartMVCDI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace GlobalMartMVCDI.Controllers
{
    public class CartsController : Controller
    {
        private IPricingService _pricingService { get; set; }
        public CartsController(IPricingService pricingService)
        {
            _pricingService = pricingService;
        }
        private static List<Product> _shoppingCart = new List<Product>();
        [HttpGet]
        public IActionResult Add(string name, decimal price)
        {
            _shoppingCart.Add(new Product { ProductName = name, Price = price });
            return Ok();
        }
        [HttpGet]
        public IActionResult Checkout(string promoCode)
        {
            var groupedItems = _shoppingCart.GroupBy(p => p.ProductName).Select(group => new CartViewModel
            {
                Name = group.Key,
                Price = group.First().Price,
                Quantity = group.Count(),
                Subtotal = group.First().Price * group.Count()
            }).ToList();
            
            ViewBag.ProductName = groupedItems.Select(x => x.Name).ToList();
            decimal grandSubtotal = _shoppingCart.Sum(p => p.Price);
            if (string.IsNullOrEmpty(promoCode)) promoCode = "NONE";
            ViewBag.CartList = groupedItems;
            ViewBag.GrandSubtotal = grandSubtotal;
            ViewBag.PromoUsed = promoCode;
            ViewBag.FinalPrice = _pricingService.CalculatePrice(grandSubtotal, promoCode);
            return View();
        }
        public IActionResult Clear()
        {
            _shoppingCart.Clear();
            return RedirectToAction("Index", "Products");
        }
    }
}
