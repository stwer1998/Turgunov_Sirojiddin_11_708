using System;

namespace ex6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Это программа посчитает расстояние от точки до прямой, заданной двумя разными точками.");
            Console.WriteLine("В ведите x1 для прямой");
            int x1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("В ведите Y1 для прямой");
            int y1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("В ведите X2 для прямой");
            int x2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("В ведите Y2 для прямой");
            int y2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("В ведите x для точки");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("В ведите Y для точки");
            int y = Convert.ToInt32(Console.ReadLine());
            Double d = ((Math.Abs((y2 - y1) * x - (x2 - x1) * y + (x2 * y1) - (y2 * x1))));
            double result=(d/ (Math.Sqrt((Math.Pow((y2 - y1), 2)) + (Math.Pow((x2 - x1), 2)))));
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
