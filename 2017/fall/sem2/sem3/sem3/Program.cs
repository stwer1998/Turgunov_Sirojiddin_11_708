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
            Console.WriteLine("Это программа вычисляет приблизительное значение интеграла");
            Console.WriteLine("Формула по умолчанию sin(tan(x))dx  c 0 до 1,2");
            Console.WriteLine("По формуле левых прямоугольников:  " + MethodLeftSquare(0, 1.2,1000000));
            Console.WriteLine("По формуле правых прямоугольников: " + MethodRightSquare(0,1.2));
            Console.WriteLine("По формуле трапецийж               " + MethodTrapezee(0, 1.2));
            Console.WriteLine("По формуле Симпсона:               " + MethodSypson(0,1.2));//может отрезок измениться
            Console.WriteLine("По формуле Монте-Карло:            " + MethodMonteCarlo(0,1.2));//из-за этого ма сами зададим отрезок
            // в задание  непонятно итиратции с консоля введется или мы сами это неизвестно
            // это программа назначена для 1000000 итираций
        }
        public static double Formula(double i)//если интеграл изменится мы только изменим только эту часть 
        {
            return (Math.Sin(Math.Tan(i)));
        }
        public static double MethodLeftSquare(double a,double b,int n)
        {
            double result = 0;
            for (double i = a; i <= b; i += (a+b)/n)
            {
                double sum = (Formula(i)) * ((a+b)/n);//Формула с википедии
                result = result + sum;
            }
           
            return result;
        }
        public static double MethodRightSquare(double a, double b)
        {
            double result = 0;
            for (double i = a; i <= b; i += 0.000001)
            {
                double sum = (Formula(i + 0.000001)) * (0.000001);//Формула с википедии
                result = result + sum;
            }
            return result;
        }
        public static double MethodTrapezee(double a, double b)
        {
            double result = 0;
            for (double i = a; i <= b; i += 0.000001)
            {
                double sum =((Formula(i)) + (Formula(i + 0.000001))) * (0.000001) / 2;//Формула с википедии
                result = result + sum;
            }
            return result;
        }
        public static double MethodSypson(double a,double b)
        {
            double result = (1.2 / 6) * ((Math.Sin(Math.Tan(0))) + 4 * (Math.Sin(Math.Tan(0.6))) + (Math.Sin(Math.Tan(1.2))));
            return result;//Формула с википедии
        }
        public static double MethodMonteCarlo(double a, double b)
        {
            double result = 0;
            double sum = 0;
            for (double i = a; i <= b; i += 0.0000012)
            {
                sum += (Formula(i));//Формула с википедии
            }
            result = 1.2 * (sum / 1000000);
            return result;
        }
    }
}
