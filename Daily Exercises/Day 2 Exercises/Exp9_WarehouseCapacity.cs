using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Sys
{
    internal class Exp9_WarehouseCapacity
    {
        static void Main(string[] args)
        {
            int itemCount = 450;
            ushort maxCapacity = 500;

            // convert unsigned to signed for comparison
            int capacity = maxCapacity;

            if (itemCount > capacity)
            {
                Console.WriteLine("Capacity Exceeded");
            }
            else
            {
                Console.WriteLine("Inventory Within Limit");
            }

            Console.WriteLine("Items Stored: " + itemCount);
            Console.WriteLine("Maximum Capacity: " + capacity);
        }
    }
}

// Item count is stored as int for flexibility.
// Maximum capacity is stored as ushort to avoid negative values.
// Capacity is converted to int before comparison.

// This prevents signed and unsigned conversion issues.

// Item count is signed int, while capacity is unsigned ushort.
// Direct comparison can cause logical errors.

