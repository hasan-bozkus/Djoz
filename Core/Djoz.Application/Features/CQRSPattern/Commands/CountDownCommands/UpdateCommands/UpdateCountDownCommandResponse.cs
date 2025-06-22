namespace Djoz.Application.Features.CQRSPattern.Commands.CountDownCommands.UpdateCommands
{
    public class UpdateCountDownCommandResponse
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}