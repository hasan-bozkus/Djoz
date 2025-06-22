using Djoz.Application.Features.CQRSPattern.Commands.BannerCommands.CreateCommands;
using Djoz.Application.Features.CQRSPattern.Commands.BannerCommands.DeleteCommands;
using Djoz.Application.Features.CQRSPattern.Commands.BannerCommands.UpdateCommands;
using Djoz.Application.Features.CQRSPattern.Queries.BannerQueries.GetQueries;
using Djoz.Application.Features.CQRSPattern.Queries.BannerQueries.ListQueries;
using Djoz.WebUI.Dtos.BannerDtos;
using Djoz.WebUI.Services.BannerServices;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Djoz.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminBannerController : Controller
    {
        private readonly IMediator _mediator;

        public AdminBannerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        void GetViewBag()
        {
            ViewBag.directory1 = "Banner";
            ViewBag.directory2 = "Banner";
            ViewBag.directory3 = "Banner Listesi";
        }

        public async Task<IActionResult> Index(ResultBannerListQueryRequest request)
        {
            GetViewBag();
            List<ResultBannerListQueryResponse> response = await _mediator.Send(request);
            return View(response);
        }

        [HttpGet]
        public IActionResult CreateBanner()
        {
            GetViewBag();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommandRequest request)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(request);
                return RedirectToAction("Index");
            }
            return NoContent();
        }

        public async Task<IActionResult> DeleteBanner(DeleteBannerCommandRequest request)
        {
            await _mediator.Send(request);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetBanner(GetBannerQueryRequest request)
        {
            GetViewBag();
            GetBannerQueryResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdatSongCommandRequest request)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(request);
                return RedirectToAction("Index");
            }
            return NoContent();
        }
    }
}
