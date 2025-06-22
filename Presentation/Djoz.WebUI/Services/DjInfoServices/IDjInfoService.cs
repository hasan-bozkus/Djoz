using Djoz.WebUI.Dtos.DjInfoDtos;

namespace Djoz.WebUI.Services.DjInfoServices
{
    public interface IDjInfoService
    {
        Task<List<ResultDjInfoDto>> GetListDjInfoAsync();
        Task CreateDjInfoAsync(CreateDjInfoDto createDjInfoDto);
        Task UpdateDjInfoAsync(UpdateDjInfoDto updateDjInfoDto);
        Task DeleteDjInfoAsync(int id);
        Task<UpdateDjInfoDto> GetDjInfoAsync(int id);
    }
}