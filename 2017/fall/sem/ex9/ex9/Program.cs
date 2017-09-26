using System;


namespace ex9
{
    class Program
    {
        static void Main(string[] args)
        {
            //Найти сумму всех положительных чисел меньше 1000 кратных 3 или 5
            Console.WriteLine("это программа Найдет сумму всех положительных чисел от 0 до любой цифры" +
                " кратных 3 или 5");
            Console.WriteLine("в ведите начало и конец отрезка");
            int a = Convert.ToInt32(Console.ReadLine());
            double b = ((a-1) / 3);
            double c = ((3+(3*b))/2)*b;
            double d = ((a-1) / 5);
            double e = ((5 + (5 * d)) / 2) * d;
            double f = (a-1) / 15;
            double g = ((15 + (15 * f)) / 2) * f;
            double s = (c + e) - g;
            Console.WriteLine(s);
            Console.ReadKey();
        }
    }
}
