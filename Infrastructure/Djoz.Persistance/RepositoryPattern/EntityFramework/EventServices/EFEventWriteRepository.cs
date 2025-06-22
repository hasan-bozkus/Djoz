using Djoz.Application.Features.RepositoryPattern.Abstract.EventDal;
using Djoz.Domain.Entities;
using Djoz.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Persistance.RepositoryPattern.EntityFramework.EventServices
{
    public class EFEventWriteRepository : GenericWriteRepository<Event>, IEventWriteDal
    {
        public EFEventWriteRepository(DjozContext context) : base(context)
        {
        }
    }
}
