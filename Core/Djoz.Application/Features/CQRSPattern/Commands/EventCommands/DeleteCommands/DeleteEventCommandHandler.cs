using Djoz.Application.Features.RepositoryPattern.Abstract.EventDal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Commands.EventCommands.DeleteCommands
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommandRequest, DeleteEventCommandResponse>
    {
        private readonly IEventReadDal _eventReadDal;
        private readonly IEventWriteDal _eventWriteDal;

        public DeleteEventCommandHandler(IEventReadDal eventReadDal, IEventWriteDal eventWriteDal)
        {
            _eventReadDal = eventReadDal;
            _eventWriteDal = eventWriteDal;
        }

        public async Task<DeleteEventCommandResponse> Handle(DeleteEventCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _eventReadDal.GetByIdAsync(request.id);
            await _eventWriteDal.DeleteAsync(result);
            await _eventWriteDal.SaveAsync();
            return new(); 
        }
    }
}
