using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace Entities
{
    public class Seat : IValidatableObject
    {
        public int Id { get;private set; }
        [Required(ErrorMessage = "Не указано категория")]
        public int Category { get; set; }
        [Required(ErrorMessage = "Не указано количество")]
        public int Quantity { get; set; }
        public string Description { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (Quantity < 0)
            {
                errors.Add(new ValidationResult("Количество не может быть меньше 0", new List<string>() { "Quantity" }));
            }
            return errors;
        }
    }
}
