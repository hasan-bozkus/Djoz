using AutoMapper;
using Djoz.Application.Features.RepositoryPattern.Abstract.DjInfoDal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Queries.DjInfoQueries.ListQueries
{
    public class ResultDjInfoListQueryHandler : IRequestHandler<ResultDjInfoListQueryRequest, List<ResultDjInfoListQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IDjInfoReadDal _djInfoReadDal;

        public ResultDjInfoListQueryHandler(IMapper mapper, IDjInfoReadDal djInfoReadDal)
        {
            _mapper = mapper;
            _djInfoReadDal = djInfoReadDal;
        }

        public async Task<List<ResultDjInfoListQueryResponse>> Handle(ResultDjInfoListQueryRequest request, CancellationToken cancellationToken)
        {
            var values = _mapper.Map<List<ResultDjInfoListQueryResponse>>(await _djInfoReadDal.GetListAllAsync());
            return values;
        }
    }
}
