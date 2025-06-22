using Djoz.Application.Features.CQRSPattern.Queries.EventQueries.ListQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Djoz.WebUI.ViewComponents.UILayoutComponentPartials
{
    public class _UILayoutEventComponentPartial : ViewComponent
    {
        private readonly IMediator _mediator;

        public _UILayoutEventComponentPartial(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ResultEventListQueryRequest request = new() { };
            List<ResultEventListQueryResponse> response = await _mediator.Send(request);

            return View(response);
        }
    }
}
