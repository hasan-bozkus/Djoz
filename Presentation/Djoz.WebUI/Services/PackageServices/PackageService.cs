using Djoz.WebUI.Dtos.PackageDtos;
using Newtonsoft.Json;

namespace Djoz.WebUI.Services.PackageServices
{
    public class PackageService : IPackageService
    {
        private readonly HttpClient _httpClient;

        public PackageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreatePackageAsync(CreatePackageDto createPackageDto)
        {
            await _httpClient.PostAsJsonAsync<CreatePackageDto>("Packages", createPackageDto);
        }

        public async Task DeletePackageAsync(int id)
        {
            await _httpClient.DeleteAsync($"Packages/{id}");
        }

        public async Task<UpdatePackageDto> GetPackageAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("Packages");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdatePackageDto>(jsonData);
            return values;
        }

        public async Task<List<ResultPackageDto>> GetListPackageAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Packages");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultPackageDto>>(jsonData);
            return values;
        }

        public async Task UpdatePackageAsync(UpdatePackageDto updatePackageDto)
        {
            await _httpClient.PutAsJsonAsync<UpdatePackageDto>("Packagess", updatePackageDto);
        }

    }
}
