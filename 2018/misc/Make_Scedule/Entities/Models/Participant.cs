using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Participant : IValidatableObject
    {
        public int Id { get; private set; }
        [Required(ErrorMessage = "Не указано название")]
        public string Name { get; set; }        
        public string Surname { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Не указано начало")]
        public DateTime Start { get; set; }
        [Required(ErrorMessage = "Не указано конец")]
        public DateTime End { get; set; }
        public Image Image { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (Start > End)
            {
                errors.Add(new ValidationResult("Дата окончания события раньше даты начала",new List<string>() {"Start" }));
            }

            return errors;
        }
    }
}
