using Djoz.Application.Features.RepositoryPattern.Abstract.AppUserDal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Commands.AppUserCommands.DeleteCommands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, DeleteUserCommandResponse>
    {
        private readonly IAppUserReadDal _appUserReadDal;
        private readonly IAppUserWriteDal _appUserWriteDal;

        public DeleteUserCommandHandler(IAppUserReadDal appUserReadDal, IAppUserWriteDal appUserWriteDal)
        {
            _appUserReadDal = appUserReadDal;
            _appUserWriteDal = appUserWriteDal;
        }

        public async Task<DeleteUserCommandResponse> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _appUserReadDal.GetByIdAsync(request.id);
            await _appUserWriteDal.DeleteAsync(result);
            await _appUserWriteDal.SaveAsync();
            return new();
        }
    }
}
