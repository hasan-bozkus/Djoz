using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Commands.ContactCommands.CreateCommands
{
    public class CreateContactCommandRequest : IRequest<CreateContactCommandResponse>
    {
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}