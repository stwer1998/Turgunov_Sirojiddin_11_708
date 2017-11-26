using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Это программа вычисляет arctg(x) с задонной точностью");
            Console.WriteLine("Введите точность:");
            double e= Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите число X");
            double x=Convert.ToDouble(Console.ReadLine());
            double result = FindResult(e, x);
            Console.WriteLine(result);
        }
        public static double FindResult(double e,double x)
        {
            double a = 0;
            double b = 0;
            double oldB = 0;
            int k = 0;
            do
            {
                oldB = b;
                b += (k % 2 == 0 ? 1 : -1) / (((Math.Pow(x, ((2 * k) + 1)))) * ((2 * k) + 1));
                k++;
            } while ((Math.Abs(oldB - b) < e));//проверяем точность
            Console.WriteLine("Шаг номер:"+k);
            a = (((Math.PI) * (Math.Sqrt(x * x))) /( 2 * x)) - b;
            return a;
        }
    }
}
