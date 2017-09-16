using System;


namespace ex8
{
    class MainClass
        {
            private static string[] coef; //array of coefficients (a, b, c)
            private static double x0, y0; // A(x0;y0)
            private const double EPSILON = 1e-9;

            static void Main()
            {
                while (true)
                {
                    ReadData();
                    if (FindIntersection())
                    {
                        break;
                    }
                }
            Console.ReadKey();

            }

            private static void ReadData()
            {
                Console.WriteLine("Enter coefficients (ax + by + c = 0): ");
                Char separator = ' ';
                coef = Console.ReadLine().Split(separator);
                Console.WriteLine("Enter x0 and y0 coordinates of A: ");
                string[] coordinates = Console.ReadLine().Split(separator);
                x0 = double.Parse(coordinates[0]);
                y0 = double.Parse(coordinates[1]);
            }

            private static Boolean FindIntersection()
            {
                /* Solving equation:
                 * ax + by + c = 0 - given line 
                 * bx - ay - bx0 + ay0 = 0 - perpendicular line 
                 * (x; y) - intersection point
                */

                double x, y;
                double a = double.Parse(coef[0]);
                double b = double.Parse(coef[1]);
                double c = double.Parse(coef[2]);

                if (Math.Abs(a) < EPSILON && Math.Abs(b) < EPSILON)
                {
                    Console.WriteLine("Wrong coefficients!");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    return false;
                }
                else if (Math.Abs(a) > EPSILON && Math.Abs(b) < EPSILON)
                {
                    Console.WriteLine($"Intersection point: ({-c / a};{y0})");
                    return true;
                }
                else if (Math.Abs(a) < EPSILON && Math.Abs(b) > EPSILON)
                {
                    Console.WriteLine($"Intersection point: ({x0};{-c / b})");
                    return true;
                }
                else
                {
                    y = (a * a * y0 - a * b * x0 - b * c) / (a * a + b * b);
                    x = -(b * y + c) / a;
                    Console.WriteLine($"Intersection point: ({x};{y})");
                    return true;
                }
            }
        
    }

}

