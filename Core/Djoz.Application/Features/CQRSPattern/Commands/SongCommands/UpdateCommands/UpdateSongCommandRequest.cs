using MediatR;
using Microsoft.AspNetCore.Http;

namespace Djoz.Application.Features.CQRSPattern.Commands.SongCommands.UpdateCommands
{
    public class UpdateSongCommandRequest : IRequest<UpdateSongCommandResponse>
    {
        public int SongId { get; set; }
        public string SongName { get; set; }
        public string Singer { get; set; }
        public IFormFile? SongFile { get; set; }
        public string? SongUrl { get; set; } //mevcut dosya yolu
    }
}