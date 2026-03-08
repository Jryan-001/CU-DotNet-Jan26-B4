using System.Threading.Channels;

namespace University_Sys
{
    internal class Exp1_Attendancecalculator
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the no. of classes Attended:");
            int attendance_num=int.Parse(Console.ReadLine());
            Console.Write("Enter the no. of total classes:");
            int total_attendance = int.Parse(Console.ReadLine());
            double percentage = (double)attendance_num / total_attendance * 100;
            int output = (int)Math.Round(percentage, MidpointRounding.AwayFromZero);
            Console.Write("Eligibility Pecentage: "+output);
        }
    }
}
// Rounding gives a more correct eligibility percentage, while truncation always lowers
// the value and can affect student eligibility.

// Truncation removes the decimal part and always reduces the percentage.

// This may wrongly affect eligibility near the cutoff.
// Rounding gives a fair and more accurate result.
