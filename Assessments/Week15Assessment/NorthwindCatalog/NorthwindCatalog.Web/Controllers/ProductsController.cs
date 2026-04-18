using Microsoft.AspNetCore.Mvc;
using NorthwindCatalog.Services.Dtos;

namespace NorthwindCatalog.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly HttpClient _client;
        public ProductsController(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("NorthwindApi");
        }
        public async Task<IActionResult> ByCategory(int id)
        {
            var products = await _client.GetFromJsonAsync<List<ProductDto>>($"api/products/by-category/{id}");
            return View(products);
        }
        public async Task<IActionResult> Summary()
        {
            var summary = await _client.GetFromJsonAsync<List<CategorySummaryDto>>("api/products/summary");
            return View(summary);
        }
    }
}