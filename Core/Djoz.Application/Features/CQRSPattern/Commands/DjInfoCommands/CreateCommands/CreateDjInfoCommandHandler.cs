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

namespace Djoz.Application.Features.CQRSPattern.Commands.DjInfoCommands.CreateCommands
{
    public class CreateDjInfoCommandHandler : IRequestHandler<CreateDjInfoCommandRequest, CreateDjInfoCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDjInfoWriteDal _djInfoWriteDal;
        private readonly IValidator<CreateDjInfoCommandRequest> _validator;

        public CreateDjInfoCommandHandler(IMapper mapper, IDjInfoWriteDal djInfoWriteDal, IValidator<CreateDjInfoCommandRequest> validator)
        {
            _mapper = mapper;
            _djInfoWriteDal = djInfoWriteDal;
            _validator = validator;
        }

        public async Task<CreateDjInfoCommandResponse> Handle(CreateDjInfoCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if(!validationResult.IsValid)
            {
                return new CreateDjInfoCommandResponse()
                {
                    Success = false,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            var result = _mapper.Map<DjInfo>(request);
            await _djInfoWriteDal.CreateAsync(result);
            await _djInfoWriteDal.SaveAsync();

            return new()
            {
                Success = true
            };
        }
    }
}
