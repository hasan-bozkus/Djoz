using Djoz.Application.Features.CQRSPattern.Commands.AppUserCommands.DeleteCommands;
using Djoz.Application.Features.CQRSPattern.Commands.AppUserCommands.UpdateCommands;
using Djoz.Application.Features.CQRSPattern.Queries.AppUserQueries.GetQueries;
using Djoz.Application.Features.CQRSPattern.Queries.AppUserQueries.ListQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace Djoz.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> UserList([FromRoute] ResultUserListQueryRequest request)
        {
            List<ResultUserListQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] GetUserQueryRequest request)
        {
            GetUserQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommandRequest request)
        {
            UpdateUserCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute]DeleteUserCommandRequest request)
        {
            DeleteUserCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
