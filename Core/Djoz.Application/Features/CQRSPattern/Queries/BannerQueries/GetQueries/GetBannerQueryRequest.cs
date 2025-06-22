using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Queries.BannerQueries.GetQueries
{
    public class GetBannerQueryRequest : IRequest<GetBannerQueryResponse>
    {
        public int id { get; set; }
    }
}