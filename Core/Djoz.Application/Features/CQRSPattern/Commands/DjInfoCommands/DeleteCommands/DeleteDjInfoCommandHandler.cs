using Djoz.Application.Features.RepositoryPattern.Abstract.DjInfoDal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Commands.DjInfoCommands.DeleteCommands
{
    public class DeleteDjInfoCommandHandler : IRequestHandler<DeleteDjInfoCommandRequest, DeleteDjInfoCommandResponse>
    {
        private readonly IDjInfoReadDal _djInfoReadDal;
        private readonly IDjInfoWriteDal _djInfoWriteDal;

        public DeleteDjInfoCommandHandler(IDjInfoReadDal djInfoReadDal, IDjInfoWriteDal djInfoWriteDal)
        {
            _djInfoReadDal = djInfoReadDal;
            _djInfoWriteDal = djInfoWriteDal;
        }

        public async Task<DeleteDjInfoCommandResponse> Handle(DeleteDjInfoCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _djInfoReadDal.GetByIdAsync(request.id);
            await _djInfoWriteDal.DeleteAsync(result);
            await _djInfoWriteDal.SaveAsync();
            return new();
        }
    }
}
