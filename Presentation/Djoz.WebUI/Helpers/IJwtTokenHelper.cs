using Djoz.WebUI.Dtos.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.WebUI.Helpers
{
    public interface IJwtTokenHelper
    {
        string GenerateToken(ResultAppUserDto user);
        Task<int?> GetPackageIdFromTokenAsync(string token);
    }
}
