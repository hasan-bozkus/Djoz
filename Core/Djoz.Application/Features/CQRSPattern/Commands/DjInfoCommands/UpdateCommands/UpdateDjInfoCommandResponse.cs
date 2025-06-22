namespace Djoz.Application.Features.CQRSPattern.Commands.DjInfoCommands.UpdateCommands
{
    public class UpdateDjInfoCommandResponse
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}