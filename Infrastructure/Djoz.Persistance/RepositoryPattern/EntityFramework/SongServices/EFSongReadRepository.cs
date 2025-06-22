using Djoz.Application.Features.RepositoryPattern.Abstract.SongDal;
using Djoz.Domain.Entities;
using Djoz.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Persistance.RepositoryPattern.EntityFramework.SongServices
{
    public class EFSongReadRepository : GenericReadRepository<Song>, ISongReadDal
    {
        private readonly DjozContext _context;

        public EFSongReadRepository(DjozContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Song> GetSongByUrlAsync(string songUrl)
        {
            var values = await _context.Songs.Include(x => x.Packages).FirstOrDefaultAsync(y => y.SongUrl.ToLower() == songUrl.ToLower());
            return values;
        }
    }
}
