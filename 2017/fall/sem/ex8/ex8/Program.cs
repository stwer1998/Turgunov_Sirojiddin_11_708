using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex8
{
    class Program
    {
        static void Main(string[] args)
        {
           
            {

                Console.WriteLine("Это программа Если Дана прямая L и точка A. Наxoдит переесечения прямой" +
                    " L с перпендикулярной ей прямой P, проходящей через точку A.");
                Console.WriteLine("Введите a,b,c");

                double a= Convert.ToDouble(Console.ReadLine());
                double b= Convert.ToDouble(Console.ReadLine());
                double c= Convert.ToDouble(Console.ReadLine());

                
                Console.WriteLine("Введите координаты точки");

                double x= Convert.ToDouble(Console.ReadLine());
                double y= Convert.ToDouble(Console.ReadLine());

                if (a== 0 && b== 0)
                {
                    Console.WriteLine("#Коэффициенты уравнения а и b не могут быть равны нулю одновременно");
                }
                else if (b== 0)
                {
                    Console.WriteLine("RESULT: (" + -c/ a+ ", " + y+ ")");
                }
                else if (a== 0)
                {
                    Console.WriteLine("RESULT: (" + x+ ", " + -c/ b+ ")");
                }
                else
                {
                    double y1 = (a * a * y - a * b * x - b * c / (a * a + b * b));
                    double x1 = -(b * y + c / a);
                    Console.WriteLine("Нашел: (" + x1+ ", " + y1+ ")");
                    
                }

                    Console.ReadKey();



            } 
        }
    }
}
