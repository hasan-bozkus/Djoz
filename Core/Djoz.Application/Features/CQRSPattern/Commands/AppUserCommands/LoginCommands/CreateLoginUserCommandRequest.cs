using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Djoz.Application.Features.CQRSPattern.Commands.AppUserCommands.LoginCommands
{
    public class CreateLoginUserCommandRequest : IRequest<CreateLoginUserCommandResponse>
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}