using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Sys
{
    internal class Exp7_GradingEngine
    {
        static void Main(string[] args)
        {
            double finalScore = 87.6;

            if (finalScore < 0 || finalScore > 100)
            {
                Console.WriteLine("Invalid Score");
                return;
            }

            int roundedScore =
                (int)Math.Round(finalScore, MidpointRounding.AwayFromZero);

            byte grade;

            if (roundedScore >= 90)
                grade = 10;
            else if (roundedScore >= 80)
                grade = 9;
            else if (roundedScore >= 70)
                grade = 8;
            else if (roundedScore >= 60)
                grade = 7;
            else
                grade = 5;

            Console.WriteLine("Final Score: " + roundedScore);
            Console.WriteLine("Grade Code: " + grade);
        }
    }
}

// Final score is calculated as double to allow decimal values.
// Score is validated to ensure it lies between 0 and 100.
// Rounding is applied before converting to grade.
// Grade is stored as byte since it uses small numeric values.
