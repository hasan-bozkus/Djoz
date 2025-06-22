using Djoz.WebUI.Dtos.CountDownDtos;

namespace Djoz.WebUI.Services.CountDownServices
{
    public interface ICountDownService
    {
        Task<List<ResultCountDownDto>> GetListCountDownAsync();
        Task CreateCountDownAsync(CreateCountDownDto createCountDownDto);
        Task UpdateCountDownAsync(UpdateCountDownDto updateCountDownDto);
        Task DeleteCountDownAsync(int id);
        Task<UpdateCountDownDto> GetCountDownAsync(int id);
    }
}