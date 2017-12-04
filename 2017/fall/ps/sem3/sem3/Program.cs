using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem3
{
    class Program
    {
	// ---check--- что-то не то ваш алгоритм делает
        static void Main(string[] args)
        {
            //Проверить, делится ли число в двоичной системе счисления на десятичное натуральное число k нацело
            Console.WriteLine("Это программа Проверяет, делится ли число в " +
                "двоичной системе счисления на десятичное натуральное число k нацело");
            Console.WriteLine("В ведите число в десятичном виде");
            int a = Convert.ToInt32(Console.ReadLine()), res = 0, step = 1;
            while (a != 0)
            {
                res += step * (a % 10);
                step *= 2;
                a /= 10;
            }
            Console.WriteLine(res);
            Console.WriteLine("В ведите делитель");
            int k = Convert.ToInt32(Console.ReadLine());
            if (res % k == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
		// ---check--- как так и тут и тут YES?
                Console.WriteLine("NO");
            }
            Console.ReadKey();
        }
    }
}
