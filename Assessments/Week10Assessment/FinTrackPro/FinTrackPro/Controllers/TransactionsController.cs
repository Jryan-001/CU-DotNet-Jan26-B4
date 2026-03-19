using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinTrackPro.Data;
using FinTrackPro.Models;

namespace FinTrackPro.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly FinTrackProContext _context;

        public TransactionsController(FinTrackProContext context)
        {
            _context = context;
        }

        // GET: Transactions/Index?accountId=5
        public async Task<IActionResult> Index(int accountId)
        {
            var transactions = await _context.Transactions
                .Where(t => t.AccountId == accountId)
                .ToListAsync();
            ViewBag.AccountId = accountId;
            return View(transactions);
        }

        // GET: Transactions/Create?accountId=5
        public IActionResult Create(int accountId)
        {
            ViewBag.AccountId = accountId;
            // Initialize all required properties
            return View(new Transaction
            {
                AccountId = accountId,
                Date = DateTime.Today,
                Description = string.Empty,
                Category = "Credit",
                Amount = 0
            });
        }

        // POST: Transactions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Transaction transaction)
        {
            var account = await _context.Account.FindAsync(transaction.AccountId);
            if (account == null)
            {
                TempData["Error"] = "Account not found.";
                return RedirectToAction("Index", "Accounts");
            }

            if (transaction.Category == "Debit")
            {
                if (account.Balance < transaction.Amount)
                {
                    TempData["Error"] = $"Not possible: Only {account.Balance:C} balance left.";
                    return RedirectToAction("Index", "Accounts");
                }
                account.Balance -= transaction.Amount;
            }
            else if (transaction.Category == "Credit")
            {
                account.Balance += transaction.Amount;
            }

            if (ModelState.IsValid)
            {
                _context.Transactions.Add(transaction);
                _context.Account.Update(account);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Transaction added successfully.";
                return RedirectToAction("Index", "Accounts");
            }

            TempData["Error"] = "Invalid transaction data.";
            return RedirectToAction("Index", "Accounts");
        }
        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            ViewBag.AccountId = transaction.AccountId;
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Transaction transaction)
        {
            if (id != transaction.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    // Update balance logic for Edit
                    var originalTransaction = await _context.Transactions.AsNoTracking().FirstOrDefaultAsync(t => t.Id == transaction.Id);
                    var account = await _context.Account.FindAsync(transaction.AccountId);
                    if (originalTransaction != null && account != null)
                    {
                        double tempBalance = account.Balance;

                        // Reverse original
                        if (originalTransaction.Category == "Debit") tempBalance += originalTransaction.Amount;
                        else if (originalTransaction.Category == "Credit") tempBalance -= originalTransaction.Amount;

                        // Apply new
                        if (transaction.Category == "Debit") tempBalance -= transaction.Amount;
                        else if (transaction.Category == "Credit") tempBalance += transaction.Amount;

                        if (tempBalance < 0)
                        {
                            ModelState.AddModelError("", $"Not possible: Only {tempBalance + transaction.Amount} balance left.");
                            ViewBag.AccountId = transaction.AccountId;
                            return View(transaction);
                        }

                        account.Balance = tempBalance;
                        _context.Account.Update(account);
                    }

                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Transactions.Any(e => e.Id == transaction.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Accounts");
            }
            ViewBag.AccountId = transaction.AccountId;
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var transaction = await _context.Transactions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }
            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            int accountId = transaction?.AccountId ?? 0;
            if (transaction != null)
            {
                var account = await _context.Account.FindAsync(transaction.AccountId);
                if (account != null)
                {
                    if (transaction.Category == "Debit")
                        account.Balance += transaction.Amount;
                    else if (transaction.Category == "Credit")
                        account.Balance -= transaction.Amount;
                    _context.Account.Update(account);
                }
                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Accounts");
        }
    }
}
