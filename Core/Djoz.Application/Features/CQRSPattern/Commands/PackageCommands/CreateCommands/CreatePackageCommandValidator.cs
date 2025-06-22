using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Commands.PackageCommands.CreateCommands
{
    public class CreatePackageCommandValidator : AbstractValidator<CreatePackageCommandRequest>
    {
        public CreatePackageCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Paket adı boş geçilemez.");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Paket adı en az 3 karkterli olabilir.");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Paket adı en fazla 50 karkterli olabilir.");
        }
    }
}
