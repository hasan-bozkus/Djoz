using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Queries.AppUserQueries.ListQueries
{
    public class ResultUserListQueryRequest : IRequest<List<ResultUserListQueryResponse>>
    {
    }
}