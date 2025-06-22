using Djoz.Application.Features.RepositoryPattern.Abstract.AppUserDal;
using Djoz.Domain.Entities;
using Djoz.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Persistance.RepositoryPattern.EntityFramework.AppUserServices
{
    public class EFAppUserWriteRepository : GenericWriteRepository<AppUser>, IAppUserWriteDal
    {
        public EFAppUserWriteRepository(DjozContext context) : base(context)
        {
        }
    }
}
