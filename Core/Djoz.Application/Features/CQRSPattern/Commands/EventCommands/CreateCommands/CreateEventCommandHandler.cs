using AutoMapper;
using Djoz.Application.Features.RepositoryPattern.Abstract.EventDal;
using Djoz.Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Commands.EventCommands.CreateCommands
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommandRequest, CreateEventCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEventWriteDal _eventWriteDal;
        private readonly IValidator<CreateEventCommandRequest> _validator;

        public CreateEventCommandHandler(IMapper mapper, IEventWriteDal eventWriteDal, IValidator<CreateEventCommandRequest> validator)
        {
            _mapper = mapper;
            _eventWriteDal = eventWriteDal;
            _validator = validator;
        }

        public async Task<CreateEventCommandResponse> Handle(CreateEventCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if(!validationResult.IsValid)
            {
                return new CreateEventCommandResponse()
                {
                    Success = false,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            var result = _mapper.Map<Event>(request);
            await _eventWriteDal.CreateAsync(result);
            await _eventWriteDal.SaveAsync();
            return new()
            {
                Success = true
            };
        }
    }
}
