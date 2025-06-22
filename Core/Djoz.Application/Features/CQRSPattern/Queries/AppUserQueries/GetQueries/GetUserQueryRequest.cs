using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Queries.AppUserQueries.GetQueries
{
    public class GetUserQueryRequest : IRequest<GetUserQueryResponse>
    {
        public int id { get; set; }
    }
}