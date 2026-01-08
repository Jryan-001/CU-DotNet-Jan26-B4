using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Sys
{
    internal class exp2_ResultProcessing
    {
        static void Main(string[] args)
        {
            int []sub_marks = [25, 27, 29, 27, 26];
            double average_marks = (double) sub_marks.Sum() / sub_marks.Length;
            Console.WriteLine("Average marks: "+average_marks);
            int scholarship_eligibility0= (int)average_marks;
            Console.WriteLine("scholarship_eligibility after truncating: "+ scholarship_eligibility0);
            int scholarship_eligibility = (int)Math.Round(average_marks, MidpointRounding.AwayFromZero);
            Console.WriteLine("scholarship_eligibility after round-off: " + scholarship_eligibility);
        }
    }
}
// When converting double to int, the decimal part is lost.

// Using rounding gives a fair result compared to truncation.

// Marks are stored as int and converted to double for average calculation.
// Precision loss occurs when converting double to int.

// Rounding is used to reduce unfair loss of marks.

