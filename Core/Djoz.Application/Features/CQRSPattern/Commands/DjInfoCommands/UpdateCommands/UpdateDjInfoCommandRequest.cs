using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Commands.DjInfoCommands.UpdateCommands
{
    public class UpdateDjInfoCommandRequest : IRequest<UpdateDjInfoCommandResponse>
    {
        public int DjInfoId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}