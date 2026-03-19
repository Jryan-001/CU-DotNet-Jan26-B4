using System.ComponentModel.DataAnnotations;

namespace TheCorporatePulsePortal.Models
{
    public class Employee
    {
        
        public int EmpId { get; set; }

        [MinLength(3)]
        [Display(Name = "Employee Name")]
        public string EmpName { get; set; }

        [MinLength(3)]
        public string Position { get; set; }

        [Range(100000, 10000000)]
        public int Salary { get; set; }
    }
}
