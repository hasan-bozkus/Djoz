using Djoz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.RepositoryPattern.Abstract.PackageDal
{
    public interface IPackageReadDal : IGenericReadDal<Package>
    {
        Task<List<Song>> GetSongsByPackageIdAsync(int id);
        Task<Package> GetPackageWithSongsByIdAsync(int id);
    }
}
