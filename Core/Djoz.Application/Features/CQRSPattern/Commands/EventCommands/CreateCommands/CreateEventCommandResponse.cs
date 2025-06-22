namespace Djoz.Application.Features.CQRSPattern.Commands.EventCommands.CreateCommands
{
    public class CreateEventCommandResponse
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}