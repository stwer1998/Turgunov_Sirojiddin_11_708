using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class MyStack
    {
        List<int> list = new List<int>();
        public void Push(int value)
        {
            list.Add(value);
        }
        public int Pop()
        {
            if (list.Count == 0) throw new InvalidOperationException();
            var result = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return result;
        }
    }
}
