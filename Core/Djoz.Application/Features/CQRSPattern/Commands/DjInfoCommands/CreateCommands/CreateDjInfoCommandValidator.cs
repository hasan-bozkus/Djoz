using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Commands.DjInfoCommands.CreateCommands
{
    public class CreateDjInfoCommandValidator : AbstractValidator<CreateDjInfoCommandRequest>
    {
        public CreateDjInfoCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("DJ ismi boş geçilemez.");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("DJ ismi en fazla 100 karakter olabilir.");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş geçilemez.");
            RuleFor(x => x.Description).MaximumLength(600).WithMessage("Açıklama en fazla 500 karakter olabilir.");
        }
    }
}
