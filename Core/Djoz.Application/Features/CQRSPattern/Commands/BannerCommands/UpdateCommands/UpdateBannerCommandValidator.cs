using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Commands.BannerCommands.UpdateCommands
{
    public class UpdateBannerCommandValidator : AbstractValidator<UpdatSongCommandRequest>
    {
        public UpdateBannerCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş geçilemez!");
            RuleFor(x => x.Title).MinimumLength(3).WithMessage("En az 3 karakter giriniz.");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("En fazla 3 karakter giriniz.");

            RuleFor(x => x.SubTitle).NotEmpty().WithMessage("Alt Başlık boş geçilemez!");
            RuleFor(x => x.SubTitle).MinimumLength(3).WithMessage("En az 3 karakter giriniz.");
            RuleFor(x => x.SubTitle).MaximumLength(50).WithMessage("En fazla 3 karakter giriniz.");

            RuleFor(x => x.SubTitle).NotEmpty().WithMessage("Açıklama boş geçilemez!");
            RuleFor(x => x.SubTitle).MinimumLength(10).WithMessage("En az 10 karakter giriniz.");
            RuleFor(x => x.SubTitle).MaximumLength(100).WithMessage("En fazla 100 karakter giriniz.");
        }
    }
}
