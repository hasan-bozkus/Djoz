using Djoz.Application.Features.CQRSPattern.Commands.BannerCommands.CreateCommands;
using Djoz.Application.Features.CQRSPattern.Commands.BannerCommands.DeleteCommands;
using Djoz.Application.Features.CQRSPattern.Commands.BannerCommands.UpdateCommands;
using Djoz.Application.Features.CQRSPattern.Queries.BannerQueries.GetQueries;
using Djoz.Application.Features.CQRSPattern.Queries.BannerQueries.ListQueries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Djoz.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BannersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> BannerList([FromHeader]ResultBannerListQueryRequest request)
        {
            List<ResultBannerListQueryResponse> respnose = await _mediator.Send(request);
            return Ok(respnose);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner([FromQuery]CreateBannerCommandRequest request)
        {
            CreateBannerCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBanner([FromRoute]GetBannerQueryRequest request)
        {
            GetBannerQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBanner([FromRoute]DeleteBannerCommandRequest request)
        {
            DeleteBannerCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBanner([FromQuery]UpdatSongCommandRequest request)
        {
            UpdateBannerCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
