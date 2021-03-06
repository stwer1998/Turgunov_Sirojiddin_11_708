﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem4
{
    public class MyBigInteger//создаем клас BIgInteger
    {
        private List<int> arr = new List<int>();
        public static MyBigInteger operator *(MyBigInteger a, MyBigInteger b)//оператор умножение
        //умножение происходит по закону умножение столбиком
        //1-ое число умножем на все числа другого массива
        //со 2-ого умножем на все числа другого массива и результат умножем на 10 по закону умножение столбиком
        {
            MyBigInteger rez = new MyBigInteger(0);
            for (int i = 0; i < b.arr.Count(); i++)
            {
                MyBigInteger newN = a * b.arr[i];
                for (int j = 0; j < i; j++)
                {
                    newN.arr.Insert(0, 0);
                }
                rez += newN;
            }
            return rez;
        }
        public static MyBigInteger operator *(MyBigInteger a, int b)//умножение BigInteger на число это легче чем BigInteger на BigInteger 
        //если при умножение число получим больше 10 по запишем %10 а оставшее добавим следуюшиму разряду
        {
            if (b > 9)
            {
                return a * (new MyBigInteger(b));
            }
            List<int> v = new List<int>();
            int c = 0;
            for (int i = 0; i < a.arr.Count(); i++)
            {
                int p = c + a.arr[i] * b;
                v.Add(p % 10);
                c = p / 10;
            }
            if (c != 0)
            {
                v.Add(c);
            }
            return new MyBigInteger(v);
        }
        public static MyBigInteger operator +(MyBigInteger a, MyBigInteger b)//оператор сложение
         //сложение происходит по закону сложение столбиком
         //если один из чисел больше другого чтобы было удобно добавим 0 до равенства
         //если при сложенни число получим больше 10 по запишем %10 а оставшее добавим следуюшиму разряду
        {
            List<int> v = new List<int>();
            int c = 0;
            for (int i = 0; i < a.arr.Count() && i < b.arr.Count(); i++)
            {
                int p = c + a.arr[i] + b.arr[i];
                v.Add(p % 10);
                c = p / 10;
            }
            if (a.arr.Count() < b.arr.Count())
            {
                for (int i = a.arr.Count(); i < b.arr.Count(); i++)
                {
                    int p = c + b.arr[i];
                    v.Add(p % 10);
                    c = p / 10;
                }
            }
            else if (a.arr.Count() > b.arr.Count())
            {
                for (int i = b.arr.Count(); i < a.arr.Count(); i++)
                {
                    int p = c + a.arr[i];
                    v.Add(p % 10);
                    c = p / 10;
                }
            }
            if (c != 0)
            {
                v.Add(c);
            }
            return new MyBigInteger(v);
        }
        public MyBigInteger(List<int> arr)
        {
            this.arr = arr;
        }
        public MyBigInteger()//добавляем в лист
        {
            arr.Add(0);
        }
        public MyBigInteger(int a)//число сохраняем в лист
        {
           while (a != 0)
            {
                arr.Add(a % 10);
                a /= 10;
            }
        }
        public static MyBigInteger generation(MyBigInteger a)
        {
            return a * a;
        }
        public void print()//Так число в лист сохранили в перевернутом виде print начинает выводить с конца
        {
            for (int i = arr.Count() - 1; i >= 0; i--)
            {
                Console.Write(arr[i]);
            }
            Console.Write("\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число");
            int n = Convert.ToInt32(Console.ReadLine());
            MyBigInteger result = new MyBigInteger(), num = new MyBigInteger(1);
            for (int i = 1; i <= n; i++)
            {
                num *= MyBigInteger.generation(new MyBigInteger(i));
                result += num;
            }
            result.print();
        }
    }
}
