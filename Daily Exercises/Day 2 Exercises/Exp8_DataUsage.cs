using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Sys
{
    internal class Exp8_DataUsage
    {
        static void Main(string[] args)
        {
            long usageBytes = 5368709120;

            double usageMB =
                usageBytes / (1024.0 * 1024.0);

            double usageGB =
                usageBytes / (1024.0 * 1024.0 * 1024.0);

            int roundedGB =
                (int)Math.Round(usageGB, MidpointRounding.AwayFromZero);

            Console.WriteLine("Usage in MB: " + usageMB);
            Console.WriteLine("Usage in GB: " + usageGB);
            Console.WriteLine("Monthly Usage (GB): " + roundedGB);
        }
    }
}

// Data usage is stored as long because byte values can be very large.
// Values are converted to double for MB and GB calculations.
// Double allows easy unit conversion.
// Rounding is used to display a clear monthly summary.
