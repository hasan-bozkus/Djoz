using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Commands.AppUserCommands.DeleteCommands
{
    public class DeleteUserCommandRequest : IRequest<DeleteUserCommandResponse>
    {
        public int id { get; set; }
    }
}