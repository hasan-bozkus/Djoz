using Djoz.Application.Features.CQRSPattern.Commands.AppUserCommands.RegisterCommands;
using Djoz.Application.Features.CQRSPattern.Queries.PackageQueries.ListQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Djoz.WebUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly IMediator _mediator;

        public RegisterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index(ResultPackageListQueryRequest request)
        {
            List<ResultPackageListQueryResponse> response = await _mediator.Send(request);
            List<SelectListItem> packageList = (from x in response
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.PackageId.ToString()
                                                }).TakeLast(3).ToList();

            ViewBag.packageList = packageList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateUserRegisterCommandRequest request)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(request);
                return RedirectToAction("Index", "Login");
            }
            return NoContent();
        }
    }
}
