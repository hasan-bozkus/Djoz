using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Commands.CountDownCommands.CreateCommands
{
    public class CreateCountDownCommandRequest : IRequest<CreateCountDownCommandResponse>
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public DateTime Date { get; set; }
    }
}