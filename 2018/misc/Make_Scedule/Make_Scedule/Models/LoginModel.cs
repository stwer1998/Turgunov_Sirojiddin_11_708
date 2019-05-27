using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Make_Scedule.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указано логин")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Не указано пароль")]
        public string Password { get; set; }
    }
}
