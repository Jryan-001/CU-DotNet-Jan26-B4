using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Sys
{
    internal class Exp5_EcommercePricing
    {
        static void Main(string[] args)
        {
            double cartTotal = 2499.49;

            decimal taxRate = 18m;
            decimal discountRate = 10m;

            // explicit conversion before financial calculation
            decimal cartTotalDecimal = (decimal)cartTotal;

            decimal taxAmount =
                cartTotalDecimal * taxRate / 100;

            decimal discountAmount =
                cartTotalDecimal * discountRate / 100;

            decimal finalAmount =
                cartTotalDecimal + taxAmount - discountAmount;

            Console.WriteLine("Final Payable Amount: " + finalAmount);
        }
    }
}
// Cart total is converted from double to decimal before tax calculation
// to avoid rounding errors in financial calculations.


