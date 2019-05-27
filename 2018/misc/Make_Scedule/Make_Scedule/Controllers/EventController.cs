using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Entities.DynamicProxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Make_Scedule.Controllers
{
    #region
    [Authorize]
    public class EventController : Controller
    {
        IHostingEnvironment _appEnvironment;
        private IEventRepository repository;
        public EventController(IHostingEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
            repository = LoggingDecorator<IEventRepository>.Create(new EventRepository());
        }

        [HttpGet]
        public IActionResult AddEvent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEvent(Event model)
        {
            model.Remaining_seats = model.Seats;
            if (ModelState.IsValid)
            {
                repository.AddEvent(User.Identity.Name,model);
                return RedirectToAction("MyEvents", "Event");
            }
            else return View(model);
        }

        [HttpGet]
        public IActionResult AddParticipant(int event_id)
        {
            ViewData["id"] = event_id;
            return View();
        }

        [HttpPost]
        public IActionResult AddParticipant(int event_id, Participant participant)
        {
            if (ModelState.IsValid)
            {
                repository.AddToEvent(User.Identity.Name, event_id, participant);
                return RedirectToAction("Settings", "Event", new { id_event = event_id });
            }
            else return View(participant);
        }

        [HttpGet]
        public IActionResult EditParticipant(int id_event, int id_participant)
        {
            return View(repository.GetEvent(User.Identity.Name,id_event,(x=>x.Participants)).Participants.FirstOrDefault(x => x.Id == id_participant));
        }

        [HttpPost]
        public IActionResult EditParticipant(int id_event, Participant participant)
        {
            if (ModelState.IsValid)
            {
                repository.EditEvent(User.Identity.Name, id_event, participant);

            }
            return RedirectToAction("Settings", "Event", new { id_event = id_event });
        }

        public IActionResult DeleteParticipant(int id_event, int id_participant)
        {
            repository.RemoveFromEvent(User.Identity.Name, id_event,"Participant", id_participant);
            return RedirectToAction("Settings", "Event", new { id_event = id_event });
        }

        [HttpGet]
        public IActionResult AddSeat(int id)
        {
            ViewData["id"] = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddSeat(Seat seat)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Home", "Events");

            }
            else return View(seat);
        }

        public IActionResult MyEvents()
        {
            var @event = repository.GetEventOrganization(User.Identity.Name);
            if (@event != null)
            {
                ViewBag.id = @event.Select(x => x.Id).ToList();
                ViewBag.Name = @event.Select(x => x.Name).ToList();
                return View();
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpGet]
        public IActionResult Event(int id_event)
        {
            var @event = repository.GetEvent(User.Identity.Name, id_event, x => x.Viewers,x=>x.Participants);
            ViewBag.name = @event.Name;
            ViewBag.id = id_event;
            ViewBag.viewers = @event.Viewers;
            return View();
        }

        public IActionResult Settings(int id_event)
        {
            return View(repository.GetEvent(User.Identity.Name,id_event,x=>x.Participants,x=>x.Seats));
        }

        public async Task<IActionResult> AddImgEventAsync(int event_id, IFormFile file)
        {
             string path ="/images/Event/" + file.FileName;

            if (file != null)
            {
                using (var filestream = new FileStream(_appEnvironment.WebRootPath+ path, FileMode.Create))
                {
                    await file.CopyToAsync(filestream);
                }
                repository.AddImageForEvent(User.Identity.Name, event_id, new Image { Name = file.FileName, Path = path });

            }
            return RedirectToAction("Settings", "Event", new { id_event = event_id });
        }

        [HttpGet]
        public IActionResult AddimgParAsync(int event_id, int p_id)
        {
            ViewBag.event_id = event_id; ViewBag.p_id = p_id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddimgParAsync(int event_id, int p_id, IFormFile file)
        {
            string path = "/images/Participant/" + file.FileName;

            if (file != null)
            {
                using (var filestream = new FileStream(_appEnvironment.WebRootPath+path, FileMode.Create))
                {
                    await file.CopyToAsync(filestream);
                }
                repository.AddImageForEvent(User.Identity.Name, event_id, p_id, new Image { Name = file.FileName, Path = path });
            }
            return RedirectToAction("Settings", "Event", new { id_event = event_id });
        }
    }
    #endregion
}