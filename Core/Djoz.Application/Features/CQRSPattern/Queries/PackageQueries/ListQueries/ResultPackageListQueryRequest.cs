using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Queries.PackageQueries.ListQueries
{
    public class ResultPackageListQueryRequest : IRequest<List<ResultPackageListQueryResponse>>
    {
    }
}