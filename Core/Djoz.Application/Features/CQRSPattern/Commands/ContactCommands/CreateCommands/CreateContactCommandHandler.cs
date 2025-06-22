using AutoMapper;
using Djoz.Application.Features.RepositoryPattern.Abstract.ContactDal;
using Djoz.Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Commands.ContactCommands.CreateCommands
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommandRequest, CreateContactCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IContactWriteDal _contactWriteDal;
        private readonly IValidator<CreateContactCommandRequest> _validator;

        public CreateContactCommandHandler(IMapper mapper, IContactWriteDal contactWriteDal, IValidator<CreateContactCommandRequest> validator)
        {
            _mapper = mapper;
            _contactWriteDal = contactWriteDal;
            _validator = validator;
        }

        public async Task<CreateContactCommandResponse> Handle(CreateContactCommandRequest request, CancellationToken cancellationToken)
        {
            var valitorResult = await _validator.ValidateAsync(request);
            if(!valitorResult.IsValid)
            {
                return new CreateContactCommandResponse
                {
                    Success = false,
                    Errors = valitorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var result = _mapper.Map<Contact>(request);
            await _contactWriteDal.CreateAsync(result);
            await _contactWriteDal.SaveAsync();

            return new()
            { 
                Success = true
            };
        }
    }
}
