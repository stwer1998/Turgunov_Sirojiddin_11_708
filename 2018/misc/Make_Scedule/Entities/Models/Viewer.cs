using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Viewer
    {
        public int Id { get; private set; }
        [Required(ErrorMessage = "Не указано Имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указано Фамилия")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Не указано почта")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Не указано билет")]
        public Seat Ticket { get; set; }
    }
}
