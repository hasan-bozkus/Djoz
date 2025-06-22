using Djoz.WebUI.Dtos.DjInfoDtos;
using Newtonsoft.Json;

namespace Djoz.WebUI.Services.DjInfoServices
{
    public class DjInfoService : IDjInfoService
    {
        private readonly HttpClient _httpClient;

        public DjInfoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateDjInfoAsync(CreateDjInfoDto createDjInfoDto)
        {
            await _httpClient.PostAsJsonAsync<CreateDjInfoDto>("DjInfos", createDjInfoDto);
        }

        public async Task DeleteDjInfoAsync(int id)
        {
            await _httpClient.DeleteAsync($"DjInfos/{id}");
        }

        public async Task<UpdateDjInfoDto> GetDjInfoAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("DjInfos");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateDjInfoDto>(jsonData);
            return values;
        }

        public async Task<List<ResultDjInfoDto>> GetListDjInfoAsync()
        {
            var responseMessage = await _httpClient.GetAsync("DjInfos");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultDjInfoDto>>(jsonData);
            return values;
        }

        public async Task UpdateDjInfoAsync(UpdateDjInfoDto updateDjInfoDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateDjInfoDto>("DjInfos", updateDjInfoDto);
        }
    }
}
