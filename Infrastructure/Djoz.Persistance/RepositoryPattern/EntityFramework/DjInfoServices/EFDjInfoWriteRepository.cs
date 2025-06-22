using Djoz.Application.Features.RepositoryPattern.Abstract.DjInfoDal;
using Djoz.Domain.Entities;
using Djoz.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Persistance.RepositoryPattern.EntityFramework.DjInfoServices
{
    public class EFDjInfoWriteRepository : GenericWriteRepository<DjInfo>, IDjInfoWriteDal
    {
        public EFDjInfoWriteRepository(DjozContext context) : base(context)
        {
        }
    }
}
