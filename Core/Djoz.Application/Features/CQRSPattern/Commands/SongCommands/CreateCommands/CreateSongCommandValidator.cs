using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Commands.SongCommands.CreateCommands
{
    public class CreateSongCommandValidator : AbstractValidator<CreateSongCommandRequest>
    {
        public CreateSongCommandValidator()
        {
            RuleFor(x => x.SongName).NotEmpty().WithMessage("Şarkı ismi boş geçilemez.");
            RuleFor(x => x.SongName).Length(3, 100).WithMessage("Şarkı ismi 3 ile 100 karakter arasında olabilir.");

            RuleFor(x => x.Singer).NotEmpty().WithMessage("Şarkıcı ismi boş geçilemez.");
            RuleFor(x => x.SongName).Length(3, 50).WithMessage("Şarkıcı ismi 3 ile 50 karakter arasında olabilir.");

            RuleFor(x => x.SongFile).NotEmpty().WithMessage("Şarkı Url'si boş geçilemez.");
        }
    }
}
