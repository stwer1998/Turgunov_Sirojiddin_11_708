using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Note.Models
{
    public class Note
    {
        public int NoteId { get; set; }
        public string NoteName { get; set; }
        public string NoteText { get; set; }
        public User User { get; set; }

    }
}
