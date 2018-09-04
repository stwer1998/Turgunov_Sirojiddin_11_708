
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farey
{
    class Program
    {
        static void Main(string[] args)
        {
            Farey.FindFarey(30);
        }
    }
    class Farey
    {
        public static void FindFarey(int n)
        {
            Console.WriteLine("{0} / {1}",0,1);
            FindFarey(n, 0, 1, 1, 1);
            Console.WriteLine("{0} / {1}", 1, 1);
        }
        static void FindFarey(int n,int x,int y,int z,int t)
        {
            int a = x + z;
            int b = y + t;
            if (b <= n)
            {
                FindFarey(n, x, y, a, b);
                Console.WriteLine("{0} / {1}", a,b);
                FindFarey(n, a, b, z, t);
            }
        }
    }
}
