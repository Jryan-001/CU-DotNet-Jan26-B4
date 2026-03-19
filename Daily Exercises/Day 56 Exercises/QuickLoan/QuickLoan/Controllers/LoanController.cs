using Microsoft.AspNetCore.Mvc;
using QuickLoan.Models;
namespace QuickLoan.Controllers
{
    
    public class LoanController : Controller
    {
        private static List<Loan> data = new List<Loan>()
        {
            new Loan()
            {
                Id = 1,
                BorrowerName="Rahul",
                LenderName="Raj",
                Amount=98888,
                IsSettled=true
            },
            new Loan()
            {
                Id = 2,
                BorrowerName="Ram",
                LenderName="Jai",
                Amount=500000,
                IsSettled=false
            }
        };
        public IActionResult Index()
        {
            return View(data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add(Loan loan)
        {
            if (ModelState.IsValid)
            {
                int idMax = 0;
                foreach(var i in data)
                {
                    if(i.Id > idMax)
                    {
                        idMax = i.Id;
                    }
                }
                loan.Id= idMax + 1;
                data.Add(loan);
                return RedirectToAction("Index");
            }
            return View(loan);
        }
        

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Loan loan = null;
            foreach(var i in data)
            {
                if(i.Id == id)
                {
                    loan = i;
                    break;
                }
            }
            return View(loan);
        }


        [HttpPost]
        public IActionResult Edit(Loan loan)
        {
            foreach(var i in data)
            {
                if(i.Id == loan.Id)
                {
                    i.BorrowerName = loan.BorrowerName;
                    i.LenderName = loan.LenderName;
                    i.Amount = loan.Amount;
                    i.IsSettled = loan.IsSettled;
                    break;
                }
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            Loan loan = null;
            foreach (var i in data)
            {
                if(i.Id == id)
                {
                    loan = i;
                    break;
                }
            }
            if(loan != null)
            {
                data.Remove(loan);
            }
            return RedirectToAction("Index");
        }

    }
}
