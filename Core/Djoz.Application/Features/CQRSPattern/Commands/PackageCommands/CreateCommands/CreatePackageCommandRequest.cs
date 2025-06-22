using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Commands.PackageCommands.CreateCommands
{
    public class CreatePackageCommandRequest : IRequest<CreatePackageCommandResponse>
    {
        public string Name { get; set; }
        public List<int> SongIds { get; set; } = new List<int>();
    }
}