namespace WeeklyReport
{
    internal class SalesReport
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Daily sales (It must be Greater then or equal to Zero)");
            decimal[] sales = new decimal[7];
            for (int i = 0; i < 7; i++)
            {
                Console.Write($"Day {i + 1} = ");
                sales[i] = decimal.Parse(Console.ReadLine());
            }

            
            decimal totalSales = 0;
            for (int i = 0; i < 7; i++)
            {
                totalSales += sales[i];
            }

            decimal averageSales = totalSales / 7;
            decimal highest = 0;
            decimal lowest = decimal.MaxValue;
            int aboveAverage = 0;

            for (int i = 0; i < 7; i++)
            {
                highest = Math.Max(highest, sales[i]);
                lowest = Math.Min(lowest, sales[i]);
                if (sales[i] > averageSales) aboveAverage++;
            }

            string[] category = new string[7];
            for (int i = 0; i < 7; i++)
            {
                if (sales[i] < 5000) category[i] = "Low";
                else if (sales[i] > 15000) category[i] = "High";
                else category[i] = "Medium";
            }

            
            Console.WriteLine($"Total Sales           : {totalSales,-10}");
            Console.WriteLine($"Average Daily Sale    : {averageSales,-10}");
            Console.WriteLine($"Highest Sales         : {highest,-10}");
            Console.WriteLine($"Lowest Sales          : {lowest,-10}");
            Console.WriteLine($"Day Above Average     : {aboveAverage,-10}");
            Console.WriteLine("\nDay wise sales Category Summary");

            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"Day {i + 1} : {category[i]}");
            }
        }
    }
}
