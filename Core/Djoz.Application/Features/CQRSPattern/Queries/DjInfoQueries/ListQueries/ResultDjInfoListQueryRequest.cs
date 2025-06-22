using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Queries.DjInfoQueries.ListQueries
{
    public class ResultDjInfoListQueryRequest : IRequest<List<ResultDjInfoListQueryResponse>>
    {
    }
}