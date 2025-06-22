namespace Djoz.Application.Features.CQRSPattern.Commands.DjInfoCommands.CreateCommands
{
    public class CreateDjInfoCommandResponse
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}