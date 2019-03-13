using Microsoft.AspNetCore.Mvc;
using Note.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Note.Controllers
{
    public class Methods
    {
        

        static string path = @"D:\Notes\Note\";
        static string ending = ".txt";
        public static List<string> GetNoteList()
        {
            //return db
            List<string> names = new List<string>();
            foreach (string item in Directory.GetFiles(path))
            {
                names.Add(item.Split(new char[] { '\\', '.' })[3]);
            }
            return names;
        }

        public static void DeleteNote(string name)
        {
            File.Delete(path + name + ending);        
        }

        public static bool CreateNote(string name, string text)
        {
            using (var textWriter = new StreamWriter(path + name + ending))
            {
                textWriter.WriteLine(text);
            }
            return true;
        }

        public static string GetNote(string name)
        {
            using (var reader = new StreamReader(path + name + ending))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
