using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Commands.EventCommands.UpdateCommands
{
    public class UpdateEventCommandRequest : IRequest<UpdateEventCommandResponse>
    {
        public int EventId { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
    }
}