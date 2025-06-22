namespace Djoz.Application.Features.CQRSPattern.Queries.BannerQueries.ListQueries
{
    public class ResultBannerListQueryResponse
    {
        public int BannerId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
    }
}