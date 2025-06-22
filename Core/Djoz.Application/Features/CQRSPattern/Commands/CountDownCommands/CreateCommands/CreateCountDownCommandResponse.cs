namespace Djoz.Application.Features.CQRSPattern.Commands.CountDownCommands.CreateCommands
{
    public class CreateCountDownCommandResponse
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}