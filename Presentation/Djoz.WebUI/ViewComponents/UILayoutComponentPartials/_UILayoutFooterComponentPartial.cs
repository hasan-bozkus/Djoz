using Djoz.Application.Features.CQRSPattern.Queries.ContactQueries.ListQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Djoz.WebUI.ViewComponents.UILayoutComponentPartials
{
    public class _UILayoutFooterComponentPartial : ViewComponent
    {
        private readonly IMediator _mediator;

        public _UILayoutFooterComponentPartial(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ResultContactListQueryRequest request = new() { };
            List<ResultContactListQueryResponse> response = await _mediator.Send(request);
            return View(response);
        }
    }
}
