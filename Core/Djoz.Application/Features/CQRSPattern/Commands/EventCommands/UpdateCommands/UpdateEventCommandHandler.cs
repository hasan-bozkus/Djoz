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

namespace Djoz.Application.Features.CQRSPattern.Commands.EventCommands.UpdateCommands
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommandRequest, UpdateEventCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEventWriteDal _eventWriteDal;
        private readonly IValidator<UpdateEventCommandRequest> _validator;

        public UpdateEventCommandHandler(IMapper mapper, IEventWriteDal eventWriteDal, IValidator<UpdateEventCommandRequest> validator)
        {
            _mapper = mapper;
            _eventWriteDal = eventWriteDal;
            _validator = validator;
        }

        public async Task<UpdateEventCommandResponse> Handle(UpdateEventCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if(!validationResult.IsValid)
            {
                return new UpdateEventCommandResponse()
                {
                    Success = false,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            var result = _mapper.Map<Event>(request);
            await _eventWriteDal.UpdateAsync(result);
            await _eventWriteDal.SaveAsync();
            return new()
            {
                Success = true
            };
        }
    }
}
