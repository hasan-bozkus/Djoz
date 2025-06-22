namespace Djoz.Application.Features.CQRSPattern.Queries.PackageQueries.GetQueries
{
    public class GetPackageQueryResponse
    {
        public int PackageId { get; set; }
        public List<int> SongIds { get; set; }
        public string Name { get; set; }
        public List<string> CurrentSongNames { get; set; } = new List<string>();
    }
}