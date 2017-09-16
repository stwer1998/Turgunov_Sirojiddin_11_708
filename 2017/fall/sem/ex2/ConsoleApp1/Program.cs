using System;


namespace Exsirsice2
{
    class Program
    {
        private static string Debug;
        private static string rere;

        static void Main(string[] args)
        {
            Console.WriteLine("Ппишите цифру");
            string abc = Console.ReadLine(), cba = "";
         for (int i = 0; i < abc.Length; i++) 
                cba += abc[abc.Length - i - 1];
            Console.WriteLine(cba);
            Console.ReadKey();
        }
    }
}
