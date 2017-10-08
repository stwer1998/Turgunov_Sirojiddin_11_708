using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Возвести вещественное число n в целую степень k
            //(используя алгоритм быстрого возведения в степень – бинарный/справа налево)
            Console.WriteLine("Введите число и степень");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int result = 1;
            while (b != 0)
                if (b % 2 == 1)
                {
                    result *= a;
                    --b;
                }
                else
                {
                    a *= a;
                    b = b / 2;
                }
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
