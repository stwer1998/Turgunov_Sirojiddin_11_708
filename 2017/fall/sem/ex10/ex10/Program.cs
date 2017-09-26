using System;


namespace ex10
{
    class Program
    {
        static void Main(string[] args)
        {
            
            {
                Console.WriteLine("Это Программа если Дано время в часах и минутах. Найходит угол" +
                    " от часовой к минутной стрелке на обычных часах.");
                Console.WriteLine("Сколько времени???");
                int hours = Convert.ToInt32(Console.ReadLine());
                int minutes = Convert.ToInt32(Console.ReadLine());
                double result = Math.Abs(6 * minutes - (30 * hours + 0.5 * minutes));
                result = result > 180 ? 360 - result : result;
                Console.WriteLine("Угол: {0}", result);
                Console.ReadKey();
            }
           
        }
    }
}
