using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Commands.ContactCommands.UpdateCommands
{
    public class UpdateContactCommandRequest : IRequest<UpdateContactCommandResponse>
    {
        public int ContactId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}