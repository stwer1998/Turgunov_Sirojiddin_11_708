using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class AccountReposirory:IAccountRepository
    {
        private MyDbContext db;
        public AccountReposirory()
        {
            db = new MyDbContext();
        }
       
        public bool GetOrganaizer(string login, string password)
        {
            var user = db.Organizers.FirstOrDefault(x => x.Login == login && x.Password == password);
            if (user != null) { return true; }
            else return false;
        }
      
        public void AddOrganaizer(Organizer organizer)
        {
            db.Organizers.Add(organizer);
            db.SaveChanges();
        }
        
        public bool GetLogin(string login)
        {
            var user = db.Organizers.FirstOrDefault(x => x.Login == login);
            if (user!= null) { return true; }
            else return false;
        }

        public Organizer GetOrganizer(string login)
        {
            return db.Organizers.Include(x=>x.Role).FirstOrDefault(x => x.Login == login);
        }
    }
}
