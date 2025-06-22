using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Commands.BannerCommands.CreateCommands
{
    public class CreateBannerCommandRequest : IRequest<CreateBannerCommandResponse>
    {
        public string ? Title { get; set; }
        public string ? SubTitle { get; set; }
        public string ? Description { get; set; }
    }
}