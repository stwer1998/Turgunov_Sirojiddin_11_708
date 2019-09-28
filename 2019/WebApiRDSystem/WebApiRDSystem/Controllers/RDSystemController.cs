using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiRDSystem.Models;

namespace WebApiRDSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RDSystemController : ControllerBase
    {
        private RDSystemContext db;

        public RDSystemController(RDSystemContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetMapMarkers() 
        {
            return db.PointOnMap.Select(x => x.ToString()).ToArray();
        }
       
        [HttpPost]
        public ActionResult<string> GetMapMarkers(string s) 
        {
            return "Ok Xoxlov";
        }

    }
}