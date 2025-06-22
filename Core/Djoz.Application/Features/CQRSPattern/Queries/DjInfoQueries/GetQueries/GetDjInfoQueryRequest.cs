using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Queries.DjInfoQueries.GetQueries
{
    public class GetDjInfoQueryRequest : IRequest<GetDjInfoQueryResponse>
    {
        public int id { get; set; }
    }
}