using Domain.Validator;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities

{
    public class TimeEntity : BaseEntity
    {
        public FluentValidation.Results.ValidationResult Validar()
        {
            TimeValidator validator = new TimeValidator();
            var results = validator.Validate(this);
            
            return results;
        }
        public string Nome { get; set; }
    }
}
