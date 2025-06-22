using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Queries.PackageQueries.GetQueries
{
    public class GetPackageQueryRequest : IRequest<GetPackageQueryResponse>
    {
        public int id { get; set; }
    }
}