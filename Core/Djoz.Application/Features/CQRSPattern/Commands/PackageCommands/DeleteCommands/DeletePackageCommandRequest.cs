using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Commands.PackageCommands.DeleteCommands
{
    public class DeletePackageCommandRequest : IRequest<DeletePackageCommandResponse>
    {
        public int id { get; set; }
    }
}