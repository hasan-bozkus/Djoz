using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Queries.ContactQueries.ListQueries
{
    public class ResultContactListQueryRequest : IRequest<List<ResultContactListQueryResponse>>
    {
    }
}