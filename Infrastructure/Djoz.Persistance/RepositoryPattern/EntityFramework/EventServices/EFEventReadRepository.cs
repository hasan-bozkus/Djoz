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
    public class EFEventReadRepository : GenericReadRepository<Event>, IEventReadDal
    {
        public EFEventReadRepository(DjozContext context) : base(context)
        {
        }
    }
}
