using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Commands.AppUserCommands.LogOutCommands
{
    public class LogOutCommandRequest : IRequest<LogOutCommandResponse>
    {
    }
}