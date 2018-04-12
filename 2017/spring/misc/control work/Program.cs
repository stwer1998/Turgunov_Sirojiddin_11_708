using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_work
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
        }
        public static void First()
        {
            var a = new int[] { 100, 200, 300, 400, 500, 600, 700, 800, 900 };
            var b = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90 };

            var res = a.SelectMany(a1 =>b.Where(z => z%10000 - a1%10000==0)).ToArray();
            //берем элементя из а и элементы из b  если 5 число совпоют        
        }

    }
}
