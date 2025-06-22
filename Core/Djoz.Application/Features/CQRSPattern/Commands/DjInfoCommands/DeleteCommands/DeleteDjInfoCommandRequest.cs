using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Commands.DjInfoCommands.DeleteCommands
{
    public class DeleteDjInfoCommandRequest : IRequest<DeleteDjInfoCommandResponse>
    {
        public int id { get; set; }
    }
}