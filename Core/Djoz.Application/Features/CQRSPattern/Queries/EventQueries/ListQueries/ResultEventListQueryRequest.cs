using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Queries.EventQueries.ListQueries
{
    public class ResultEventListQueryRequest : IRequest<List<ResultEventListQueryResponse>>
    {
    }
}