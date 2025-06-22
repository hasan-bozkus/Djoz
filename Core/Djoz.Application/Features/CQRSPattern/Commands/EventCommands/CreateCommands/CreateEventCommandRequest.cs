using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Commands.EventCommands.CreateCommands
{
    public class CreateEventCommandRequest : IRequest<CreateEventCommandResponse>
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
    }
}