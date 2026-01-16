namespace WeeklySaleS
{
    internal class SaleS
    {
        static void ReadWeeklySales(decimal[] dailySales)
        {
            int dayIndex = 0;
            while (dayIndex < 7)
            {
                Console.Write($"Day {dayIndex + 1} = ");
                dailySales[dayIndex] = decimal.Parse(Console.ReadLine());
                if (dailySales[dayIndex] < 0)
                {
                    Console.WriteLine("Negative Value not Permitted");
                    continue;
                }
                dayIndex++;
            }
        }

        static decimal CalculateTotal(decimal[] dailySales)
        {
            decimal sum = 0;
            foreach (decimal sale in dailySales)
            {
                sum += sale;
            }
            return sum;
        }

        static decimal CalculateAverage(decimal totalAmount, int numberOfDays)
        {
            return totalAmount / numberOfDays;
        }

        static decimal FindHighestSale(decimal[] dailySales, out int dayNumber)
        {
            decimal maxSale = dailySales[0];
            dayNumber = 0;
            for (int i = 1; i < dailySales.Length; i++)
            {
                if (dailySales[i] > maxSale)
                {
                    maxSale = dailySales[i];
                    dayNumber = i;
                }
            }
            return maxSale;
        }

        static decimal FindLowestSale(decimal[] dailySales, out int dayNumber)
        {
            decimal minSale = dailySales[0];
            dayNumber = 0;
            for (int i = 1; i < dailySales.Length; i++)
            {
                if (dailySales[i] < minSale)
                {
                    minSale = dailySales[i];
                    dayNumber = i;
                }
            }
            return minSale;
        }

        static decimal CalculateDiscount(decimal totalAmount)
        {
            decimal discountRate = (totalAmount >= 50000) ? 10m : 5m;
            return (discountRate / 100m) * totalAmount;
        }

        static decimal CalculateDiscount(decimal totalAmount, bool isFestivalWeek)
        {
            decimal discountRate = (totalAmount >= 50000) ? 15m : 10m;
            return (discountRate / 100m) * totalAmount;
        }

        static decimal CalculateTax(decimal amountAfterDiscount)
        {
            decimal taxRate = 18m;
            return (taxRate / 100m) * amountAfterDiscount;
        }

        static decimal CalculateFinalAmount(decimal totalAmount, decimal discountAmount, decimal taxAmount)
        {
            return totalAmount - discountAmount - taxAmount;
        }

        static void GenerateSalesCategory(decimal[] dailySales, string[] categoryList)
        {
            for (int i = 0; i < dailySales.Length; i++)
            {
                if (dailySales[i] < 5000)
                    categoryList[i] = "Low";
                else if (dailySales[i] > 15000)
                    categoryList[i] = "High";
                else
                    categoryList[i] = "Medium";
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Daily Sales Value");
            decimal[] dailySales = new decimal[7];

            ReadWeeklySales(dailySales);

            decimal totalAmount = CalculateTotal(dailySales);
            decimal averageAmount = CalculateAverage(totalAmount, dailySales.Length);

            int highDay;
            int lowDay;
            decimal highestSale = FindHighestSale(dailySales, out highDay);
            decimal lowestSale = FindLowestSale(dailySales, out lowDay);

            bool isFestivalWeek = true;
            decimal discountAmount;
            if (isFestivalWeek)
                discountAmount = CalculateDiscount(totalAmount, isFestivalWeek);
            else
                discountAmount = CalculateDiscount(totalAmount);

            decimal taxAmount = CalculateTax(totalAmount - discountAmount);
            decimal finalPayable = CalculateFinalAmount(totalAmount, discountAmount, taxAmount);

            string[] salesCategory = new string[7];
            GenerateSalesCategory(dailySales, salesCategory);

            Console.WriteLine("\nWeekly Sales Summary");
            Console.WriteLine($"Total Sales            : {totalAmount}");
            Console.WriteLine($"Average Sales          : {averageAmount}");
            Console.WriteLine($"\nHighest Sales          : {highestSale:F2} (Day {highDay})");
            Console.WriteLine($"Total Sales            : {lowestSale} (Day {lowDay})");
            Console.WriteLine($"\nDiscount Applied       : {discountAmount}");
            Console.WriteLine($"Tax Amount             : {taxAmount}");
            Console.WriteLine($"Final Amount           : {finalPayable}");

            Console.WriteLine("\nDay-Wise Category");
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"Day {i + 1} = {salesCategory[i]}");
            }
        }
    }
}
