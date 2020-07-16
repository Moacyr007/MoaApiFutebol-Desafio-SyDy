using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Services.Time;
using FluentValidation;
using System.Linq;
using System.Collections.Generic;

namespace Domain.Validator
{
    public class TimeValidator : AbstractValidator<TimeEntity>
    {
        private ITimeService _service;

        public TimeValidator(ITimeService service)
        {
            _service = service;

            RuleFor(time => time.Nome)
                .NotNull().WithMessage("Nome não deve ser nulo")
                .MinimumLength(3);
            RuleFor(time => time.Nome).MustAsync(IsNameUnique).WithMessage("Nome deve ser único");
        }

        private async Task<bool> IsNameUnique(string nome, CancellationToken arg2)
        {
            var times = await _service.FindAll(nome);
            return !times.Any(x => x.Nome == nome);
        }
    }
}
