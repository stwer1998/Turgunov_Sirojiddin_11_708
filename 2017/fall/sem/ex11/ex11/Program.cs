using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex11
{
    class Program
    {
      static void Main(string[] args)
      {
            double high = double.Parse(Console.ReadLine());
            double time = double.Parse(Console.ReadLine());
            double speed = double.Parse(Console.ReadLine());
            double s = double.Parse(Console.ReadLine());

            double Mininimum;  
            double maxsimum = time;
            if (s >= high / time)
            {
                Mininimum = 0;
                maxsimum = high / s;
            }
            else Mininimum = (high - s * time) / (speed - s);

            Console.WriteLine(Mininimum);
            Console.WriteLine(maxsimum);
        }   
    }
}
