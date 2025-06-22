using Djoz.Application.Features.CQRSPattern.Commands.PackageCommands.CreateCommands;
using Djoz.Application.Features.CQRSPattern.Commands.PackageCommands.DeleteCommands;
using Djoz.Application.Features.CQRSPattern.Commands.PackageCommands.UpdateCommands;
using Djoz.Application.Features.CQRSPattern.Queries.PackageQueries.GetQueries;
using Djoz.Application.Features.CQRSPattern.Queries.PackageQueries.ListQueries;
using Djoz.Application.Features.CQRSPattern.Queries.SongQueries.ListQueries;
using Djoz.WebUI.Dtos.PackageDtos;
using Djoz.WebUI.Services.PackageServices;
using Djoz.WebUI.Services.SongServices;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Djoz.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminPackageController : Controller
    {
        private readonly IMediator _mediator;

        public AdminPackageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(ResultPackageListQueryRequest request)
        {
            List<ResultPackageListQueryResponse> values = await _mediator.Send(request);
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreatePackage(ResultSongListQueryRequest request)
        {
            var sognsList = await _mediator.Send(request);
            List<SelectListItem> selectSongs = (from x in sognsList
                                                select new SelectListItem
                                                {
                                                    Text = x.SongName,
                                                    Value = x.SongId.ToString()
                                                }).ToList();
            ViewBag.songsList = selectSongs;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePackage(CreatePackageCommandRequest request)
        {
            if(ModelState.IsValid)
            {
                await _mediator.Send(request);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeletePackage(DeletePackageCommandRequest request)
        {
            await _mediator.Send(request);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetPackage(GetPackageQueryRequest request)
        {
            var value = await _mediator.Send(request);

            ResultSongListQueryRequest songRequest = new() { };
            List<ResultSongListQueryResponse> songlist = await _mediator.Send(songRequest);
            List<SelectListItem> selectSongs = (from x in songlist
                                                select new SelectListItem
                                                {
                                                    Text = x.SongName,
                                                    Value = x.SongId.ToString()
                                                }).ToList();
            ViewBag.songsList = selectSongs;

            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePackage(UpdatePackageCommandRequest request)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(request);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
