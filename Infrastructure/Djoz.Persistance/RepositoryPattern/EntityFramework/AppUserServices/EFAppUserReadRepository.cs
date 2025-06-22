using Djoz.Application.Features.RepositoryPattern.Abstract.AppUserDal;
using Djoz.Domain.Entities;
using Djoz.Persistance.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Persistance.RepositoryPattern.EntityFramework.AppUserServices
{
    public class EFAppUserReadRepository : GenericReadRepository<AppUser>, IAppUserReadDal
    {
        private readonly DjozContext _context;
        private readonly UserManager<AppUser> _userManager;

        public EFAppUserReadRepository(DjozContext context, UserManager<AppUser> userManager) : base(context)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<List<AppUser>> GetPackageNameWithUserListAsync()
        {
            var values = await _context.AppUsers.Include(x => x.Package).ToListAsync();
            return values;
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            var value = await _userManager.FindByIdAsync(id.ToString());
            return value;
        }
    }
}
