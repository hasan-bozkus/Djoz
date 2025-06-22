using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Commands.ContactCommands.DeleteCommands
{
    public class DeleteContactCommandRequest : IRequest<DeleteContactCommandResponse>
    {
        public int id { get; set; }
    }
}