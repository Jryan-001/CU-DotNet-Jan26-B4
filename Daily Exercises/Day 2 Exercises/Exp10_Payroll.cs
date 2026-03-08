using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Sys
{
    internal class Exp10_Payroll
    {
        static void Main(string[] args)
        {
            int basicSalary = 50000;

            double allowances = 12450.75;
            double deductions = 3250.25;

            decimal basicDec = basicSalary;
            decimal allowanceDec = (decimal)allowances;
            decimal deductionDec = (decimal)deductions;

            decimal netSalary =
                basicDec + allowanceDec - deductionDec;

            Console.WriteLine("Net Salary: " + netSalary);
        }
    }
}

// Basic salary is stored as int since it is a fixed whole amount.
// Allowances and deductions are stored as double with fractional values.

// All values are converted to decimal for payroll calculation.



// Decimal ensures accuracy and avoids floating point errors.
