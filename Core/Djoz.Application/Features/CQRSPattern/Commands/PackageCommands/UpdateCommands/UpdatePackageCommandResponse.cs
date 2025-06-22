namespace Djoz.Application.Features.CQRSPattern.Commands.PackageCommands.UpdateCommands
{
    public class UpdatePackageCommandResponse
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}