using Djoz.Application.Features.RepositoryPattern.Abstract.ContactDal;
using Djoz.Domain.Entities;
using Djoz.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Persistance.RepositoryPattern.EntityFramework.ContactServices
{
    public class EFContactWriteRepository : GenericWriteRepository<Contact>, IContactWriteDal
    {
        public EFContactWriteRepository(DjozContext context) : base(context)
        {
        }
    }
}
