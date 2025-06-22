namespace Djoz.Application.Features.CQRSPattern.Commands.SongCommands.CreateCommands
{
    public class CreateSongCommandResponse
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}