using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Queries.EventQueries.GetQueries
{
    public class GetEventQueryRequest : IRequest<GetEventQueryResponse>
    {
        public int id { get; set; }
    }
}