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

namespace Djoz.Application.Features.CQRSPattern.Commands.CountDownCommands.CreateCommands
{
    public class CreateCountDownCommandHandler : IRequestHandler<CreateCountDownCommandRequest, CreateCountDownCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IValidator<CreateCountDownCommandRequest> _validator;
        private readonly ICoutDownWriteDal _countDownWriteDal;

        public CreateCountDownCommandHandler(IMapper mapper, IValidator<CreateCountDownCommandRequest> validator, ICoutDownWriteDal countDownWriteDal)
        {
            _mapper = mapper;
            _validator = validator;
            _countDownWriteDal = countDownWriteDal;
        }

        public async Task<CreateCountDownCommandResponse> Handle(CreateCountDownCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if(!validationResult.IsValid)
            {
                return new CreateCountDownCommandResponse
                {
                    Success = false,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            var result = _mapper.Map<CountDown>(request);
            await _countDownWriteDal.CreateAsync(result);
            await _countDownWriteDal.SaveAsync();
            return new CreateCountDownCommandResponse()
            {
                Success = true
            };
        }
    }
}
