using System;
using System.Collections.Generic;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
         // Посчитать количество различных подстрок строки с использованием хэширования
            Console.WriteLine(FinderSubstring.Finder());
        }
    }
    class FinderSubstring
    {
        public static List<long> substrings= new List<long>();
        public static long[] str = new long[] { 11, 11, 12, 11 };
        public static int Finder()
        //Сначала каждую букву хэшируем потом по очереди добавим 
        //в список подстрок. Н-р: (aaba),a,aa,aab,aaba,a,ab,aba,b,ba,a.
        {
            for (int i = 0; i < str.Length; i++)
            {
                Join(str[i]);
                int degree = 100;
                long old = str[i];
                for (int j = i + 1; j < str.Length; j++)
                {
                    Join(old * degree + str[j]);
                    old = old * degree + str[j];
                }
            }
            return substrings.Count;
        }
        public static void Join(long item)//проверяем если небыло токого элемента то добавим            
        {
            int a = 0;
            for (int i = 0; i < substrings.Count; i++)
            {
                if (item == substrings[i]) { a++; }
            }
            if (a == 0) { substrings.Add(item); }
        }
    }
}
