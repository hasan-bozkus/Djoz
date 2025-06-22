namespace Djoz.Application.Features.CQRSPattern.Commands.SongCommands.UpdateCommands
{
    public class UpdateSongCommandResponse
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}