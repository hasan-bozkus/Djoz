using Djoz.Application.Features.CQRSPattern.Commands.ContactCommands.CreateCommands;
using Djoz.Application.Features.CQRSPattern.Commands.ContactCommands.DeleteCommands;
using Djoz.Application.Features.CQRSPattern.Commands.ContactCommands.UpdateCommands;
using Djoz.Application.Features.CQRSPattern.Queries.ContactQueries.GetQueries;
using Djoz.Application.Features.CQRSPattern.Queries.ContactQueries.ListQueries;
using Djoz.WebUI.Dtos.ContactDtos;
using Djoz.WebUI.Services.ContactServices;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Djoz.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminContactController : Controller
    {
        private readonly IMediator _mediator;

        public AdminContactController(IMediator contactService)
        {
            _mediator = contactService;
        }

        public async Task<IActionResult> Index(ResultContactListQueryRequest request)
        {
            List<ResultContactListQueryResponse> values = await _mediator.Send(request);
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommandRequest request)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(request);
                return RedirectToAction("Index");
            }
            return NoContent();
        }

        public async Task<IActionResult> DeleteContact(DeleteContactCommandRequest request)
        {
            await _mediator.Send(request);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetContact(GetContactQueryRequest request)
        {
            GetContactQueryResponse values = await _mediator.Send(request);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactCommandRequest request)
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
