using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Считывая числа покa не встретится 0, найти минимальное 
            //число и сколько раз оно встречается в последовательности
            Console.WriteLine("Это програма Считывает числа пока не встретится 0," +
                "и надет минимальное число и сколько раз оно встречается в последовательности");
            int min = Convert.ToInt32(Console.ReadLine()), numberOfMin = 1;
            while (true)
            {
               
                int number = Convert.ToInt32(Console.ReadLine());
                if (number == 0)
                    break;
                if (number < min)
                {
                    min = number;
                    numberOfMin = 1;
                }
                else if (number == min)
                {
                    numberOfMin++;
                }
            }
            Console.WriteLine("Минимальное число "+min + " встречается " + numberOfMin+" раз ");
            Console.ReadKey();
                
        }
    }
}
