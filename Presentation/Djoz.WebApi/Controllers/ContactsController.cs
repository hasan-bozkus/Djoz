using Djoz.Application.Features.CQRSPattern.Commands.ContactCommands.CreateCommands;
using Djoz.Application.Features.CQRSPattern.Commands.ContactCommands.DeleteCommands;
using Djoz.Application.Features.CQRSPattern.Commands.ContactCommands.UpdateCommands;
using Djoz.Application.Features.CQRSPattern.Queries.ContactQueries.GetQueries;
using Djoz.Application.Features.CQRSPattern.Queries.ContactQueries.ListQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Djoz.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ContactList([FromHeader] ResultContactListQueryRequest request)
        {
            List<ResultContactListQueryResponse> respnose = await _mediator.Send(request);
            return Ok(respnose);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromQuery] CreateContactCommandRequest request)
        {
            CreateContactCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact([FromRoute] GetContactQueryRequest request)
        {
            GetContactQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact([FromRoute] DeleteContactCommandRequest request)
        {
            DeleteContactCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact([FromQuery] UpdateContactCommandRequest request)
        {
            UpdateContactCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
