namespace Djoz.Application.Features.CQRSPattern.Queries.CountDownQueries.GetQueries
{
    public class GetCountDownQueryResponse
    {
        public int CountDownId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public DateTime Date { get; set; }
    }
}