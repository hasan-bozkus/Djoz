using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Queries.CountDownQueries.ListQueries
{
    public class ResultCountDownListQueryRequest : IRequest<List<ResultCountDownListQueryResponse>>
    {
    }
}