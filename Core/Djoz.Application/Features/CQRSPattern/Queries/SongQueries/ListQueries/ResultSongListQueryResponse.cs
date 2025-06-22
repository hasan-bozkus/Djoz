namespace Djoz.Application.Features.CQRSPattern.Queries.SongQueries.ListQueries
{
    public class ResultSongListQueryResponse
    {
        public int SongId { get; set; }
        public string SongName { get; set; }
        public string Singer { get; set; }
        public string SongUrl { get; set; }
        public List<int> PackageIds { get; set; } //Şarkının bağlı olduğu paket bilgisi

        //Kullanıcının şarkıyı çalabilmesi için kontrol
        public bool CanPlay(int userpackageId) => PackageIds.Contains(userpackageId);
    }
}