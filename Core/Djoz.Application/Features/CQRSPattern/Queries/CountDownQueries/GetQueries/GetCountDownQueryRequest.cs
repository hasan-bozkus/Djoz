using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Queries.CountDownQueries.GetQueries
{
    public class GetCountDownQueryRequest : IRequest<GetCountDownQueryResponse>
    {
        public int id { get; set; }
    }
}