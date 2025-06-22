namespace Djoz.Application.Features.CQRSPattern.Queries.EventQueries.ListQueries
{
    public class ResultEventListQueryResponse
    {
        public int EventId { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
    }
}