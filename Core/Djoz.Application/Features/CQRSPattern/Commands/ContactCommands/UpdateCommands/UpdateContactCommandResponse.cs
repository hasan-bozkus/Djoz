namespace Djoz.Application.Features.CQRSPattern.Commands.ContactCommands.UpdateCommands
{
    public class UpdateContactCommandResponse
    {
        public bool Success { get; set; }
        public List<string>? Errors { get; set; }
    }
}