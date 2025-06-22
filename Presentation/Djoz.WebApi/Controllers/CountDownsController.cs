using Djoz.Application.Features.CQRSPattern.Commands.CountDownCommands.CreateCommands;
using Djoz.Application.Features.CQRSPattern.Commands.CountDownCommands.DeleteCommands;
using Djoz.Application.Features.CQRSPattern.Commands.CountDownCommands.UpdateCommands;
using Djoz.Application.Features.CQRSPattern.Queries.CountDownQueries.GetQueries;
using Djoz.Application.Features.CQRSPattern.Queries.CountDownQueries.ListQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Djoz.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountDownsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CountDownsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CountDownList([FromHeader] ResultCountDownListQueryRequest request)
        {
            List<ResultCountDownListQueryResponse> respnose = await _mediator.Send(request);
            return Ok(respnose);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCountDown([FromQuery] CreateCountDownCommandRequest request)
        {
            CreateCountDownCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountDown([FromRoute] GetCountDownQueryRequest request)
        {
            GetCountDownQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountDown([FromRoute] DeleteCountDownCommandRequest request)
        {
            DeleteCountDownCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCountDown([FromQuery] UpdateCountDownCommandRequest request)
        {
            UpdateCountDownCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
