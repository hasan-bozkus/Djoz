namespace Djoz.Application.Features.CQRSPattern.Commands.AppUserCommands.UpdateCommands
{
    public class UpdateUserCommandResponse
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}