using Djoz.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Commands.AppUserCommands.IdentityLoginCommands
{
    public class IdentityLoginCommandHandler : IRequestHandler<IdentityLoginCommandRequest, IdentityLoginCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public IdentityLoginCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityLoginCommandResponse> Handle(IdentityLoginCommandRequest request, CancellationToken cancellationToken)
        {

            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
                if (result.Succeeded)
                {
                    var roles = await _userManager.GetRolesAsync(user);

                    if (roles.Contains("Admin"))
                        return new IdentityLoginCommandResponse()
                        { Success = true, Message = "Giriş başarılı" };
                    else
                        return new IdentityLoginCommandResponse()
                        { Success = false, Message =  "Kullanıcı adı veya şifre hatalı"};
                }
            }

            return new IdentityLoginCommandResponse()
            { Success = false, Message = "Kullanıcı adı veya şifre hatalı" };
        }
    }
}
