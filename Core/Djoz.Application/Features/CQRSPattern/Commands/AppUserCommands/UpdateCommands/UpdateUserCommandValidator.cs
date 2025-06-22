using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Commands.AppUserCommands.UpdateCommands
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommandRequest>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Ad Soyad alanı boş geçilemez.");
            RuleFor(x => x.FullName).MinimumLength(3).WithMessage("Ad Soyad en az 3 karakter olmalıdır.");
            RuleFor(x=> x.FullName).MaximumLength(50).WithMessage("Ad Soyad en fazla 50 karakter olabilir.");

            RuleFor(x => x.PackageId).NotEmpty().WithMessage("Lütfen bir paket seçiniz.");
            RuleFor(x=> x.PackageId).GreaterThan(0).WithMessage("Geçerli bir paket seçmelisiniz.");
        }
    }
}
