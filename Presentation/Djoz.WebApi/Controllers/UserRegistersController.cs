using Djoz.Application.Features.CQRSPattern.Commands.AppUserCommands.RegisterCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Djoz.WebApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserRegistersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister([FromQuery]CreateUserRegisterCommandRequest request)
        {
            CreateUserRegisterCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
