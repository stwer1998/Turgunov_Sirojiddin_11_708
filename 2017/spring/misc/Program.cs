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



    public class Second
    {
        public static void Commit()
        {
            //string file = "road to file";
            //var str=File.ReadAllLines(file);
            var str = JsonConvert.SerializeObject();
            Console.WriteLine(str);
            var list = new List<string>();
            list.AddRange(str.Split('}'));
            for (int i = 0; i < list.Count; i=i+2)
            {
                Body(list[i]);
            }
        }
        static void Body(string str)
        {
            var letters = new List<string>();
            letters.AddRange(str.Split(','));

            var letters1 = new List<string>();

            for (int i = 4; i < letters.Count; i=i+5)
            {
                letters1.AddRange(letters[i].Split(':'));
            }

            var result = new List<int>();
            for (int i = 0; i < letters1.Count; i = i + 2)
            {
                result.Add(letters1[i].Length);
            }
            {
                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
   public class First
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
            
            var str = JsonConvert.SerializeObject(students);
            Print(str);
        }
        static void Print(string str)
        {
            string[] word = str.Split(',');
            var list = new List<string>();
            for (int i = 0; i < word.Length; i++)
            {
                string a = word[i];
                list.AddRange(a.Split(':'));
            }
            var result = new List<string>();
            for (int i = 0; i < list.Count; i = i + 2)
            {
                if (Check(list[i]))
                {
                    result.Add(list[i]);
                    result.Add(list[i + 1]);
                }
            }

            for (int i = 0; i < result.Count; i = i + 2)
            {
                Console.Write(result[i] + " : ");
                Console.WriteLine(result[i + 1]);
            }
        }
        static bool Check(string str)
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
        static bool CheckLetter(char letter)
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
