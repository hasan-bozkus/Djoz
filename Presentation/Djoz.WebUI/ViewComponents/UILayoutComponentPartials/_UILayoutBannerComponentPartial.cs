using Djoz.Application.Features.CQRSPattern.Queries.BannerQueries.ListQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Djoz.WebUI.ViewComponents.UILayoutComponentPartials
{
    public class _UILayoutBannerComponentPartial : ViewComponent
    {
        private readonly IMediator _mediator;

        public _UILayoutBannerComponentPartial(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ResultBannerListQueryRequest request = new() { };
            List<ResultBannerListQueryResponse> response = await _mediator.Send(request);
            return View(response);
        }
    }
}
