using Djoz.Application.Features.RepositoryPattern.Abstract.PackageDal;
using Djoz.Domain.Entities;
using Djoz.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Persistance.RepositoryPattern.EntityFramework.PackageServices
{
    public class EFPackageReadRepository : GenericReadRepository<Package>, IPackageReadDal
    {
        private readonly DjozContext _context;

        public EFPackageReadRepository(DjozContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Package> GetPackageWithSongsByIdAsync(int id)
        {
            var values = await _context.Packages.Include(p => p.Songs).FirstOrDefaultAsync(p => p.PackageId == id);
            return values;
        }

        public async Task<List<Song>> GetSongsByPackageIdAsync(int id)
        {
            var values = await _context.Songs.Where(song => song.Packages.Any(p =>  p.PackageId == id)).ToListAsync();
            return values;
        }
    }
}
