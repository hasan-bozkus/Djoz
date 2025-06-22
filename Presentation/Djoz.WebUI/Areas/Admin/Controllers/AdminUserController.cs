using Djoz.Application.Features.CQRSPattern.Commands.AppUserCommands.DeleteCommands;
using Djoz.Application.Features.CQRSPattern.Commands.AppUserCommands.UpdateCommands;
using Djoz.Application.Features.CQRSPattern.Queries.AppUserQueries.GetQueries;
using Djoz.Application.Features.CQRSPattern.Queries.AppUserQueries.ListQueries;
using Djoz.Application.Features.CQRSPattern.Queries.PackageQueries.ListQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Djoz.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminUserController : Controller
    {
        private readonly IMediator _mediator;

        public AdminUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(ResultUserListQueryRequest request)
        {
            List<ResultUserListQueryResponse> response = await _mediator.Send(request);
            return View(response);
        }

        public async Task<IActionResult> DeleteUser(DeleteUserCommandRequest request)
        {
            await _mediator.Send(request);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetUser(GetUserQueryRequest request)
        {
            GetUserQueryResponse response = await _mediator.Send(request);

            ResultPackageListQueryRequest packageRequest = new() { };
            List<ResultPackageListQueryResponse> packageList = await _mediator.Send(packageRequest);
            List<SelectListItem> packages = (from x in packageList
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.PackageId.ToString()
                                             }).ToList();
            ViewBag.Packages = packages;

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateUserCommandRequest request)
        {
            if(ModelState.IsValid)
            {
                await _mediator.Send(request);
                return RedirectToAction("Index");
            }
            return NoContent();

        }
    }
}
