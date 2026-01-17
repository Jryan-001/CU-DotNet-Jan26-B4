using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Assessment
{
    internal class InsurancePremiumSummarySystem
    {
        static void Main(string[] args)
        {
            string[] policyHolderNames = new string[10];
            decimal[] annualPremiums = new decimal[10];
            Console.WriteLine("Enter Policy Holder Details:-");

            for (int i = 0; i < policyHolderNames.Length / 2; i++)
            {
                Console.Write($"Enter Policy Holder {i + 1} Name: ");
                string name = Console.ReadLine();
                if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name cannot be Empty, Enter Again.");
                    i--;
                    continue;
                }
                policyHolderNames[i] = name;
                Console.Write($"Enter Annual Premium Amount for {name}: ");
                decimal amount = decimal.Parse(Console.ReadLine());
                if (amount < 0)
                {
                    Console.WriteLine("Premium Must be greater than 0, Enter Again.");
                    i--;
                }
                annualPremiums[i] = amount;
            }


            //Calculate Total Premium Amount

            decimal totalPremium = 0;
            for (int j = 0; j < annualPremiums.Length / 2; j++)
            {
                totalPremium += annualPremiums[j];
            }


            //Calculate Average Premium Amount

            decimal averagePremium = totalPremium / 5;

            //Calculate Highest Premium , Lowest Premium Amount

            decimal highestPremium = annualPremiums[0];
            decimal lowestPremium = annualPremiums[0];
            for (int z = 1; z < annualPremiums.Length / 2; z++)
            {
                if (annualPremiums[z] > highestPremium)
                {
                    highestPremium = annualPremiums[z];
                }
                if (annualPremiums[z] < lowestPremium)
                {
                    lowestPremium = annualPremiums[z];
                }
            }

            //Display Output with Sring Operations

            Console.WriteLine("\nInsurance Premium Summary\n");
            Console.WriteLine("-----------------------------");
            Console.WriteLine($"\n{"Name", -10} {"Amount",-10} {"Category",-7}\n");
            Console.WriteLine("\n-----------------------------\n");
            for (int a = 0; a < 5; a++)
            {
                string upperName = policyHolderNames[a].ToUpper();

                string category;
                if (annualPremiums[a] < 10000)
                {
                    category = "LOW";
                }
                else if (annualPremiums[a] > 25000)
                {
                    category = "HIGH";
                }
                else
                {
                    category = "MEDIUM";
                }

                Console.WriteLine($"{policyHolderNames[a].ToUpper(),-10} {annualPremiums[a],-10} {category,-7}");
            }
            Console.WriteLine("...");
            Console.WriteLine($"\nTotal Premium  : {totalPremium:F2}");
            Console.WriteLine($"Average Premium: {averagePremium:F2}");
            Console.WriteLine($"Highest Premium: {highestPremium:F2}");
            Console.WriteLine($"Lowest Premium : {lowestPremium:F2}");

        }
    }
}
