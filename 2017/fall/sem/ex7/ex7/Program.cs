using System;


namespace ex7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Это прогрмма Найдет вектор, параллельный прямой. Перпендикулярный прямой");
            Console.WriteLine("Введите a, b, c");

            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int c = Convert.ToInt32(Console.ReadLine());

            
            Console.WriteLine("Найден ");
            Console.WriteLine("Вектор, параллельный прямой: ({0}, {1})", a, b);

            Console.WriteLine("Вектор, перпендикулярный прямой: ({0}, {1})", 1, -1.0 * a / b);
            Console.ReadKey();


        }
    }
}
