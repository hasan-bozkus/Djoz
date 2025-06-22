using Djoz.Application.Features.CQRSPattern.Commands.SongCommands.CreateCommands;
using Djoz.Application.Features.CQRSPattern.Commands.SongCommands.DeleteCommands;
using Djoz.Application.Features.CQRSPattern.Commands.SongCommands.PlayCommands;
using Djoz.Application.Features.CQRSPattern.Commands.SongCommands.UpdateCommands;
using Djoz.Application.Features.CQRSPattern.Queries.SongQueries.GetQueries;
using Djoz.Application.Features.CQRSPattern.Queries.SongQueries.ListQueries;
using Djoz.Application.Services.AuthenticationServices;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Djoz.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IJwtTokenHelper _jwtTokenHelper;

        public SongsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> SongList([FromQuery]ResultSongListQueryRequest request)
        {
            List<ResultSongListQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSong([FromQuery]CreateSongCommandRequest request)
        {
            CreateSongCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong([FromRoute]DeleteSongCommandRequest request)
        {
            DeleteSongCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSong([FromRoute]GetSongQueryRequest request)
        {
            GetSongQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSong([FromQuery]UpdateSongCommandRequest request)
        {
            UpdateSongCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("PlaySong")]
        public async Task<IActionResult> PlaySong([FromBody]PlaySongCommandRequest request)
        {
            //var authHeader = HttpContext.Request?.Headers["Authorization"].FirstOrDefault(); // en son buaryı düzelt           


            // ~/songs/suspus_ceza_85a9d543-1e32-47e9-8fef-a76f2a9dbed1.mp3
            PlaySongCommandResponse response = await _mediator.Send(request);

            //if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
            //    return Ok(new { Success = false, Message = "Yetkilendirme başlığı eksik." });

            //var token = authHeader.Substring("Bearer ".Length).Trim();
            //var userPackageId = await _jwtTokenHelper.GetPackageIdFromTokenAsync(token);
            //request.Token = userPackageId.ToString();

            //if (userPackageId == null)
            //    return Ok(new { Success = false, Message = "Giriş yapmanız gerekiyor." });

            return Ok(response);
        }

    }
}
