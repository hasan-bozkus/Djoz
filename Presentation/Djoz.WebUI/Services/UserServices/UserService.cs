using Djoz.WebUI.Dtos.AppUserDtos;

namespace Djoz.WebUI.Services.UserServices
{
    public class UserService : IUserService
    {
        public Task DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultAppUserDto>> GetListUserAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UpdateAppUserDto> GetUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(UpdateAppUserDto updateUserDto)
        {
            throw new NotImplementedException();
        }
    }
}
