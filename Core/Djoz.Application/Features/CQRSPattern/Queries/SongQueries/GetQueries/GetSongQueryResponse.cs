using Microsoft.AspNetCore.Http;

namespace Djoz.Application.Features.CQRSPattern.Queries.SongQueries.GetQueries
{
    public class GetSongQueryResponse
    {
        public int SongId { get; set; }
        public string SongName { get; set; }
        public string Singer { get; set; }
        public string SongUrl { get; set; }
        public IFormFile? SongFile { get; set; }
    }
}