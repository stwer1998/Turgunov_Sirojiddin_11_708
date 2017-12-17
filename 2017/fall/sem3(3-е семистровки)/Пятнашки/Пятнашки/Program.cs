using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Пятнашки
{
    class Program
    {
        static int size = 4;//чтобы мы потом могли изменять размер поля 
        static int[,] map = new int[size, size];//создаем массив
        static int spaceY, spaceX; // кординаты свободной клавиши        
        static void Main(string[] args)
        {
            Start();
            Print();
            Mix(1);
            for (int i = 0; !CheckUp(); i++)
            {
                ConsoleKeyInfo keyInfo;
                keyInfo = Console.ReadKey();
                Move(keyInfo.Key);
            }
        }
        static bool CheckUp()//проверяем победу 
        {
            int b = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if ((map[i, j]-1) / size == i && (map[i, j]-1) % size == j) { b++; }
                }
            }
            if (b == size * size) { Print(); Console.WriteLine("Congratulation you win!!!"); Console.ReadLine(); return true; }
            else { return false;  }
        }
        static void Mix(int n)// перемешиваем цифры несколько раз
        {
            for (int a = 0; a < n * 2; a++)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (spaceY - 1 < 0) { Move(ConsoleKey.UpArrow); } else Move(ConsoleKey.DownArrow);
                    if (spaceX - 1 < 0) { Move(ConsoleKey.LeftArrow); } else Move(ConsoleKey.RightArrow);
                }
                for (int i = 0; i < 5; i++)
                {
                    if (spaceY + 1 > size - 1) { Move(ConsoleKey.DownArrow); } else Move(ConsoleKey.UpArrow);
                    if (spaceX + 1 > size - 1) { Move(ConsoleKey.RightArrow); } else Move(ConsoleKey.LeftArrow);
                }
            }
        }
        static void Move(ConsoleKey keyInfo)// в этом методе проверяем коректность хода и перемещаем клавиш 
        {
            if (keyInfo == ConsoleKey.DownArrow)
            {
                if (spaceY - 1 < 0) { Print(); Console.WriteLine("Wrong way!!!"); }
                else
                {
                    map[spaceY, spaceX] = map[spaceY - 1, spaceX];
                    map[spaceY - 1, spaceX] = size * size;
                    spaceY = spaceY - 1;
                    Print();
                }

            }
            else if (keyInfo == ConsoleKey.UpArrow)
            {
                if (spaceY + 1 > size - 1) { Print(); Console.WriteLine("Wrong way!!!"); }
                else
                {
                    map[spaceY, spaceX] = map[spaceY + 1, spaceX];
                    map[spaceY + 1, spaceX] = size * size;
                    spaceY = spaceY + 1; Print();
                }
            }
            else if (keyInfo == ConsoleKey.RightArrow)
            {
                if (spaceX - 1 < 0) { Print(); Console.WriteLine("Wrong way!!!"); }
                else
                {
                    map[spaceY, spaceX] = map[spaceY, spaceX - 1];
                    map[spaceY, spaceX - 1] = size * size;
                    spaceX = spaceX - 1; Print();
                }
            }
            else if (keyInfo == ConsoleKey.LeftArrow)
            {
                if (spaceX + 1 > size - 1) { Print(); Console.WriteLine("Wrong way!!!"); }
                else
                {
                    map[spaceY, spaceX] = map[spaceY, spaceX + 1];
                    map[spaceY, spaceX + 1] = size * size;
                    spaceX = spaceX + 1; Print();
                }
            }

        }
        static void Start()//заполняем наш массив 
        {
            int number = 1;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    map[i, j] = number; number++;
                }
            }
            spaceX = size - 1;
            spaceY = size - 1;
            Print();
        }
        static void Print()// метод вывода массива с консоль
        {
            Console.Clear();
            Console.WriteLine("Пятнашки вы должны поставить клавиши по порятку возрастания"); Console.WriteLine("");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (map[i, j] == size * size) { Console.Write("|    |"); }//пустая клавиша
                    else if (map[i, j] < 10) { Console.Write("|  " + map[i, j] + " |"); }
                    else Console.Write("| " + map[i, j] + " |"); // чтобы бало красиво попрпвляем границы
                }
                Console.WriteLine();
            }

        }
    }
}
