using Djoz.WebUI.Dtos.EventDtos;
using Newtonsoft.Json;

namespace Djoz.WebUI.Services.EventServices
{
    public class EventService : IEventService
    {
        private readonly HttpClient _httpClient;
        public EventService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateEventAsync(CreateEventDto createEventDto)
        {
            await _httpClient.PostAsJsonAsync<CreateEventDto>("Events", createEventDto);
        }

        public async Task DeleteEventAsync(int id)
        {
            await _httpClient.DeleteAsync($"Events/{id}");
        }

        public async Task<UpdateEventDto> GetEventAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("Events");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateEventDto>(jsonData);
            return values;
        }

        public async Task<List<ResultEventDto>> GetListEventAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Events");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultEventDto>>(jsonData);
            return values;
        }

        public async Task UpdateEventAsync(UpdateEventDto updateEventDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateEventDto>("Events", updateEventDto);
        }
    }
}
