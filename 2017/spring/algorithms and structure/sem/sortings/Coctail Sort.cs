using System;
namespace ConsoleApp2
{
    class Program
    {
        static void Main()
        {
        }
        static int[] CoctailSort(int[] array)
        {
            int left = 0,//левая граница
                right = array.Length - 1,//правая граница
                step = 0;//число иттераций

            while (left <= right)
            {
                int a = 0;//переменная для выхода
                for (int i = left; i < right; i++)//в этом цикле max элемент гдебы не было переместится в конец массива
                {
                    if (array[i] > array[i + 1])
                        step++; Swap(array, i, i + 1); a++;
                }
                right--;//так -как max тепер в конце мы може его не трогать

                if (a == 0) break;//если ни кокого перемешение не было тогда мы можем выйти из цикла
                for (int i = right; i > left; i--)//в этом цикле min элемент гдебы не было переместится в начало массива
                {
                    if (array[i - 1] > array[i])
                        step++; Swap(array, i - 1, i);//
                }
                left++;//так -как min тепер в начале мы може его не трогать
            }
            step += array.Length;
            return array;
        }

        /* Поменять элементы местами */
        static void Swap(int[] array, int i, int j)
        {
            int glass = array[i];
            array[i] = array[j];
            array[j] = glass;
        }
    }
}

