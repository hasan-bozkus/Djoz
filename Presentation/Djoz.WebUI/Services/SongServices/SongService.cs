using Djoz.WebUI.Dtos.SongDtos;
using Newtonsoft.Json;

namespace Djoz.WebUI.Services.SongServices
{
    public class SongService : ISongService
    {
        private readonly HttpClient _httpClient;

        public SongService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateSongAsync(CreateSongDto createSongDto)
        {
            await _httpClient.PostAsJsonAsync<CreateSongDto>("Songs", createSongDto);
        }

        public async Task DeleteSongAsync(int id)
        {
            await _httpClient.DeleteAsync($"Songs/{id}");
        }

        public async Task<UpdateSongDto> GetSongAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("Songs");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateSongDto>(jsonData);
            return values;
        }

        public async Task<List<ResultSongDto>> GetListSongAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Songs");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSongDto>>(jsonData);
            return values;
        }

        public async Task UpdateSongAsync(UpdateSongDto updateSongDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateSongDto>("Songs", updateSongDto);
        }

        public async Task PlaySongAsync(PlaySongRequestDto playSong)
        {
            await _httpClient.PostAsJsonAsync<PlaySongRequestDto>("Songs/PlaySong", playSong);
        }
    }
}
