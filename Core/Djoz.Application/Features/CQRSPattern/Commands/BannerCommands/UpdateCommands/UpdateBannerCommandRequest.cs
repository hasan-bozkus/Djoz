using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Commands.BannerCommands.UpdateCommands
{
    public class UpdatSongCommandRequest : IRequest<UpdateBannerCommandResponse>
    {
        public int BannerId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
    }
}