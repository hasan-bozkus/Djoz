using AutoMapper;
using Djoz.Application.Features.RepositoryPattern.Abstract.CountDownDal;
using Djoz.Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Commands.CountDownCommands.UpdateCommands
{
    public class UpdateCountDownCommandHandler : IRequestHandler<UpdateCountDownCommandRequest, UpdateCountDownCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICoutDownWriteDal _countDownWriteDal;
        private readonly IValidator<UpdateCountDownCommandRequest> _validator;

        public UpdateCountDownCommandHandler(IMapper mapper, ICoutDownWriteDal countDownWriteDal, IValidator<UpdateCountDownCommandRequest> validator)
        {
            _mapper = mapper;
            _countDownWriteDal = countDownWriteDal;
            _validator = validator;
        }

        public async Task<UpdateCountDownCommandResponse> Handle(UpdateCountDownCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if(!validationResult.IsValid)
            {
                return new UpdateCountDownCommandResponse()
                {
                    Success = true,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            var result = _mapper.Map<CountDown>(request);
            await _countDownWriteDal.UpdateAsync(result);
            await _countDownWriteDal.SaveAsync();

            return new()
            {
                Success = true
            };
        }
    }
}
