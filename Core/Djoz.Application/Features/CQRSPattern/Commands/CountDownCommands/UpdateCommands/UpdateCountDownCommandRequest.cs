using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Commands.CountDownCommands.UpdateCommands
{
    public class UpdateCountDownCommandRequest : IRequest<UpdateCountDownCommandResponse>
    {
        public int CountDownId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public DateTime Date { get; set; }
    }
}