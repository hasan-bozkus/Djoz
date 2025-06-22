namespace Djoz.Application.Features.CQRSPattern.Commands.ContactCommands.CreateCommands
{
    public class CreateContactCommandResponse
    {
        public bool Success { get; set; }
        public List<string>? Errors { get; set; }
    }
}