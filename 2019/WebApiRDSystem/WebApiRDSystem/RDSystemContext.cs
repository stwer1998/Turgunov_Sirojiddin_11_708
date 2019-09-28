using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiRDSystem.Models;

namespace WebApiRDSystem
{
    public class RDSystemContext: DbContext
    {
        public DbSet<PointOnMap> PointOnMap { get; set; }

        public DbSet<MapMarker> MapMarker { get; set; }

        public RDSystemContext(DbContextOptions<RDSystemContext> options):base(options)
        {
            Database.EnsureCreated();
        }
    }
}
