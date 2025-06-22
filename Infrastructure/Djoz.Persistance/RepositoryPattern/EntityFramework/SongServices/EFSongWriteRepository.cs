using Djoz.Application.Features.RepositoryPattern.Abstract.SongDal;
using Djoz.Domain.Entities;
using Djoz.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Persistance.RepositoryPattern.EntityFramework.SongServices
{
    public class EFSongWriteRepository : GenericWriteRepository<Song>, ISongWriteDal
    {
        public EFSongWriteRepository(DjozContext context) : base(context)
        {
        }
    }
}
