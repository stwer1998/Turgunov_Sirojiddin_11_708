using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex12
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Козла пустили в квадратный огород и привязали к колышку. Колышек воткнули точно в центре огорода.
            Козёл голоден, как волк, прожорлив, как бык, и ест всё, до чего дотянется, не перелезая через забор
            и не разрывая веревку. Какая площадь огорода будет объедена?
            a=сторона квадрата, b=площадь занетая r=радиусб c=угол f=площадь сектора e*/
            Console.WriteLine("в ведите длину стороны огорода");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("в ведите длину верёвки");
            int r=Convert.ToInt32(Console.ReadLine());
            

            double b;

            if ((r >= (a / 2)) && (r < ((Math.Sqrt((a * a) + (a * a))) / 2)))
            {
                double c = 90 - 2*(Math.Acos(a / (2 * r))) * 180 / Math.PI;  
                double f = (Math.PI * r * r )* (c / 360);  
                double e = Math.Sqrt((r * r) - ((a * a) / 4));
                double s = e * (a / 2);  
                b = 4 * (f + (s));
                
            }
            else if (r >= Math.Sqrt(2 * (a / 2) * (a / 2))) b = a * a;
            else b = Math.PI * r * r;


            Console.WriteLine(Math.Abs(Math.Round(b, 3)));
            Console.Read();
            
        }
    }
}
