namespace Djoz.Application.Features.CQRSPattern.Commands.SongCommands.PlayCommands
{
    public class PlaySongCommandResponse
    {
        public int SongId { get; set; }
        public string SongName { get; set; }
        public string Singer { get; set; }
        public string SongUrl { get; set; }
        public List<int> PackageIds { get; set; } = new List<int>(); //Şarkının bağlı olduğu paket bilgisi

        //Kullanıcının şarkıyı çalabilmesi için kontrol
        public bool CanPlay(int userpackageId) => PackageIds.Contains(userpackageId);
    }
}