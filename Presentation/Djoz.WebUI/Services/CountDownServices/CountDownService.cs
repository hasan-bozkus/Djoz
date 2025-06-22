using Djoz.WebUI.Dtos.CountDownDtos;
using Newtonsoft.Json;
using System.Net.Http;

namespace Djoz.WebUI.Services.CountDownServices
{
    public class CountDownService : ICountDownService
    {
        private readonly HttpClient _httpClient;

        public CountDownService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCountDownAsync(CreateCountDownDto createCountDownDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCountDownDto>("CountDowns", createCountDownDto);
        }

        public async Task DeleteCountDownAsync(int id)
        {
            await _httpClient.DeleteAsync($"CountDowns/{id}");
        }

        public async Task<UpdateCountDownDto> GetCountDownAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("CountDowns");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateCountDownDto>(jsonData);
            return values;
        }

        public async Task<List<ResultCountDownDto>> GetListCountDownAsync()
        {
            var responseMessage = await _httpClient.GetAsync("CountDowns");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCountDownDto>>(jsonData);
            return values;
        }

        public async Task UpdateCountDownAsync(UpdateCountDownDto updateCountDownDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCountDownDto>("CountDowns", updateCountDownDto);
        }
    }
}
