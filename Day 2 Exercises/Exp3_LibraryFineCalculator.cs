using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Sys
{
    internal class Exp3_LibraryFineCalculator
    {
        static void Main(string[] args)
        {
            decimal fine = 3.19m;
            Console.Write("Enter the no. of days overdue: ");
            int overdue_days = int.Parse(Console.ReadLine());
            decimal totalFine = fine * overdue_days;
            Console.WriteLine("Total fine need to submit: "+totalFine);
            double tf_analytics = (double)totalFine;
            Console.WriteLine("Total fine for analysis: "+tf_analytics);
            
        }
    }
}
// Decimal is used for fine calculation to maintain accuracy, and double is used for

// analysis where small precision loss does not matter.


// Int is used for days as they are whole numbers.
// Decimal is explicitly converted to double for analysis purposes.

