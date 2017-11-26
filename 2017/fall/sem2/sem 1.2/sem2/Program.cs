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
            Console.WriteLine("Это программа вычисляет (-x) степень числа e c заданной точностью");
            Console.WriteLine("В ведите точность:");
            double e = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("В ведите  X");
            int x = Convert.ToInt32(Console.ReadLine());
            var result = FindResult(e, x);
            Console.WriteLine("резултат алгоритма:"+result);
        }
        public static double FindResult(double e, int x)
        {
            double b = 0;
            int step = 0;
            double oldB = 0;
            for (int k = 0; true; k++)
            {
                step++;
                oldB = b;
                int c = Factorial(2*k);
                b += ((2 * k * x )+ 1) / ((Math.Pow(x, 2 * k) )*c);
                if (Math.Abs(b - oldB) < e) break;//проверяем точность

            }
            Console.WriteLine("Шаг номер:"+step);
            return b;
        }
        public static int Factorial(int k)
        {
            int a = 1;
            for (int i = 1; i < k + 1;i++)
            {
                a = a * i;
            }
            return a;
        }
    }
}
