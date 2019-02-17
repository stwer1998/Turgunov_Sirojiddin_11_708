using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Note.Controllers
{
    public class MyNoteController : Controller
    {
        public IActionResult Main()
        {
            ViewBag.Countries = Methods.GetNoteList();
            return View();
        }

        public IActionResult Note(string name)
        {
            ViewData["name"] = name;
            ViewData["text"] = Methods.GetNote(name);
            return View();
        }

        public FileResult GetFile(string name)
        {
            string file_path = @"D:\Notes\Note\" + name + ".txt";
            FileStream fs = new FileStream(file_path, FileMode.Open);
            string file_type = "plain/text";
            string file_name = name + ".txt";
            return File(fs, file_type, file_name);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(string name)
        {
            ViewData["name"] = name;
            ViewData["text"] = Methods.GetNote(name);
            Methods.DeleteNote(name);
            return View();
        }

        public IActionResult Delete(string name)
        {
            Methods.DeleteNote(name);
            return View();
        }

        public IActionResult CreateNote(string name, string text)
        {
            Methods.CreateNote(name, text);            
            return View();
        }
    }
}