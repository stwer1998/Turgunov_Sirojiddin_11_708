using System;


namespace ex4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Это программа найдёт вам количество чисел меньших N, которые имеют простые делители X или Y");
            Console.WriteLine("В ведите число N");
            int a = Convert.ToInt32(Console.ReadLine()),m = 0, n = 0, k=0,s = 0;
            a = (a - 1);
            Console.WriteLine("В ведите число x");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("В ведите число y");
            int c = Convert.ToInt32(Console.ReadLine());  
            m = (a / b);
            n = (a / c);
            k = (a / (b*c));
            s = (m + (n - k));
            Console.WriteLine(s);
            Console.ReadKey();
        }
    }
}
