using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Sys
{
    internal class Exp4_BankingInterest
    {
        static void Main(string[] args)
        {
            decimal accountBalance = 100000m;

            Console.Write("Enter annual interest rate: ");
            float interestRate = float.Parse(Console.ReadLine());

            // explicit conversion from float to decimal
            decimal rateDecimal = (decimal)interestRate;

            decimal monthlyInterest =
                accountBalance * rateDecimal / 100 / 12;

            accountBalance = accountBalance + monthlyInterest;

            Console.WriteLine("Updated Balance: " + accountBalance);
        }
    }
}

// Float cannot be implicitly converted to decimal due to precision difference
// so explicit casting is required for correct interest calculation.


// Explicit casting ensures safe and accurate calculation.


