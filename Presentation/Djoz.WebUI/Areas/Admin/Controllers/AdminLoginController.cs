using Djoz.Application.Features.CQRSPattern.Commands.AppUserCommands.IdentityLoginCommands;
using Djoz.Application.Features.CQRSPattern.Commands.AppUserCommands.LogOutCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Djoz.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class AdminLoginController : Controller
    {
        private readonly IMediator _mediator;

        public AdminLoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IdentityLoginCommandRequest request)
        {
            IdentityLoginCommandResponse response = await _mediator.Send(request);
            return RedirectToAction("Index", "AdminSong");
        }

        public async Task<IActionResult> LogOut(LogOutCommandRequest request)
        {
            await _mediator.Send(request);
            return RedirectToAction("Index");
        }
    }
}
