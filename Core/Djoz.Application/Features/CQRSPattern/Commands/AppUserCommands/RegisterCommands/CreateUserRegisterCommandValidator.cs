using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Commands.AppUserCommands.RegisterCommands
{
    public class CreateUserRegisterCommandValidator : AbstractValidator<CreateUserRegisterCommandRequest>
    {
        public CreateUserRegisterCommandValidator()
        {
            
        }
    }
}
