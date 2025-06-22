using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Commands.DjInfoCommands.CreateCommands
{
    public class CreateDjInfoCommandRequest : IRequest<CreateDjInfoCommandResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}