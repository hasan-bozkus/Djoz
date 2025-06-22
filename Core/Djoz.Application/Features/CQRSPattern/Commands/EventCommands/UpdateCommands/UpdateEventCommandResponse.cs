namespace Djoz.Application.Features.CQRSPattern.Commands.EventCommands.UpdateCommands
{
    public class UpdateEventCommandResponse
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}