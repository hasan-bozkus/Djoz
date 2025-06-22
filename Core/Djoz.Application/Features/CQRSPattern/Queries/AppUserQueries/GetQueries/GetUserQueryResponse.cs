namespace Djoz.Application.Features.CQRSPattern.Queries.AppUserQueries.GetQueries
{
    public class GetUserQueryResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int? PackageId { get; set; }
    }
}