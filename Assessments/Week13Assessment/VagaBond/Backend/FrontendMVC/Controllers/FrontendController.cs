using FrontendMVC.Models;
using FrontendMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontendMVC.Controllers
{
    public class FrontendController : Controller
    {
        private readonly IDestinationService _service;
        public FrontendController(IDestinationService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }
        public async Task<IActionResult> Details(int id)
        {
            return View(await _service.GetByIdAsync(id));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DestinationViewModel destination)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(destination);
                return RedirectToAction(nameof(Index));
            }
            return View(destination);
        }
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _service.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, DestinationViewModel destination)
        {
            if (id != destination.Id) return NotFound();
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(destination);
                return RedirectToAction(nameof(Index));
            }
            return View(destination);
        }
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _service.GetByIdAsync(id));
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
