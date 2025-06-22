using Djoz.Application.Features.CQRSPattern.Commands.DjInfoCommands.CreateCommands;
using Djoz.Application.Features.CQRSPattern.Commands.DjInfoCommands.DeleteCommands;
using Djoz.Application.Features.CQRSPattern.Commands.DjInfoCommands.UpdateCommands;
using Djoz.Application.Features.CQRSPattern.Queries.DjInfoQueries.GetQueries;
using Djoz.Application.Features.CQRSPattern.Queries.DjInfoQueries.ListQueries;
using Djoz.WebUI.Dtos.DjInfoDtos;
using Djoz.WebUI.Services.DjInfoServices;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Djoz.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminDjInfoController : Controller
    {
        private readonly IMediator _mediator;

        public AdminDjInfoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(ResultDjInfoListQueryRequest request)
        {
            List<ResultDjInfoListQueryResponse> values = await _mediator.Send(request);
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateDjInfo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDjInfo(CreateDjInfoCommandRequest request)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(request);
                return RedirectToAction("Index");
            }
            return NoContent();
        }

        public async Task<IActionResult> DeleteDjInfo(DeleteDjInfoCommandRequest request)
        {
            await _mediator.Send(request);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetDjInfo(GetDjInfoQueryRequest request)
        {
            GetDjInfoQueryResponse values = await _mediator.Send(request);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDjInfo(UpdateDjInfoCommandRequest request)
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
