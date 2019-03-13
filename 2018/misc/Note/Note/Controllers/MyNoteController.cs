using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Note.Models;

namespace Note.Controllers
{
    [Authorize]
    public class MyNoteController : Controller
    {
        private MyDbContext db;

        public MyNoteController(MyDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return Content(User.Identity.Name);
        }
        public IActionResult Main()
        {           
            var notes = db.Users.Where(x => x.Login == User.Identity.Name).Include(x => x.Notes).Select(x => x.Notes).First();
            if (notes == null) notes = new List<Models.Note>();
            ViewBag.Names = notes.Select(x => x.NoteName).ToList();
            ViewBag.Id = notes.Select(x => x.NoteId).ToList();
            return View();
        }

        public IActionResult Note(int id)
        {
            var note = db.Users.Where(x => x.Login == User.Identity.Name).Include(x => x.Notes).Select(x => x.Notes).First()
                .Where(x => x.NoteId == id).First();
            ViewData["id"] = note.NoteId;
            ViewData["name"] = note.NoteName;
            ViewData["text"] = note.NoteText;
            return View();
        }

        public FileResult GetFile(int id)
        {
            var note = db.Users.Where(x => x.Login == User.Identity.Name).Include(x => x.Notes).Select(x => x.Notes).First()
                .Where(x => x.NoteId == id).First();
            MemoryStream memoryStream = new MemoryStream();
            TextWriter tw = new StreamWriter(memoryStream);
            tw.WriteLine(note.NoteText);
            tw.Flush();
            tw.Close();
            return File(memoryStream.GetBuffer(), "text/plain", note.NoteName + ".txt");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NoteModel note)
        {
            var u = db.Users.Where(x => x.Login == User.Identity.Name).Include(x => x.Notes).FirstOrDefault();
            if (u.Notes == null) {
                u.Notes = new List<Models.Note>() { new Models.Note { NoteName = note.NoteName, NoteText = note.NoteText } };
            }
            else u.Notes.Add(new Models.Note { NoteName = note.NoteName, NoteText = note.NoteText });
            db.Users.Update(u);
            db.SaveChanges();
            
            return RedirectToAction("Main", "MyNote");
        }

        public IActionResult Edit(int id)
        {
            var note = db.Users.Where(x => x.Login == User.Identity.Name).Include(x => x.Notes).Select(x => x.Notes).First().
                Where(x => x.NoteId == id).First();
            ViewData["id"] = note.NoteId;
            ViewData["name"] = note.NoteName;
            ViewData["text"] = note.NoteText;
            return View();
        }

        public IActionResult Delete(int id)
        {
            if (id != 0)
            {
                var note = db.Users.Where(x => x.Login == User.Identity.Name).Include(x => x.Notes).Select(x => x.Notes).First()
                    .Where(x => x.NoteId == id).First();
                db.Notes.Remove(note);
                db.SaveChanges();
            }
            return RedirectToAction("Main", "MyNote");

        }

        public IActionResult CreateNote(int id,string name, string text)
        {
            var note = db.Notes.Where(x => x.NoteId == id).FirstOrDefault();
            note.NoteName = name;
            note.NoteText = text;
            db.Notes.Update(note);
            db.SaveChanges();
            return RedirectToAction("Main", "MyNote");           
        }
    }
}