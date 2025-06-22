using Djoz.Application.Features.CQRSPattern.Queries.SongQueries.ListQueries;
using Djoz.WebUI.Services.SongServices;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Djoz.WebUI.ViewComponents.UILayoutComponentPartials
{
    public class _UILayoutSongComponentPartial : ViewComponent
    {
        private readonly IMediator _mediator;

        public _UILayoutSongComponentPartial(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ResultSongListQueryRequest request = new(){
                 };
            List<ResultSongListQueryResponse>? response = await _mediator?.Send(request);
            return View(response);
        }
    }
}
