using Djoz.Application.Features.RepositoryPattern.Abstract.BannerDal;
using Djoz.Domain.Entities;
using Djoz.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Persistance.RepositoryPattern.EntityFramework.BannerServices
{
    public class EFBannerReadRepository : GenericReadRepository<Banner>, IBannerReadDal
    {
        public EFBannerReadRepository(DjozContext context) : base(context)
        {
        }
    }
}
