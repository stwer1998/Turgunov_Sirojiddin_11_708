using System;

namespace RadixSort
{
    class Program
    {
        static void Main()
        {
            var a = new string[] { "925", "564"};
            RadixSort_MSD(a);
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }
        }

        public static void RadixSort_MSD(string[] a)
        {
            string[] array = new string[a.Length];
            Sort(a, array, 0, a.Length - 1, 0);
        }

        private static void Sort(string[] a, string[] array, int finish, int length, int rank)
        {
            if (finish >= length) return;
            var R = 256;
            var count = new int[R + 2];
            for (var i = finish; i <= length; ++i)
            {
                count[charAt(a[i], rank) + 2]++;
            }
            for (var r = 0; r < R + 1; ++r)
            {
                count[r + 1] += count[r];
            }
            for (var i = finish; i <= length; ++i)
            {
                array[count[charAt(a[i], rank) + 1]++] = a[i];
            }
            for (var i = finish; i <= length; ++i)
            {
                a[i] = array[i - finish];
            }
            for (var r = 0; r < R + 1; ++r)
            {
                Sort(a, array, finish + count[r], finish + count[r + 1] - 1, rank + 1);
            }
        }

        private static int charAt(string a, int d)
        {
            if (a.Length <= d)
            {
                return -1;
            }
            return a[d];
        }
    }
}