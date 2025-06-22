using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Commands.SongCommands.UpdateCommands
{
    public class UpdateSongCommandValidator : AbstractValidator<UpdateSongCommandRequest>
    {
        public UpdateSongCommandValidator()
        {
            RuleFor(x => x.SongName).NotEmpty().WithMessage("Şarkı ismi boş geçilemez.");
            RuleFor(x => x.SongName).Length(3, 100).WithMessage("Şarkı ismi 3 ile 100 karakter arasında olabilir.");

            RuleFor(x => x.Singer).NotEmpty().WithMessage("Şarkıcı ismi boş geçilemez.");
            RuleFor(x => x.SongName).Length(3, 50).WithMessage("Şarkıcı ismi 3 ile 50 karakter arasında olabilir.");

            //Eğer mevcutta bir müzik url yok ise (ilk yükleme ise) dosya zorunludur.
            When(x => string.IsNullOrEmpty(x.SongUrl), () =>
            {
                RuleFor(x => x.SongFile).NotEmpty().WithMessage("Şarkı dosya olarak yüklenmeli.");
            });
        }
    }
}
