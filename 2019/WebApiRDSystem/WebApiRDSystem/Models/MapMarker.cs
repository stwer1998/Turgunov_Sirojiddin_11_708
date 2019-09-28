using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiRDSystem.Models
{
    public class MapMarker
    {
        [Key]
        public Guid IdMapMarker { get; private set; }

        public PointOnMap Point { get; set; }

        public string Comment { get; set; }

        public DateTime Date { get; set; }
    }
}
