using Djoz.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Commands.AppUserCommands.LogOutCommands
{
    public class LogOutCommandHandler : IRequestHandler<LogOutCommandRequest, LogOutCommandResponse>
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LogOutCommandHandler(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<LogOutCommandResponse> Handle(LogOutCommandRequest request, CancellationToken cancellationToken)
        {
            await _signInManager.SignOutAsync();    
            return new();
        }
    }
}
