namespace Djoz.Application.Features.CQRSPattern.Commands.BannerCommands.CreateCommands
{
    public class CreateBannerCommandResponse
    {
        public bool Success { get; set; }
        public List<string>? Errors { get; set; }
        public int? CreatedId { get; set; } // örnek: banner ID
    }
}