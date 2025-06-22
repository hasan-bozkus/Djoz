using Djoz.Application.Features.RepositoryPattern.Abstract.CountDownDal;
using Djoz.Domain.Entities;
using Djoz.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Persistance.RepositoryPattern.EntityFramework.CountDownServices
{
    public class EFCountDownReadRepository : GenericReadRepository<CountDown>, ICountDownReadDal
    {
        public EFCountDownReadRepository(DjozContext context) : base(context)
        {
        }
    }
}
