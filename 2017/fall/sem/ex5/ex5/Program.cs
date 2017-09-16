using System;

namespace ex5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("это программа находит количество високосных лет на отрезке [a, b]");
            Console.WriteLine("В ведите начало отрезка");
            int a = Convert.ToInt32(Console.ReadLine()),c = 0, e = 0, f = 0, g = 0;
            Console.WriteLine("В ведите конец отрезка");
            int b = Convert.ToInt32(Console.ReadLine()),h = 0, m = 0, n = 0, s = 0;
            c = b / 4;
            e = a / 4;
            f = b / 100;
            g = ((c-e)-f);
            h = b / 400;
            m = a / 400;
            n = h + m;
            s = (n + g);
            Console.WriteLine(s);
            Console.ReadKey();
        }
    }
}
