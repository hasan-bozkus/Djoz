using AutoMapper;
using Djoz.Application.Features.CQRSPattern.Commands.SongCommands.PlayCommands;
using Djoz.Application.Services.AuthenticationServices;
using Djoz.WebUI.Dtos.SongDtos;
using Djoz.WebUI.Services.SongServices;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Djoz.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongAccessController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IJwtTokenHelper _jwtTokenHelper;

        public SongAccessController(IMediator mediator, IJwtTokenHelper jwtTokenHelper)
        {
            _mediator = mediator;
            _jwtTokenHelper = jwtTokenHelper;
        }

        [HttpPost]
        public async Task<IActionResult> PlaySong(PlaySongCommandRequest request)
        {
            var songUrl = request.SongUrl?.Replace("~", "").TrimStart('/');
            // ~ karakterini temizle
            var authHeader = Request.Headers["Authorization"].FirstOrDefault();

            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
                return Unauthorized(new { success = false, message = "Yetkilendirme başlığı eksik." });

            var token = authHeader.Substring("Bearer ".Length).Trim();
            var userPackageId = await _jwtTokenHelper.GetPackageIdFromTokenAsync(token);

            if (userPackageId == null)
                return Unauthorized(new { success = false, message = "Giriş yapmanız gerekiyor." });

            request.SongUrl = songUrl;
            PlaySongCommandResponse response = await _mediator.Send(request);

            var songDto = response;

            if (songDto.CanPlay(userPackageId.Value))
            {
                return Ok(new { success = true, message = "Şarkı çalınıyor!" });
            }

            return BadRequest(new { success = false, message = "Pakete dahil olmayan şarkı." });
        }
    }
}
