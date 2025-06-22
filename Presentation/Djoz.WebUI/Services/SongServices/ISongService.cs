using Djoz.WebUI.Dtos.SongDtos;

namespace Djoz.WebUI.Services.SongServices
{
    public interface ISongService
    {
        Task<List<ResultSongDto>> GetListSongAsync();
        Task CreateSongAsync(CreateSongDto createSongDto);
        Task UpdateSongAsync(UpdateSongDto updateSongDto);
        Task DeleteSongAsync(int id);
        Task<UpdateSongDto> GetSongAsync(int id);
        Task PlaySongAsync(PlaySongRequestDto playSong);
    }
}