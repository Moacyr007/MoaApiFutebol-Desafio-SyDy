using Domain.Entities;
using FluentValidation;

namespace Domain.Validator
{
    public class TimeValidator : AbstractValidator<TimeEntity>
    {
        public TimeValidator()
        {
            RuleFor(time => time.Nome)
                .NotNull().WithMessage("Nome não deve ser nulo")
                .MinimumLength(3);
        }
    }
}
