using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class MyDbContext : DbContext
    {
        const string connectionString = "Server=MACHINE-UBDDM1S;Database=storedb;Trusted_Connection=True;MultipleActiveResultSets=true";
        public MyDbContext() : base() { Database.EnsureCreated(); }

        public DbSet<Event> Events { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Viewer> Viewers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Subscriptions> Subscriptions { get; set; }
        public DbSet<MethodParams> MethodParams { get; set; }


        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
           // Database.EnsureCreated();
         }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
