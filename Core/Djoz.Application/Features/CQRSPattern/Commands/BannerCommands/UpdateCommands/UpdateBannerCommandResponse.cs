namespace Djoz.Application.Features.CQRSPattern.Commands.BannerCommands.UpdateCommands
{
    public class UpdateBannerCommandResponse
    {
        public bool Success { get; set; }
        public List<string>? Errors { get; set; }
    }
}