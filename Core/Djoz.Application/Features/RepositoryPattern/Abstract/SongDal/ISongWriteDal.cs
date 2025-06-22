using Djoz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.RepositoryPattern.Abstract.SongDal
{
    public interface ISongWriteDal : IGenericWriteDal<Song>
    {
    }
}
