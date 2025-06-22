using Djoz.Application.Features.RepositoryPattern.Abstract.CountDownDal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Commands.CountDownCommands.DeleteCommands
{
    public class DeleteCountDownCommandHandler : IRequestHandler<DeleteCountDownCommandRequest, DeleteCountDownCommandResponse>
    {
        private readonly ICountDownReadDal _countDownReadDal;
        private readonly ICoutDownWriteDal _countDownWriteDal;

        public DeleteCountDownCommandHandler(ICountDownReadDal countDownReadDal, ICoutDownWriteDal countDownWriteDal)
        {
            _countDownReadDal = countDownReadDal;
            _countDownWriteDal = countDownWriteDal;
        }

        public async Task<DeleteCountDownCommandResponse> Handle(DeleteCountDownCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _countDownReadDal.GetByIdAsync(request.id);
            await _countDownWriteDal.DeleteAsync(result);
            await _countDownWriteDal.SaveAsync();
            return new ();
        }
    }
}
