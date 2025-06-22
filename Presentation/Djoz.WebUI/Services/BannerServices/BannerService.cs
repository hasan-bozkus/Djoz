using Djoz.WebUI.Dtos.BannerDtos;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Djoz.WebUI.Services.BannerServices
{
    public class BannerService : IBannerService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BannerService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateBannerAsync(CreateBannerDto createBannerDto)
        {
            await _httpClient.PostAsJsonAsync<CreateBannerDto>("Banners", createBannerDto);
        }

        public async Task DeleteBannerAsync(int id)
        {
            await _httpClient.DeleteAsync($"Banners/{id}");
        }

        public async Task<UpdateBannerDto> GetBannerAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("Banners");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateBannerDto>(jsonData);
            return values;
        }

        public async Task<List<ResultBannerDto>> GetListBannerAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Banners");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBannerDto>>(jsonData);
            return values;
        }

        public async Task UpdateBannerAsync(UpdateBannerDto updateBannerDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateBannerDto>("Banners", updateBannerDto);
        }
    }
}
