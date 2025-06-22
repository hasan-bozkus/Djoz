namespace Djoz.Application.Features.CQRSPattern.Queries.AppUserQueries.ListQueries
{
    public class ResultUserListQueryResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int PackageId { get; set; }
        public string PackageName { get; set; }
    }
}