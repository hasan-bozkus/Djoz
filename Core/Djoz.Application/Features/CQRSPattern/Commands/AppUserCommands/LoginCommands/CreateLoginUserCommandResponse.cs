namespace Djoz.Application.Features.CQRSPattern.Commands.AppUserCommands.LoginCommands
{
    public class CreateLoginUserCommandResponse
    {
        public bool Success { get; set; }
        public string Token { get; set; }
    }
}