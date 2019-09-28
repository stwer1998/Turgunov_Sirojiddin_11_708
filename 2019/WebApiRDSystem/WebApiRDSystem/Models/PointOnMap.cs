using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiRDSystem.Models
{
    public class PointOnMap
    {   
        [Key]
        public Guid IdPointOnMap { get; set; }

        public float Longitude { get; set; }

        public float Latitude { get; set; }

        public float Heights { get; set; }

        public override string ToString()
        {
            return Longitude + " " + Latitude + " " + Heights;
        }
    }
}
