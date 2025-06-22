using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Commands.EventCommands.DeleteCommands
{
    public class DeleteEventCommandRequest : IRequest<DeleteEventCommandResponse>
    {
        public int id { get; set; }
    }
}