using Djoz.Application.Features.CQRSPattern.Commands.DjInfoCommands.CreateCommands;
using Djoz.Application.Features.CQRSPattern.Commands.DjInfoCommands.DeleteCommands;
using Djoz.Application.Features.CQRSPattern.Commands.DjInfoCommands.UpdateCommands;
using Djoz.Application.Features.CQRSPattern.Queries.DjInfoQueries.GetQueries;
using Djoz.Application.Features.CQRSPattern.Queries.DjInfoQueries.ListQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Djoz.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DjInfosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DjInfosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> DjInfoList([FromHeader] ResultDjInfoListQueryRequest request)
        {
            List<ResultDjInfoListQueryResponse> respnose = await _mediator.Send(request);
            return Ok(respnose);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDjInfo([FromQuery] CreateDjInfoCommandRequest request)
        {
            CreateDjInfoCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDjInfo([FromRoute] GetDjInfoQueryRequest request)
        {
            GetDjInfoQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDjInfo([FromRoute] DeleteDjInfoCommandRequest request)
        {
            DeleteDjInfoCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDjInfo([FromQuery] UpdateDjInfoCommandRequest request)
        {
            UpdateDjInfoCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
