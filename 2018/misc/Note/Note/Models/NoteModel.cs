using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Note.Models
{
    public class NoteModel
    {
        [Required(ErrorMessage = "Не указано имя")]
        public string NoteName { get; set; }
        [Required(ErrorMessage = "Пустой текст")]
        public string NoteText { get; set; }
    }
}
