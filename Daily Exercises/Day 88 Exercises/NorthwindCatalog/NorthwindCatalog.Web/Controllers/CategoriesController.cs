using Microsoft.AspNetCore.Mvc;
using NorthwindCatalog.Services.Dtos;

namespace NorthwindCatalog.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly HttpClient _client;
        public CategoriesController(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("NorthwindApi");
        }
        public async Task<IActionResult> Index()
        {
            var data = await _client.GetFromJsonAsync<List<CategoryDto>>("api/categories");
            return View(data);
        }
    }
}
