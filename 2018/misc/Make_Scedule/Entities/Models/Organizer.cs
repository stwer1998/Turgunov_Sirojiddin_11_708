using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Organizer
    {
        public int Id { get; private set; }

        public Role Role { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указано пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указано почта")]
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        public string Email{ get; set; }   
        
        [Required(ErrorMessage = "Не указано номер")]
        [Phone]
        public string Phone_Number{ get; set; }

        public List<Event> Events { get; set; }  
        
        public double Monney { get; set; }

        public List<Subscriptions> Subscriptions { get; set; }
    }
}
