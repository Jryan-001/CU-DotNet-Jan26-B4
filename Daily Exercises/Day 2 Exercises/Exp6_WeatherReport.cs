using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Sys
{
    internal class Exp6_WeatherReport
    {
        static void Main(string[] args)
        {
            short sensorReading = 325; // 32.5°C

            double temperatureCelsius =
                sensorReading / 10.0;

            double[] readings = { 32.5, 33.1, 31.8 };

            double average =
                readings.Average();

            int displayTemp =
                (int)Math.Round(average, MidpointRounding.AwayFromZero);

            Console.WriteLine("Average Temperature: " + displayTemp + " C");
        }
    }
}

// Sensor readings are stored as short to save memory.
// Values are converted to double for accurate temperature calculation.
// Daily average is calculated using double.

// Rounding is used while converting to int for dashboard display.


// Conversion to double avoids overflow during calculation.

