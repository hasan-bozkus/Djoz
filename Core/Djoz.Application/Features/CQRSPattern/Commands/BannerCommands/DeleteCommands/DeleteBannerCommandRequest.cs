using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Commands.BannerCommands.DeleteCommands
{
    public class DeleteBannerCommandRequest : IRequest<DeleteBannerCommandResponse>
    {
        public int id { get; set; }
    }
}