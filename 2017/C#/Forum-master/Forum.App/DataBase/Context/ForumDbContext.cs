using Forum.App.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace Forum.App.DataBase.Context
{
    public class ForumDbContext : DbContext
    {
        public ForumDbContext(DbContextOptions opt) :base(opt)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Subforum> Forums { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Message> Messages { get; set; }
    }
}