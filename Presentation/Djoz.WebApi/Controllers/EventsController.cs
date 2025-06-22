using Djoz.Application.Features.CQRSPattern.Commands.EventCommands.CreateCommands;
using Djoz.Application.Features.CQRSPattern.Commands.EventCommands.DeleteCommands;
using Djoz.Application.Features.CQRSPattern.Commands.EventCommands.UpdateCommands;
using Djoz.Application.Features.CQRSPattern.Queries.EventQueries.GetQueries;
using Djoz.Application.Features.CQRSPattern.Queries.EventQueries.ListQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Djoz.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> EventList([FromHeader] ResultEventListQueryRequest request)
        {
            List<ResultEventListQueryResponse> respnose = await _mediator.Send(request);
            return Ok(respnose);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromQuery] CreateEventCommandRequest request)
        {
            CreateEventCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent([FromRoute] GetEventQueryRequest request)
        {
            GetEventQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent([FromRoute] DeleteEventCommandRequest request)
        {
            DeleteEventCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEvent([FromQuery] UpdateEventCommandRequest request)
        {
            UpdateEventCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
