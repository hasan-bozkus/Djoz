using Djoz.WebUI.Dtos.PackageDtos;

namespace Djoz.WebUI.Services.PackageServices
{
    public interface IPackageService
    {
        Task<List<ResultPackageDto>> GetListPackageAsync();
        Task CreatePackageAsync(CreatePackageDto createPackageDto);
        Task UpdatePackageAsync(UpdatePackageDto updatePackageDto);
        Task DeletePackageAsync(int id);
        Task<UpdatePackageDto> GetPackageAsync(int id);
    }
}