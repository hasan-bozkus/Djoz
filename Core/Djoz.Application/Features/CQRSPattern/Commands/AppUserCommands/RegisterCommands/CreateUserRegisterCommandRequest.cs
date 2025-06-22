using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Djoz.Application.Features.CQRSPattern.Commands.AppUserCommands.RegisterCommands
{
    public class CreateUserRegisterCommandRequest : IRequest<CreateUserRegisterCommandResponse>
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public int PackageId { get; set; }

        [Required]
        public string FullName { get; set; }
    }
}