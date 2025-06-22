using Djoz.WebUI.Dtos.ContactDtos;
using Newtonsoft.Json;

namespace Djoz.WebUI.Services.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;
        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            await _httpClient.PostAsJsonAsync<CreateContactDto>("Contacts", createContactDto);
        }

        public async Task DeleteContactAsync(int id)
        {
            await _httpClient.DeleteAsync($"Contacts/{id}");
        }

        public async Task<UpdateContactDto> GetContactAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("Contacts");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateContactDto>(jsonData);
            return values;
        }

        public async Task<List<ResultContactDto>> GetListContactAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Contacts");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
            return values;
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateContactDto>("Contacts", updateContactDto);
        }
    }
}
