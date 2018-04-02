using System;
using System.Collections.Generic;
using System.Linq;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

           //Дана последовательность положительных целых
           //чисел.Обрабатывая только нечетные числа, получить после -
           //довательность их строковых представлений и отсортировать
           //ее в лексикографическом порядке по возрастанию
            int[] numbers = { 1, 21, 3, 43, 5, 65, 7, 91, 9 };
            var result = numbers.Where(x => x%2==1).OrderBy(e => e.ToString()).ToArray();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

        }
    }
}
