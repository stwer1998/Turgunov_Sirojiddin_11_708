using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Entities.Repositories;
using System.Reflection;

namespace Entities
{
    public class EventRepository : IEventRepository
    {
        private MyDbContext db;
        public EventRepository()
        {
            db = new MyDbContext();
        }

        public void AddEvent(string organizer_login, Event model)
        {
            var organizer = db.Organizers.Include(x => x.Events).FirstOrDefault(x => x.Login == organizer_login);

            if (organizer.Events == null)
            {
                organizer.Events = new List<Event>();
            }
            organizer.Events.Add(model);
            db.SaveChanges();

        }

        public void AddImageForEvent(string organizer_login, int id_event, Image image)
        {
            if (CheckEvent(organizer_login, id_event))
            {
                var @event = db.Events.Include(x => x.Image).First(x => x.Id == id_event);
                @event.Image = image;
                db.Update(@event);
                db.SaveChanges();
            }
        }

        public void AddImageForEvent(string organizer_login, int id_event, int id_participant, Image image)
        {
            if (CheckEvent(organizer_login, id_event))
            {
                var participant = db.Participants.Include(x => x.Image).First(x => x.Id == id_participant);
                participant.Image = image;
                db.Update(participant);
                db.SaveChanges();
            }
        }

        public void AddToEvent(string organizer_login, int id_event, object model)
        {
            if (CheckEvent(organizer_login, id_event))
            {
                string parametr = model.GetType().Name;
                if (parametr == "Participant")
                {

                    var @event = db.Events.Include(x => x.Participants).First(x => x.Id == id_event);
                    if (@event.Participants == null) { @event.Participants = new List<Participant>(); }
                    @event.Participants.Add(model as Participant);
                    db.Update(@event);
                    db.SaveChanges();
                }

                if (parametr == "Seat")
                {
                    var @event = db.Events.Include(x => x.Seats).First(x => x.Id == id_event);
                    if (@event.Seats == null) { @event.Seats = new List<Seat>(); }
                    @event.Seats.Add(model as Seat);
                    db.Update(@event);
                    db.SaveChanges();
                }
            }
        }

        public void AddViewer(int id_event, Viewer viewer)
        {
            var @event = db.Events.Include(x => x.Viewers).FirstOrDefault(x => x.Id == id_event);
            if (@event.Viewers == null)
            {
                @event.Viewers = new List<Viewer>();
            }
            @event.Viewers.Add(viewer);
            db.SaveChanges();
        }

        public bool CheckEvent(string organizer_login, int id_event)
        {
            if (db.Organizers.Include(x => x.Events).First(x => x.Login == organizer_login).Events.Where(x => x.Id == id_event) == null)
            {
                return false;
            }
            return true;
        }

        public void DeleteEvent(string organizer_login, int id_event)
        {
            if (CheckEvent(organizer_login, id_event))
            {
                var a = db.Events.First(x => x.Id == id_event);
                db.Events.Remove(a);
                db.SaveChanges();
            }
        }

        public void EditEvent(string organizer_login, int id_event, object model)
        {
            if (CheckEvent(organizer_login, id_event))
            {
                string parametr = model.GetType().Name;
                if (parametr == "Event")
                {
                    var @event = db.Events.First(x => x.Id == id_event);
                    @event = model as Event;
                    db.Events.Update(@event);
                    db.SaveChanges();
                }
                if (parametr == "Participant")
                {
                    var participant = model as Participant;
                    db.Participants.Update(participant);
                    db.SaveChanges();
                }

                if (parametr == "Seat")
                {
                    var seat = model as Seat;
                    db.Seats.Update(seat);
                    db.SaveChanges();
                }
            }
        }

        public Event GetEvent(string organizer_login, int id_event, params Expression<Func<Event, object>>[] includes)
        {
            if (CheckEvent(organizer_login, id_event))
            {
                return db.Events.Where(x => x.Id == id_event).IncludeMultiple(includes).First();
            }
            return null;
        }

        public Event GetEvent(string organizer_login, int id_event)
        {
            if (CheckEvent(organizer_login, id_event))
            {
                return db.Events.First(x => x.Id == id_event);
            }
            return null;
        }

        public Event GetEvent(int id_event)
        {
            return db.Events.Include(x => x.Participants).ThenInclude(p => (p.Image)).Include(x => x.Image).Include(x => x.Remaining_seats)
                .First(x => x.Id == id_event);
        }

        public List<Event> GetEventOrganization(string organizer_login)
        {
            return db.Organizers.Include(x => x.Events).FirstOrDefault(x => x.Login == organizer_login).Events;
        }

        public List<Event> GetEvents()
        {
            return db.Events.Where(x => x.End > DateTime.Now).OrderByDescending(x => x.Start).ToList();
        }

        public void RemoveFromEvent(string organizer_login, int id_event, string parametr, int id)
        {
            if (CheckEvent(organizer_login, id_event))
            {
                if (parametr == "Participant")
                {
                    var @event = db.Events.Include(x => x.Participants).First(x => x.Id == id_event);
                    @event.Participants.Remove(@event.Participants.First(x => x.Id == id));
                    db.SaveChanges();
                }
                if (parametr == "Seat")
                {
                    var @event = db.Events.Include(x => x.Seats).First(x => x.Id == id_event);
                    @event.Seats.Remove(@event.Seats.First(x => x.Id == id));
                    db.SaveChanges();
                }
            }
        }

        public MethodParams MethodParams(string name)
        {
            return db.MethodParams.First(x => x.MethodName == name);
        }

        public bool Check(MethodInfo targetMethod, object[] args)
        {
            var metod = targetMethod.Name;

            var prava = db.MethodParams.IncludeMultiple(x=>x.Roles,x=>x.Subscription).FirstOrDefault(x => x.MethodName == metod);

            var user=db.Organizers.IncludeMultiple(x => x.Role, x => x.Subscriptions).FirstOrDefault(x => x.Login == args[0].ToString());
            if (user.Role!=null&&prava.Roles[0].RoleName==user.Role.RoleName)
            {
                return true;
            }
            return false;
        }

        //#region
        //public void AddEvent(Event model, string user_login)
        //{
        //    var organizer = db.Organizers.Include(x => x.Events).FirstOrDefault(x => x.Login == user_login);
        //    //if (organizer.CanAddEvent)
        //    {
        //        if (organizer.Events == null)
        //        {
        //            organizer.Events = new List<Event>();
        //        }
        //        organizer.Events.Add(model);
        //        db.SaveChanges();
        //    }
        //}

        //public List<Event> GetEvents(string user)
        //{
        //    return db.Organizers.Include(x => x.Events).FirstOrDefault(x => x.Login == user).Events;
        //}

        //public List<Event> GetEvents()
        //{
        //    return db.Events.Where(x => x.End > DateTime.Now).OrderByDescending(x => x.Start).ToList();
        //}

        //public Event GetEvent(int id_event)
        //{
        //    return db.Events.Include(x => x.Participants).ThenInclude(p => p.Image).Include(x => x.Viewers).Include(x => x.Seats).FirstOrDefault(x => x.Id == id_event);
        //}

        //public void AddViewer(int id, Viewer viewer)
        //{
        //    var a = db.Events.Include(x => x.Viewers).FirstOrDefault(x => x.Id == id);
        //    if (a.Viewers == null)
        //    {
        //        a.Viewers = new List<Viewer>();
        //    }
        //    a.Viewers.Add(viewer);
        //    db.SaveChanges();
        //}
        //public void AddParticipant(int id, Participant participant)
        //{
        //    var e = db.Events.Include(x => x.Participants).FirstOrDefault(x => x.Id == id);
        //    if (e.Participants == null) { e.Participants = new List<Participant>(); }
        //    e.Participants.Add(participant);
        //    db.Update(e);
        //    db.SaveChanges();
        //}
        //public void EditPArticipant(int id, Participant participant)
        //{
        //    var e = db.Events.Include(x => x.Participants).FirstOrDefault(x => x.Id == id);
        //    var a = e.Participants.FirstOrDefault(x => x.Id == participant.Id);
        //    a = participant;
        //    db.Update(e);
        //    db.SaveChanges();
        //}
        //public void DeletePArticipant(int id, int id_par)
        //{
        //    var a = db.Events.Include(x => x.Participants).FirstOrDefault(x => x.Id == id);
        //    a.Participants.Remove(a.Participants.FirstOrDefault(x => x.Id == id_par));
        //    db.SaveChanges();
        //}

        //public void AddImgEvent(int id, Image img)
        //{
        //    var a = db.Events.FirstOrDefault(x => x.Id == id);
        //    a.Image = img;
        //    db.Update(a);
        //    db.SaveChanges();
        //}

        //public void AddImgPar(int id, int id_par, Image img)
        //{
        //    var a = db.Events.Include(x => x.Participants).FirstOrDefault(x => x.Id == id);
        //    var b = a.Participants.FirstOrDefault(x => x.Id == id_par);
        //    b.Image = img;
        //    db.Update(b);
        //    db.SaveChanges();
        //}
        //#endregion
    }
}
