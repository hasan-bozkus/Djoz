using Djoz.Application.Features.CQRSPattern.Commands.PackageCommands.CreateCommands;
using Djoz.Application.Features.CQRSPattern.Commands.PackageCommands.DeleteCommands;
using Djoz.Application.Features.CQRSPattern.Commands.PackageCommands.UpdateCommands;
using Djoz.Application.Features.CQRSPattern.Queries.PackageQueries.GetQueries;
using Djoz.Application.Features.CQRSPattern.Queries.PackageQueries.ListQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Djoz.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PackagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> PackageList([FromQuery]ResultPackageListQueryRequest request)
        {
            List<ResultPackageListQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePackage([FromQuery]CreatePackageCommandRequest request)
        {
            //validation yapılacak
            CreatePackageCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackage([FromRoute]DeletePackageCommandRequest request)
        {
            DeletePackageCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPackage([FromRoute]GetPackageQueryRequest request)
        {
            GetPackageQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePackage([FromQuery]UpdatePackageCommandRequest request)
        {
            UpdatePackageCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
