using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Queries.BannerQueries.ListQueries
{
    public class ResultBannerListQueryRequest : IRequest<List<ResultBannerListQueryResponse>>
    {
    }
}