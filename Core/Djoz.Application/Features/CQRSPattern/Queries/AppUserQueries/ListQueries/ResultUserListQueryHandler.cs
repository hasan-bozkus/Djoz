using Djoz.Application.Features.RepositoryPattern.Abstract.AppUserDal;
using Djoz.Application.Features.RepositoryPattern.Abstract.PackageDal;
using Djoz.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Queries.AppUserQueries.ListQueries
{
    public class ResultUserListQueryHandler : IRequestHandler<ResultUserListQueryRequest, List<ResultUserListQueryResponse>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IPackageReadDal _packageReadDal;
        private readonly IAppUserReadDal _appUserReadDal;

        public ResultUserListQueryHandler(UserManager<AppUser> userManager, IPackageReadDal packageReadDal, IAppUserReadDal appUserReadDal)
        {
            _userManager = userManager;
            _packageReadDal = packageReadDal;
            _appUserReadDal = appUserReadDal;
        }

        public async Task<List<ResultUserListQueryResponse>> Handle(ResultUserListQueryRequest request, CancellationToken cancellationToken)
        {
            var users = await _appUserReadDal.GetPackageNameWithUserListAsync();
            var filteredUsers = new List<AppUser>();
            foreach (var user in users)
            {
               var roles  = await _userManager.GetRolesAsync(user);
                if (roles.Contains("User"))
                {
                    filteredUsers.Add(user);
                }
            }

            return filteredUsers.Select(user => new ResultUserListQueryResponse
            {
                Id = user.Id,
                FullName = user.FullName,
                PackageId = user.PackageId,
                PackageName = user.Package.Name ?? "paketi yok"
            }).ToList();
        }
    }
}
