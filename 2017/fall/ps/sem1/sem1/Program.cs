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
            //По вещественным координатам треугольника(шесть чисел) найти площадь этого треугольника
            Console.WriteLine("В ведите кординат 1-й точки с перва x потом y");
            int x1 = Convert.ToInt32(Console.ReadLine());
            int y1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("В ведите кординат 2-й точки с перва x потом y ");
            int x2 = Convert.ToInt32(Console.ReadLine());
            int y2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("В ведите кординат 3-й точки с перва x потом y");
            int x3 = Convert.ToInt32(Console.ReadLine());
            int y3 = Convert.ToInt32(Console.ReadLine());
            double a = Math.Sqrt(Math.Pow((x2 - x1),2) + Math.Pow((y2 - y1),2));//находим отрезок1
            double b = Math.Sqrt(Math.Pow((x3 - x1),2) + Math.Pow((y3 - y1),2));//находим отрезок2
            double  c = Math.Sqrt(Math.Pow((x2 - x3),2) + Math.Pow((y2 - y3),2));//находим отрезок3
            double p = (a + b + c) / 2;//находим полупириметр
            double result = Math.Sqrt(p * (p - a) * (p - b) * (p - c));//находим площадь по формуле Герона
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
