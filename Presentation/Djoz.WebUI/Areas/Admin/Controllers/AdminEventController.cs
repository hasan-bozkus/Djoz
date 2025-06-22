using Djoz.Application.Features.CQRSPattern.Commands.EventCommands.CreateCommands;
using Djoz.Application.Features.CQRSPattern.Commands.EventCommands.DeleteCommands;
using Djoz.Application.Features.CQRSPattern.Commands.EventCommands.UpdateCommands;
using Djoz.Application.Features.CQRSPattern.Queries.EventQueries.GetQueries;
using Djoz.Application.Features.CQRSPattern.Queries.EventQueries.ListQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Djoz.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminEventController : Controller
    {
        private readonly IMediator _mediator;

        public AdminEventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(ResultEventListQueryRequest request)
        {
            List<ResultEventListQueryResponse> values = await _mediator.Send(request);
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(CreateEventCommandRequest request)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(request);
                return RedirectToAction("Index");
            }
            return NoContent();
        }

        public async Task<IActionResult> DeleteEvent(DeleteEventCommandRequest request)
        {
            await _mediator.Send(request);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetEvent(GetEventQueryRequest request)
        {
            GetEventQueryResponse values = await _mediator.Send(request);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEvent(UpdateEventCommandRequest request)
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
