using Djoz.Application.Features.RepositoryPattern.Abstract.AppUserDal;
using Djoz.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Commands.AppUserCommands.RegisterCommands
{
    public class CreateUserRegisterCommandHandler : IRequestHandler<CreateUserRegisterCommandRequest, CreateUserRegisterCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserWriteDal _appUserWriteDal;
        private readonly IValidator<CreateUserRegisterCommandRequest> _validator;

        public CreateUserRegisterCommandHandler(UserManager<AppUser> userManager, IAppUserWriteDal appUserWriteDal, IValidator<CreateUserRegisterCommandRequest> validator)
        {
            _userManager = userManager;
            _appUserWriteDal = appUserWriteDal;
            _validator = validator;
        }

        public async Task<CreateUserRegisterCommandResponse> Handle(CreateUserRegisterCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return new CreateUserRegisterCommandResponse
                {
                    Success = false
                };
            }

            var user = new AppUser
            {
                UserName = request.Username,
                FullName = request.FullName,
                PackageId = request.PackageId
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                return new CreateUserRegisterCommandResponse() { Success = true };
            }

            return new();
        }
    }
}
