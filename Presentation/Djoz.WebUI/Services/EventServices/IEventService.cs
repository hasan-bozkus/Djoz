using Djoz.WebUI.Dtos.EventDtos;

namespace Djoz.WebUI.Services.EventServices
{
    public interface IEventService
    {
        Task<List<ResultEventDto>> GetListEventAsync();
        Task CreateEventAsync(CreateEventDto createEventDto);
        Task UpdateEventAsync(UpdateEventDto updateEventDto);
        Task DeleteEventAsync(int id);
        Task<UpdateEventDto> GetEventAsync(int id);
    }
}