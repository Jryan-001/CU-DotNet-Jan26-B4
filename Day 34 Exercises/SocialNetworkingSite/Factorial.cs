using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkingSite
{
    
    internal class Factorial
    {
        //public static int Factt(int n, int depth)
        public static int Factt(int n)
        {
            //Console.WriteLine(n);
            //string indent = new string(' ', depth * 2);
            int d = 5;
            Console.WriteLine(new string(' ', d-n)+ n);
            //Console.WriteLine(indent + n);
            //Console.WriteLine();
            if (n == 1)
            {
                return 1;
            }
            //int r = n * Factt(n - 1, depth+1);
            int r = n * Factt(n - 1);
            //Console.WriteLine(indent + r);
            Console.WriteLine(new string(' ', d-n)+ r);
            //Console.WriteLine(n*r);
            return r;
        }
        static void Main(string[] args)
        {
            //int n = 10;
            //Factt(5, 0);
            Factt(5);
            
        }
    }
}
