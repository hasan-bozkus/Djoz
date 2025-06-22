using Djoz.WebUI.Dtos.BannerDtos;

namespace Djoz.WebUI.Services.BannerServices
{
    public interface IBannerService
    {
        Task<List<ResultBannerDto>> GetListBannerAsync();
        Task CreateBannerAsync(CreateBannerDto createBannerDto);
        Task UpdateBannerAsync(UpdateBannerDto updateBannerDto);
        Task DeleteBannerAsync(int id);
        Task<UpdateBannerDto> GetBannerAsync(int id);
    }
}