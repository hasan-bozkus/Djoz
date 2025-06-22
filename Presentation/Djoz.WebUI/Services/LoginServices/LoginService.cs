using Djoz.WebUI.Dtos.AppUserDtos;
using Djoz.WebUI.Helpers;
using Djoz.WebUI.Models.AppUserViewModels;
using Djoz.WebUI.ViewModels.AppUserViewModels;

namespace Djoz.WebUI.Services.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient _httpClient;

        public LoginService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> UserLoginAsync(UserLoginViewModel userLoginViewModel)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<UserLoginViewModel>("UserLogins", userLoginViewModel);
            if(responseMessage.IsSuccessStatusCode)
            {
                var loginResponse = await responseMessage.Content.ReadFromJsonAsync<UserLoginResponseViewModel>();
                if (loginResponse != null && loginResponse.Success)
                {
                    return loginResponse.Token; // Token'ı geriye döndürüyoruz
                }
            }

            return null;
        }
    }
}
