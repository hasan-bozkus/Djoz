namespace Djoz.Application.Features.CQRSPattern.Queries.ContactQueries.ListQueries
{
    public class ResultContactListQueryResponse
    {
        public int ContactId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}