using Djoz.Application.Features.RepositoryPattern.Abstract.ContactDal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Commands.ContactCommands.DeleteCommands
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommandRequest, DeleteContactCommandResponse>
    {
        private readonly IContactReadDal _contactReadDal;
        private readonly IContactWriteDal _contactWriteDal;

        public DeleteContactCommandHandler(IContactReadDal contactReadDal, IContactWriteDal contactWriteDal)
        {
            _contactReadDal = contactReadDal;
            _contactWriteDal = contactWriteDal;
        }

        public async Task<DeleteContactCommandResponse> Handle(DeleteContactCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _contactReadDal.GetByIdAsync(request.id);
            await _contactWriteDal.DeleteAsync(result);
            await _contactWriteDal.SaveAsync();
            return new ();
        }
    }
}
