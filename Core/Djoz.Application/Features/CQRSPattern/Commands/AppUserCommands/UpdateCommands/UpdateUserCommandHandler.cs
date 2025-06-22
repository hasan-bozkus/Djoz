using AutoMapper;
using Djoz.Application.Features.RepositoryPattern.Abstract.AppUserDal;
using Djoz.Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Commands.AppUserCommands.UpdateCommands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAppUserWriteDal _appUserWriteDal;
        private readonly IAppUserReadDal _appUserReadDal;
        private readonly IValidator<UpdateUserCommandRequest> _validator;

        public UpdateUserCommandHandler(IMapper mapper, IAppUserWriteDal appUserWriteDal, IValidator<UpdateUserCommandRequest> validator, IAppUserReadDal appUserReadDal)
        {
            _mapper = mapper;
            _appUserWriteDal = appUserWriteDal;
            _validator = validator;
            _appUserReadDal = appUserReadDal;
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if(!validationResult.IsValid)
            {
                return new UpdateUserCommandResponse
                {
                    Success = false,
                    Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var user = await _appUserReadDal.GetByIdAsync(request.Id);

            user.Id = request.Id;
            user.FullName = request.FullName;
            user.PackageId = request.PackageId;

            var result = _mapper.Map<AppUser>(user);
            await _appUserWriteDal.UpdateAsync(result);
            await _appUserWriteDal.SaveAsync();

            return new UpdateUserCommandResponse
            {
                Success = true,
            };
        }
    }
}
