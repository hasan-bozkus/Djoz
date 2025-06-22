using Djoz.Application.Services.AuthenticationServices;
using Djoz.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Commands.AppUserCommands.LoginCommands
{
    public class CreateLoginUserCommandHandler : IRequestHandler<CreateLoginUserCommandRequest, CreateLoginUserCommandResponse>
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IValidator<CreateLoginUserCommandRequest> _validator;
        private readonly IJwtTokenHelper _jwtTokenHelper;

        public CreateLoginUserCommandHandler(SignInManager<AppUser> signInManager, IValidator<CreateLoginUserCommandRequest> validator, IJwtTokenHelper jwtTokenHelper)
        {
            _signInManager = signInManager;
            _validator = validator;
            _jwtTokenHelper = jwtTokenHelper;
        }

        public async Task<CreateLoginUserCommandResponse> Handle(CreateLoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if(!validationResult.IsValid)
            {
                return new CreateLoginUserCommandResponse()
                {
                    Success = false
                };
            }

            var result = await _signInManager.PasswordSignInAsync(request.Username, request.Password, false, true);

            if (result.Succeeded)
            {
                var user = await _signInManager.UserManager.FindByNameAsync(request.Username);

                //  burada token oluşacak
                var token = _jwtTokenHelper.GenerateToken(user);
                var packageIdFromHelper = await _jwtTokenHelper.GetPackageIdFromTokenAsync(token);

                return new CreateLoginUserCommandResponse()
                {
                    Success = true,
                    Token = token
                };
            }
            return new();
        }
    }
}
