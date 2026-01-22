using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Day_15_Exercises
{
    internal class Height
    {
        public int Feet { get; set; }

        public decimal Inches { get; set; }

        public Height()
        {
            Feet = 0;
            Inches = 0.0m;
        }

        public Height(int Feet, decimal Inches)
        {
            this.Feet = Feet;
            this.Inches = Inches;
        }

        public Height AddHeights(Height h2)
        {
            int h =Feet + h2.Feet;
            decimal i= Inches + h2.Inches;

            if (i >= 12)
            {
                h += (int)i / 12;
                i = i % 12;
            }
            Height h3 = new Height(h, i);

            h3.Feet = h;
            h3.Inches = i;
            return h3;

        }


        public override string ToString()
        {
            return $"Height - {Feet} feets {Inches:f1} inches";
        }
    }

    internal class Program 
    {
        static void Main(string[] args)
        {
            Height h = new Height(6, 11.9m);
            Height h2 = new Height(9, 3);
            Console.WriteLine(h);
            Console.WriteLine(h2);
            h.AddHeights(h2);

            Height h3 = new Height();
            h3 = h.AddHeights(h2);
            Console.WriteLine(h3);
        }

    }

}
