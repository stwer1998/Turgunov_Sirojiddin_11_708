using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem6
{
    class Program
    {
	// ---check--- есть вариант намного проще  (A % 10)^[(B - 1) % 4 + 1] } % 10
        static void Main(string[] args)
        {
            //Найти последнюю цифру A^B (1<=A,B<=10000)
            Console.WriteLine("Это программа находит последнюю цифру A^B");
            Console.WriteLine("В ведите А");
            int a =Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("В ведите В");
            int b = Convert.ToInt32(Console.ReadLine());
            if (b == 0) { Console.WriteLine("1"); }// если степень 0 всегда число равен 1
            else if (b == 1) { Console.WriteLine(a%10); }// если степень 1 всегда число равен себе
            else if (a < 0 || b < 0) { Console.WriteLine("Неправилиный вывод"); }// это программа для наторальных чисел
            else if (a % 10 == 0) { Console.WriteLine(a % 10); }
            else if (a % 10 == 1) { Console.WriteLine(a % 10); }
            else if (a%10 == 2)// чтобы узнать последнюю цифру нам хватит последняя цифра
                               // я мог сделать отдельный класс но для разны цифр чередование разнае
                               //из-за этого код большой но его можно использовать для бесконечности
            {
                if (b % 4 == 0) { Console.WriteLine("6"); }
                else if ((b + 1) % 4 == 0) { Console.WriteLine("8"); }
                else if ((b - 1) % 2 == 0) { Console.WriteLine("2"); }
                else if (b %2 == 0) { Console.WriteLine("4"); }
            }
            else if (a%10 == 3)
            {
                if (b % 4 == 0) { Console.WriteLine("1"); }
                else if ((b + 1) % 4 == 0) { Console.WriteLine("7"); }
                else if ((b - 1) % 2 == 0) { Console.WriteLine("3"); }
                else if (b % 2 == 0) { Console.WriteLine("9"); }
            }
            else if (a % 10 == 4) { if (b % 2 == 1) Console.WriteLine("4"); else Console.WriteLine("6"); }
            else if (a % 10 == 5) { Console.WriteLine(a % 10); }
            else if (a % 10 == 6) { Console.WriteLine(a % 10); }
            else if (a%10 == 7)
            {
                if (b % 4 == 0) { Console.WriteLine("1"); }
                else if ((b + 1) % 4 == 0) { Console.WriteLine("3"); }
                else if ((b - 1) % 2 == 0) { Console.WriteLine("7"); }
                else if (b % 2 == 0) { Console.WriteLine("9"); }
            }
            else if (a%10 == 8)
            {
                if (b % 4 == 0) { Console.WriteLine("6"); }
                else if ((b + 1) % 4 == 0) { Console.WriteLine("2"); }
                else if ((b - 1) % 2 == 0) { Console.WriteLine("8"); }
                else if (b % 2 == 0) { Console.WriteLine("4"); }
            }
            else if (a % 10 == 9) { if (b % 2 == 1) Console.WriteLine("9"); else Console.WriteLine("1"); }
            Console.ReadKey();
        }
    }
}
