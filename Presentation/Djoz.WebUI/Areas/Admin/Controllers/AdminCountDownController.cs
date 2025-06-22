using Djoz.Application.Features.CQRSPattern.Commands.CountDownCommands.CreateCommands;
using Djoz.Application.Features.CQRSPattern.Commands.CountDownCommands.DeleteCommands;
using Djoz.Application.Features.CQRSPattern.Commands.CountDownCommands.UpdateCommands;
using Djoz.Application.Features.CQRSPattern.Queries.CountDownQueries.GetQueries;
using Djoz.Application.Features.CQRSPattern.Queries.CountDownQueries.ListQueries;
using Djoz.WebUI.Dtos.CountDownDtos;
using Djoz.WebUI.Services.CountDownServices;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Djoz.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCountDownController : Controller
    {
        private readonly IMediator _mediator;

        public AdminCountDownController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(ResultCountDownListQueryRequest request)
        {
            List<ResultCountDownListQueryResponse> values = await _mediator.Send(request);
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateCountDown()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCountDown(CreateCountDownCommandRequest request)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(request);
                return RedirectToAction("Index");
            }
            return NoContent();
        }

        public async Task<IActionResult> DeleteCountDown(DeleteCountDownCommandRequest request)
        {
            await _mediator.Send(request);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetCountDown(GetCountDownQueryRequest request)
        {
            GetCountDownQueryResponse values = await _mediator.Send(request);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCountDown(UpdateCountDownCommandRequest request)
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
