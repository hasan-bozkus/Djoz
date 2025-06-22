using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Commands.PackageCommands.UpdateCommands
{
    public class UpdatePackageCommandRequest : IRequest<UpdatePackageCommandResponse>
    {
        public int PackageId { get; set; }
        public List<int> SongIds { get; set; }
        public string Name { get; set; }
        public List<string> CurrentSongNames { get; set; } = new List<string>();
    }
}