using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ConsoleApp4
{

    public class Program
    {
        public static void Main()
        {
            Second.Commit();
        }
    }

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    //
    // По адресы https://jsonplaceholder.typicode.com/comments?postId=1 лежит список комментариев
    // в формате JSON. Для этого списка в каждом четном комментарии необходимо сосчитать число букв
    // в комментарии(поле body). Использовать максимально все технологии, которые вы знаете: многопоточное
    // или асинхронное программирование, linq и т.д. Парсер json можно использовать библиотечный.
    //
    public class Third
    {
        public static void Commit()
        {
            // так как вы сказали считаем из файла
            //string file = "road to file";
            //var str=File.ReadAllLines(file);
            var str = JsonConvert.SerializeObject();
            Console.WriteLine(str);
            var list = new List<string>();
            list.AddRange(str.Split('}'));//получаем отдельные объекты в виде
            //   "postId":    , "id":     , "name":    ,  "email":     ,   "body":   
            for (int i = 0; i < list.Count; i=i+2)//берем четные объекты
            {
                Body(list[i]);
            }
        }
        static void Body(string str)
        {
            var letters = new List<string>();
            letters.AddRange(str.Split(','));// объект делим по полям

            var letters1 = new List<string>();

            for (int i = 4; i < letters.Count; i=i+5)
            //   "postId": 0   , "id": 1    , "name":  2  ,  "email": 3    ,   "body": 4
            // берем только body и строку
            {
                letters1.AddRange(letters[i].Split(':'));
            }

            var result = new List<int>();
            for (int i = 1; i < letters1.Count; i = i + 2)// сейчас lettesr1 содержит body  по четным индексам
                // b строку по нечетням
            {
                result.Add(letters1[i].Length);//берем нечетные и считаем символы
            }
            {
                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
    //
    // Для списка объектов необходимо вывести все названия методов, в наименовании 
    //которых четное число согласных букв. Сериализовать такие объекты в формат JSON.
    //
    //
    //
    public class Second
    {        
        public static void Json()
        {
            var students = new List<Student>
            {
            new Student
            {
                FirstName = "John",
                LastName = "Smith",
                Age = 20
            },
            new Student
            {
                FirstName = "James",
                LastName = "Adams",
                Age = 19
            }
            };
            
            var str = JsonConvert.SerializeObject(students);//сериализуем в формате Json
            Print(str);
        }
        static void Print(string str)
        {
            string[] word = str.Split(',');//делим по объектам
            var list = new List<string>();
            for (int i = 0; i < word.Length; i++)
            {
                string a = word[i];
                list.AddRange(a.Split(':'));//так как уже делили по объектам теперь получаем название методов
            }
            var result = new List<string>();
            for (int i = 0; i < list.Count; i = i + 2)
            {
                if (Check(list[i]))//провери содержитли четное количество согласных
                {
                    result.Add(list[i]);
                    result.Add(list[i + 1]);
                }
            }

            for (int i = 0; i < result.Count; i = i + 2)
            {// печатаем
                Console.Write(result[i] + " : ");
                Console.WriteLine(result[i + 1]);
            }
        }
        static bool Check(string str)//провери содержитли четное количество согласных
        {
            int result = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (CheckLetter(str[i]))
                {
                    result++;
                }
            }
            if (result % 2 == 0) { return true; }
            return false;
        } 
        static bool CheckLetter(char letter)//провери содержитли четное количество согласных
        {
            string letters = "qwrtypsdfghjklmnbvcxz";
            for (int i = 0; i < letters.Length; i++)
            {
                if (letter == letters[i]) { return true; }
            }
            return false;
        }
    }
    
}
