using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Commands.AppUserCommands.IdentityLoginCommands
{
    public class IdentityLoginCommandRequest : IRequest<IdentityLoginCommandResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}