using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Commands.EventCommands.UpdateCommands
{
    public class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommandRequest>
    {
        public UpdateEventCommandValidator()
        {
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel url'i boş geçilemez.");
            RuleFor(x => x.ImageUrl).MaximumLength(300).WithMessage("Görsel url'i en fazla 300 karakter olabilir.");
            RuleFor(x => x.ImageUrl).Must(url => url.EndsWith(".jpg") || url.EndsWith(".png") || url.EndsWith(".jpeg")).WithMessage("Görsel url'i .jpg, jpeg veya .png uzantılı olabilir.");

            RuleFor(x => x.Date).GreaterThan(DateTime.Now).WithMessage("Tarih bilgisi bugünden sonraki bir tarih olamaz.");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Etkinlik adı boş geçilemez.");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Etkinlik adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.Location).NotEmpty().WithMessage("Lokasyon bilgisi boş geçilemez.");
            RuleFor(x => x.Location).MaximumLength(150).WithMessage("Lokasyon bilgisi en fazla 150 karater olabilir.");
        }
    }
}
