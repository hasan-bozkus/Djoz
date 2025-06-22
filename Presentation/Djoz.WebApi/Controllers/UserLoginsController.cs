using Djoz.Application.Features.CQRSPattern.Commands.AppUserCommands.IdentityLoginCommands;
using Djoz.Application.Features.CQRSPattern.Commands.AppUserCommands.LoginCommands;
using Djoz.Application.Features.CQRSPattern.Commands.AppUserCommands.LogOutCommands;
using Djoz.Application.Features.CQRSPattern.Commands.BannerCommands.CreateCommands;
using Djoz.Application.Services.AuthenticationServices;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Djoz.WebApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserLoginsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin([FromBody] CreateLoginUserCommandRequest request)
        {
            CreateLoginUserCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("IdentityLogin")]
        public async Task<IActionResult> IdentityLogin([FromQuery] IdentityLoginCommandRequest request)
        {
            IdentityLoginCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("LogOut")]
        public async Task<IActionResult> LogOut([FromBody] LogOutCommandRequest request)
        {
            LogOutCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
