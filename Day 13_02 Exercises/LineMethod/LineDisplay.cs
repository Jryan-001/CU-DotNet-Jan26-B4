using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemO
{
    internal class LineDisplay
    {
        //static void display()
        //{
        //    Console.WriteLine($"\nPrint in line: '-' ");
        //    for (int i = 0; i < 40; i++)
        //    {
        //        Console.Write('-');
        //    }
        //}
        //static void display(char disp)
        //{
        //    Console.WriteLine($"\nPrint in line: '{disp}' ");
        //    for (int i = 0; i < 40; i++)
        //    {
        //        Console.Write(disp);
        //    }
        //}
        //static void display(char disp, int f)
        //{
        //    Console.WriteLine($"\nPrint in line: '{disp}' ");
        //    for (int i = 0; i < f; i++)
        //    {
        //        Console.Write(disp);
        //    }
        //}

        static void display(char disp = '-', int f = 40)
        {
            Console.WriteLine($"\nPrint in line:{disp}");
            for (int i = 0; i < f; i++)
            {
                Console.Write(disp);
            }
        }

        static void InParameterMethod(in int f) 
        {
         //   f++; // read only
        }



        //static void display(char disp = '-', int f = 40, double d = 10.00, int a=4, char val='r')
        //{
        //    Console.WriteLine($"\nPrint in line:{disp}");
        //    for (int i = 0; i < f; i++)
        //    {
        //        Console.Write($"{disp} {f} {d} {a} {val}");
        //    }
        //}
        static void Main(string[] args)
        {
            int a = 10;
            InParameterMethod(a);
            //multiple options to call the method
            display(); //don't pass anything as arguement
            display('+');  //pass a character like +

            display(f: 60);  //if the pattern of arguements is char then num like [display(char disp , int f )]
                           //then if we want to change the int value from 40 to 60 or something then i must pass
                           //the named arguement like the name of variable then use " : " as used here 
                           // it will define that we mean the int value not the string or char its called named arguement pass
            display('$', 61);  //pass character $ and a number like 60  //print the $ - 60 times
        }
    }
}
