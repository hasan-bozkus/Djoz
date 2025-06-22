using Djoz.Application.Features.CQRSPattern.Commands.SongCommands.CreateCommands;
using Djoz.Application.Features.CQRSPattern.Commands.SongCommands.UpdateCommands;
using Djoz.Application.Features.CQRSPattern.Commands.SongCommands.DeleteCommands;
using Djoz.Application.Features.CQRSPattern.Queries.SongQueries.GetQueries;
using Djoz.Application.Features.CQRSPattern.Queries.SongQueries.ListQueries;
using Djoz.WebUI.Dtos.SongDtos;
using Djoz.WebUI.Services.SongServices;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Djoz.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminSongController : Controller
    {
        private readonly IMediator _mediator;

        public AdminSongController(IMediator mediator)
        {
            _mediator = mediator;
        }


        public async Task<IActionResult> Index(ResultSongListQueryRequest request)
        {
            List<ResultSongListQueryResponse> values = await _mediator.Send(request);
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSong()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSong(CreateSongCommandRequest request)
        {
            if(ModelState.IsValid)
            {
                await _mediator.Send(request);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteSong(DeleteSongCommandRequest request)
        {
            await _mediator.Send(request);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetSong(GetSongQueryRequest request)
        {
            var value = await _mediator.Send(request);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSong(UpdateSongCommandRequest request)
        {
            if(ModelState.IsValid)
            {
                await _mediator.Send(request);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
