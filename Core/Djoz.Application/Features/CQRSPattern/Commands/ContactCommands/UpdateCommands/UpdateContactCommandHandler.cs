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

namespace Djoz.Application.Features.CQRSPattern.Commands.ContactCommands.UpdateCommands
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommandRequest, UpdateContactCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IContactWriteDal _contactWriteDal;
        private readonly IValidator<UpdateContactCommandRequest> _validator;

        public UpdateContactCommandHandler(IMapper mapper, IContactWriteDal contactWriteDal, IValidator<UpdateContactCommandRequest> validator)
        {
            _mapper = mapper;
            _contactWriteDal = contactWriteDal;
            _validator = validator;
        }

        public async Task<UpdateContactCommandResponse> Handle(UpdateContactCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return new UpdateContactCommandResponse()
                {
                    Success = false,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            var result = _mapper.Map<Contact>(request);
            await _contactWriteDal.UpdateAsync(result);
            await _contactWriteDal.SaveAsync();

            return new()
            {
                Success = true
            };
        }
    }
}
