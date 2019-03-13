using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Note.Models
{
    public class RegisterModel
    {
        
        public string Login { get; set; }
               
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
