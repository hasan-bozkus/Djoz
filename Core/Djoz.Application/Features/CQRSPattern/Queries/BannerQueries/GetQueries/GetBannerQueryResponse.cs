namespace Djoz.Application.Features.CQRSPattern.Queries.BannerQueries.GetQueries
{
    public class GetBannerQueryResponse
    {
        public int BannerId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
    }
}