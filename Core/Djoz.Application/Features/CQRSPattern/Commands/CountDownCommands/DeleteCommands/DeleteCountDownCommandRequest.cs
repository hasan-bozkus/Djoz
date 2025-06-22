using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Commands.CountDownCommands.DeleteCommands
{
    public class DeleteCountDownCommandRequest : IRequest<DeleteCountDownCommandResponse>
    {
        public int id { get; set; }
    }
}