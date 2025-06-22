using Djoz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Services.AuthenticationServices
{
    public interface IJwtTokenHelper
    {
        string GenerateToken(AppUser user);
        Task<int?> GetPackageIdFromTokenAsync(string token);
    }
}
