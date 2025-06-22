using Djoz.Application.Features.CQRSPattern.Queries.DjInfoQueries.ListQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Djoz.WebUI.ViewComponents.UILayoutComponentPartials
{
    public class _UILayoutAboutComponentPartial : ViewComponent
    {
        private readonly IMediator _mediator;

        public _UILayoutAboutComponentPartial(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ResultDjInfoListQueryRequest request = new() { };
            List<ResultDjInfoListQueryResponse> response = await _mediator.Send(request);
            return View(response);
        }
    }
}
