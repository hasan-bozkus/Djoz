using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Commands.CountDownCommands.UpdateCommands
{
    public class UpdateCountDownCommandValidator : AbstractValidator<UpdateCountDownCommandRequest>
    {
        public UpdateCountDownCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş geçilemez");
            RuleFor(x => x.Title).MaximumLength(100).WithMessage("Başlık en fazla 100 karakter olabilir.");

            RuleFor(x => x.SubTitle).NotEmpty().WithMessage("Alt başlık boş geçilemez.");
            RuleFor(x => x.SubTitle).MaximumLength(200).WithMessage("Alt başlık en fazla 200 karakter olabilir.");

            RuleFor(x => x.Date).NotEmpty().WithMessage("Tarih boş geçilemez.");
            RuleFor(x => x.Date).GreaterThan(DateTime.Now).WithMessage("Tarih bugünden sonraki bir tarih olmamalıdır.");
        }
    }
}
