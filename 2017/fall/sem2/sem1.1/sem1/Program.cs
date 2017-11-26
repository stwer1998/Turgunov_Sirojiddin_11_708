using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Это  программа вычисляет константу Эйлер-Маскерони с задонной точностью " 
            + "Постоянная Эйлера — Маскерони или постоянная Эйлера — математическая константа, "
            + "определяемая как предел разности между частичной суммой гармонического ряда и натуральным логарифмом числа:");
            Console.WriteLine("Введите точность e: ");
            double e = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите число N Чем больше число тем точнее будет константа");
            int n = Convert.ToInt32(Console.ReadLine());
            double result = FindConstant(e, n);
            Console.WriteLine(result);
        }
        public static double FindConstant(double e, int n)
        {
            double result = 0;
            int k = 1;
            double h= 0;
            double oldH =0;
            do
            {
                oldH = h;
                h += 1.0 / k;
                k++;
            } while (Math.Abs(oldH - h) > e);//проверяем точность
            Console.WriteLine("Шаг номер:  "+(k-1));
            result = h - (Math.Log(n));//В википедие формула такая 
            return result;
        }
    }
}
