using Djoz.Application.Features.RepositoryPattern.Abstract.PackageDal;
using Djoz.Domain.Entities;
using Djoz.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Persistance.RepositoryPattern.EntityFramework.PackageServices
{
    public class EFPackageWriteRepository : GenericWriteRepository<Package>, IPackageWriteDal
    {
        public EFPackageWriteRepository(DjozContext context) : base(context)
        {
        }
    }
}
