using GlobalMartMVCDI.Models;
using GlobalMartMVCDI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GlobalMartMVCDI.Controllers
{
    public class ProductsController : Controller
    {
        private IPricingService _pricingService { get; set; }

        public ProductsController(IPricingService pricingService)
        {
            _pricingService = pricingService;
        }

        private static List<Product> _products = new List<Product>()
        {
            new Product(){ ProductId=1, ProductName="Laptop", Price=50000 },
            new Product(){ ProductId=2, ProductName="Mobile", Price=20000 },
            new Product(){ ProductId=3, ProductName="Tablet", Price=30000 },
            new Product(){ ProductId=4, ProductName="SmartWatch", Price=15000 },
            new Product(){ ProductId=5, ProductName="Headphones", Price=8000 },
            new Product(){ ProductId=6, ProductName="Camera", Price=45000 },
        };
        public IActionResult Index()
        {
            return View(_products);
        }
        public IActionResult Details(int id)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == id);
            if (product == null) return NotFound();
            return View(product);
        }

    }
}
