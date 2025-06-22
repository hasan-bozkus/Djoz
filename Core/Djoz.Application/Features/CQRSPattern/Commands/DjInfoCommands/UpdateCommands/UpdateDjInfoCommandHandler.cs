using AutoMapper;
using Djoz.Application.Features.RepositoryPattern.Abstract.DjInfoDal;
using Djoz.Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Commands.DjInfoCommands.UpdateCommands
{
    public class UpdateDjInfoCommandHandler : IRequestHandler<UpdateDjInfoCommandRequest, UpdateDjInfoCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDjInfoWriteDal _djInfoWriteDal;
        private readonly IValidator<UpdateDjInfoCommandRequest> _validator;

        public UpdateDjInfoCommandHandler(IMapper mapper, IDjInfoWriteDal djInfoWriteDal, IValidator<UpdateDjInfoCommandRequest> validator)
        {
            _mapper = mapper;
            _djInfoWriteDal = djInfoWriteDal;
            _validator = validator;
        }

        public async Task<UpdateDjInfoCommandResponse> Handle(UpdateDjInfoCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if(!validationResult.IsValid)
            {
                return new UpdateDjInfoCommandResponse()
                {
                    Success = false,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            var result = _mapper.Map<DjInfo>(request);
            await _djInfoWriteDal.UpdateAsync(result);
            await _djInfoWriteDal.SaveAsync();
            return new UpdateDjInfoCommandResponse()
            {
                Success = true
            };
        }
    }
}
