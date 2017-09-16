using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Какой час???");
            int a = Convert.ToInt32(Console.ReadLine()),b = 0, d = 0;
            if (a < 12) 
             b = a * 30;
           else 
            b = ((a - 12) * 30); 
            if (b > 180)
             b = 360 - b;
            Console.WriteLine(b);
            Console.ReadKey();
        }
    }
}
