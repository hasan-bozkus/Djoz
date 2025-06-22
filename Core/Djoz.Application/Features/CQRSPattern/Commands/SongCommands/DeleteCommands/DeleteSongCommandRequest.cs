using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Commands.SongCommands.DeleteCommands
{
    public class DeleteSongCommandRequest : IRequest<DeleteSongCommandResponse>
    {
        public int id { get; set; }
    }
}