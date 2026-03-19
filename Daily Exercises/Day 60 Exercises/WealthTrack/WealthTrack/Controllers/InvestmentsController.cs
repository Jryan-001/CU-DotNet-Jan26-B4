using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WealthTrack.Data;
using WealthTrack.Models;
using WealthTrack.ViewModel;

namespace WealthTrack.Controllers
{
    public class InvestmentsController : Controller
    {
        private readonly WealthTrackContext _context;

        public InvestmentsController(WealthTrackContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Investment.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InvestmentCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var model = new Investment
                {
                    TickerSymbol = vm.TickerSymbol,
                    AssetName = vm.AssetName, // Defaulting to ticker as AssetName isn't in VM
                    PurchasePrice = vm.Price,
                    Quantity = vm.Quantity,
                    PurchaseDate = DateTime.Now
                };
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }
    }
}
