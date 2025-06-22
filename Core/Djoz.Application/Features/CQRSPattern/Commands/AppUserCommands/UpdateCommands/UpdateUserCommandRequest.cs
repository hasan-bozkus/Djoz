using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Commands.AppUserCommands.UpdateCommands
{
    public class UpdateUserCommandRequest : IRequest<UpdateUserCommandResponse>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int PackageId { get; set; }
    }
}