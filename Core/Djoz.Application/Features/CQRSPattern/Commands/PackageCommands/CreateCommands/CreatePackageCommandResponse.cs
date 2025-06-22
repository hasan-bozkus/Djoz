namespace Djoz.Application.Features.CQRSPattern.Commands.PackageCommands.CreateCommands
{
    public class CreatePackageCommandResponse
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}