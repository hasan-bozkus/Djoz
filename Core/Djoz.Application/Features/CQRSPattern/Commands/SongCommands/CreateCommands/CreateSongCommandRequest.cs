using Djoz.Application.Features.CQRSPattern.Commands.BannerCommands.CreateCommands;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Djoz.Application.Features.CQRSPattern.Commands.SongCommands.CreateCommands
{
    public class CreateSongCommandRequest : IRequest<CreateSongCommandResponse>
    {
        public string SongName { get; set; }
        public string Singer { get; set; }
        public IFormFile SongFile { get; set; }
    }
}