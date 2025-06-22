using Djoz.WebUI.ViewModels.AppUserViewModels;

namespace Djoz.WebUI.Services.LoginServices
{
    public interface ILoginService
    {
        Task<string> UserLoginAsync(UserLoginViewModel userLoginViewModel);
    }
}