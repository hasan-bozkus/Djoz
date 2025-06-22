using Djoz.Application.Features.CQRSPattern.Queries.CountDownQueries.GetQueries;
using Djoz.Application.Features.CQRSPattern.Queries.CountDownQueries.ListQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Djoz.WebUI.ViewComponents.UILayoutComponentPartials
{
    public class _UILayoutCountDownComponentPartial : ViewComponent
    {
        private readonly IMediator _mediator;

        public _UILayoutCountDownComponentPartial(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            GetCountDownQueryRequest request = new() { id = 1 };
            GetCountDownQueryResponse response = await _mediator.Send(request);
            return View(response);
        }
    }
}
