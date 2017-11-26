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
            Console.WriteLine("Это программа вычисляет число ПИ через биномиальный коэфицент с задоной точностью");
            Console.WriteLine("Введите точность");
            double e = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(FindPi(e));
        }
        public static double FindPi (double e)
        {
            double result = 0;
            int k = 0;
            double sum = 0;
            double oldSum = 100500;
            while(Math.Abs(oldSum-sum)>e)//проверяем точность
            {
                result = (50 * k - 6) / ((1 << k) * Factorial(k));
                oldSum = sum;
                sum = sum + result;               
                k++;                
            }
            return sum;
        }
        public static double Factorial(int k)//вычислим Факториал
        {
            double a = 1;
            for (int i = 1; i < k + 1; i++)
            {
                a = (a * (2 * k + i)) / i;
            }
            return a;
        }
        
    }
}
