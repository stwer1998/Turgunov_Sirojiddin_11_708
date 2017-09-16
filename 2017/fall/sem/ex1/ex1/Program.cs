using System;


namespace ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите числo");

            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());

            b = b - a;
            a = a + b;
            b = a - b;

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.ReadKey();




        }
    }
}
