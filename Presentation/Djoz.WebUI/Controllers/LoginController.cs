using Azure.Core;
using Djoz.Application.Features.CQRSPattern.Commands.AppUserCommands.LoginCommands;
using Djoz.WebUI.Services.LoginServices;
using Djoz.WebUI.ViewModels.AppUserViewModels;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Djoz.WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateLoginUserCommandRequest request)
        {
            CreateLoginUserCommandResponse response = await _mediator.Send(request);
            if (!string.IsNullOrEmpty(response.Token))
            {
                TempData["Token"] = response.Token; // geçici olarak token'ı taşı
                return RedirectToAction("SaveTokenAndRedirect", "Login");
            }

            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginJson(CreateLoginUserCommandRequest request)
        {
            CreateLoginUserCommandResponse response = await _mediator.Send(request);
            if (!string.IsNullOrEmpty(response.Token))
            {
               
                TempData["Token"] = response.Token; // geçici olarak token'ı taşı
                return Json(new { success = true, response.Token });
            }

            return Json(new { success = false });
        }


        [HttpGet]
        public IActionResult SaveTokenAndRedirect()
        {
            if (TempData["Token"] != null)
            {
                ViewBag.Token = TempData["Token"].ToString();
            }

            return View(); // Bu view'da token'ı js vasıtasıyla localStorage'a yaz ve anasayfaya yönlendir
        }
    }
}
