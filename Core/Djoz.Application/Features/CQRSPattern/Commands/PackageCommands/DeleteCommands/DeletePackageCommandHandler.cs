using Djoz.Application.Features.RepositoryPattern.Abstract.PackageDal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Commands.PackageCommands.DeleteCommands
{
    public class DeletePackageCommandHandler : IRequestHandler<DeletePackageCommandRequest, DeletePackageCommandResponse>
    {
        private readonly IPackageReadDal _packageReadDal;
        private readonly IPackageWriteDal _packageWriteDal;

        public DeletePackageCommandHandler(IPackageReadDal packageReadDal, IPackageWriteDal packageWriteDal)
        {
            _packageReadDal = packageReadDal;
            _packageWriteDal = packageWriteDal;
        }

        public async Task<DeletePackageCommandResponse> Handle(DeletePackageCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _packageReadDal.GetByIdAsync(request.id);
            await _packageWriteDal.DeleteAsync(result);
            await _packageWriteDal.SaveAsync();
            return new();
        }
    }
}
