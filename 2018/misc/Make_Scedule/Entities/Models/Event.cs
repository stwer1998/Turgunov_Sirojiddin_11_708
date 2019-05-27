using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Event : IValidatableObject
    {
        public int Id { get; private set; }

        [Required(ErrorMessage = "Не указано название")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Не указано начало")]
        public DateTime Start { get; set; }

        [Required(ErrorMessage = "Не указано конец")]
        public DateTime End { get; set; }
        /// <summary>
        /// все места
        /// </summary>
        public List<Seat> Seats { get; set; }
        /// <summary>
        /// оставшие места
        /// </summary>
        public List<Seat> Remaining_seats { get; set; }

        [Required(ErrorMessage = "Не указано адрес")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Не указано цель")]
        [StringLength(200, MinimumLength = 20, ErrorMessage = "Длина строки должна быть от 20 до 200 символов")]
        public string Description { get; set; }

        public Image Image { get; set; }

        public List<Participant> Participants { get; set; }

        public List<Viewer> Viewers { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (Start > End)
            {
                errors.Add(new ValidationResult("Дата окончания события раньше даты начала", new List<string>() {"Start"}));
            }
            if (Start < DateTime.Now)
            {
                errors.Add(new ValidationResult("Дата начала позже сегоднего", new List<string>() { "Start" }));

            }
            if (Participants != null)
            {
                foreach (var participant in Participants)
                {
                    if (participant.Start > End && participant.End > End)
                    {
                        errors.Add(new ValidationResult("Расписание неправильно"));
                    }
                }
            }
            return errors;

        }
    }
}
