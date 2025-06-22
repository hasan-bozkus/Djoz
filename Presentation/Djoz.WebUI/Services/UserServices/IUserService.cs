using Djoz.WebUI.Dtos.AppUserDtos;

namespace Djoz.WebUI.Services.UserServices
{
    public interface IUserService
    {
        Task<List<ResultAppUserDto>> GetListUserAsync();
        Task UpdateUserAsync(UpdateAppUserDto updateUserDto);
        Task DeleteUserAsync(int id);
        Task<UpdateAppUserDto> GetUserAsync(int id);
    }
}