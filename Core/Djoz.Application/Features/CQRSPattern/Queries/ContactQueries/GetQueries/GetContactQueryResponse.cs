namespace Djoz.Application.Features.CQRSPattern.Queries.ContactQueries.GetQueries
{
    public class GetContactQueryResponse
    {
        public int ContactId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}