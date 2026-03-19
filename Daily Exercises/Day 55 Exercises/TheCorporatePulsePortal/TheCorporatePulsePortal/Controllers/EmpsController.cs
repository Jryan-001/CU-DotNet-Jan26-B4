using Microsoft.AspNetCore.Mvc;
using TheCorporatePulsePortal.Models;

namespace TheCorporatePulsePortal.Controllers
{
    public class EmpsController : Controller
    {
        private static List<Employee> portals = new List<Employee>()
        {
            new Employee()
            {
                EmpId = 101,
                EmpName="Raj",
                Position="Founder",
                Salary=45000
            },
            new Employee()
            {
                EmpId = 102,
                EmpName="Rahul",
                Position="Founder",
                Salary=450000
            },
            new Employee()
            {
                EmpId = 103,
                EmpName="Sneha",
                Position="Founder",
                Salary=54000
            },
            new Employee()
            {
                EmpId = 104,
                EmpName="Jai",
                Position="CEO",
                Salary=900000
            },
            new Employee()
            {
                EmpId = 105,
                EmpName="Harpuneet",
                Position="HR",
                Salary=5000000
            }
        };
        [HttpGet]
        public IActionResult Display()
        {
            string msg = "Daily Announcement: Meeting at 4 PM.";
            ViewBag.msg = msg;

            ViewData["DepartmentName"] = "Corporate Management";
            ViewData["ServerStatus"] = true;

            return View(portals);
        }
        //[HttpGet]
        //public IActionResult ShowTable()
        //{
        //    return View(model: portals);
        //}


        public IActionResult Index()
        {
            return View();
        }
    }
}
