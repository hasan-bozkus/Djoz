using Djoz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.RepositoryPattern.Abstract.AppUserDal
{
    public interface IAppUserReadDal : IGenericReadDal<AppUser>
    {
        Task<List<AppUser>> GetPackageNameWithUserListAsync();
        Task<AppUser> GetUserByIdAsync(int id);
    }
}
