using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Commands.ContactCommands.UpdateCommands
{
    public class UpdateContactCommandValidator : AbstractValidator<UpdateContactCommandRequest>
    {
        public UpdateContactCommandValidator()
        {
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon boş geçilemez");
            RuleFor(x => x.Phone).Matches(@"^05\d{9}$").WithMessage("Telefon numarası 05 ile başlamalı ve 11 haneli olmalıdır.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email adresi boş geçilemez");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");
        }
    }
}
