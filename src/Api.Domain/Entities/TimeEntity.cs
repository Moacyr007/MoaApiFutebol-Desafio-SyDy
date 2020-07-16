using Domain.Interfaces.Services.Time;
using Domain.Validator;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities

{
    public class TimeEntity : BaseEntity
    {
        public FluentValidation.Results.ValidationResult Validar(ITimeService service)
        {
            TimeValidator validator = new TimeValidator(service);
            var results = validator.Validate(this);
            
            return results;
        }
        public string Nome { get; set; }
    }
}
