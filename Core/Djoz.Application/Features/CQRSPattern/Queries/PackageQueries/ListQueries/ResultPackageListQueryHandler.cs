using AutoMapper;
using Djoz.Application.Features.RepositoryPattern.Abstract.PackageDal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Queries.PackageQueries.ListQueries
{
    public class ResultPackageListQueryHandler : IRequestHandler<ResultPackageListQueryRequest, List<ResultPackageListQueryResponse>>
    {
        private readonly IPackageReadDal _packageReadDal;
        private readonly IMapper _mapper;

        public ResultPackageListQueryHandler(IPackageReadDal packageReadDal, IMapper mapper)
        {
            _packageReadDal = packageReadDal;
            _mapper = mapper;
        }


        public async Task<List<ResultPackageListQueryResponse>> Handle(ResultPackageListQueryRequest request, CancellationToken cancellationToken)
        {
            var values = _mapper.Map<List<ResultPackageListQueryResponse>>(await _packageReadDal.GetListAllAsync());
            return values;
        }
    }
}
