using Djoz.WebUI.Services.Interfaces;
using System.Security.Claims;

namespace Djoz.WebUI.Services.Concrete
{
    public class JwtAuthService : IJwtAuthSevice
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JwtAuthService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId => _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}
