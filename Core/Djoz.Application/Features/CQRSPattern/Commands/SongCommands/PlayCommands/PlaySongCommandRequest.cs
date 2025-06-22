using Djoz.Application.Features.CQRSPattern.Commands.BannerCommands.CreateCommands;
using MediatR;
namespace Djoz.Application.Features.CQRSPattern.Commands.SongCommands.PlayCommands
{
    public class PlaySongCommandRequest : IRequest<PlaySongCommandResponse>
    {
        public string SongUrl { get; set; }
    }
}