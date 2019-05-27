using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Make_Scedule.Models;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Entities.Repositories;

namespace Make_Scedule.Controllers
{    
    public class HomeController : Controller
    {
        private IEventRepository repository;
        public HomeController()
        {
            repository = new EventRepository();
        }

        public IActionResult Events()
        {
            var events = repository.GetEvents();
            ViewBag.id = events.Select(x => x.Id).ToList();
            ViewBag.Name = events.Select(x => x.Name).ToList();
            return View();
        }
        
        public IActionResult AddViewer(int id)
        {
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public IActionResult AddViewer(int id_event,Viewer model)
        {
            if (ModelState.IsValid)
            {
                repository.AddViewer(id_event,model);
                return Redirect("Events");
            }
            else  return View(model);
        }

        public IActionResult Event(int id)
        {
            var a = repository.GetEvent(id);

            return View(repository.GetEvent(id));
        }        
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
