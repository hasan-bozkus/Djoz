using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Queries.ContactQueries.GetQueries
{
    public class GetContactQueryRequest : IRequest<GetContactQueryResponse>
    {
        public int id { get; set; }
    }
}