using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Найти сумму пятизначных чисел, у которых значение равно сумме пятых степеней их цифр
            Console.WriteLine("Это программа находит сумму пятизначных чисел," +
                " у которых значение равно сумме пятых степеней их цифр");
            int sum = 0;
            for (int i = 10000; i < 100000; i++)
            {
                int num = i, a = 0;
                while (num != 0)
                {
                    a += (num % 10) * (num % 10) * (num % 10) * (num % 10) * (num % 10);
                    num /= 10;
                }
                if (i == a)
                {
                    Console.WriteLine(i + "\n");
                    sum += i;
                }
            }
            Console.WriteLine("SUM = " + sum + "\n");
            Console.ReadKey();
        }
    }
}
