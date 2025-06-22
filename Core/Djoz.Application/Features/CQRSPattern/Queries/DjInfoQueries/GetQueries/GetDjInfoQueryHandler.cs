using AutoMapper;
using Djoz.Application.Features.RepositoryPattern.Abstract.DjInfoDal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Queries.DjInfoQueries.GetQueries
{
    public class GetDjInfoQueryHandler : IRequestHandler<GetDjInfoQueryRequest, GetDjInfoQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDjInfoReadDal _djInfoReadDal;

        public GetDjInfoQueryHandler(IMapper mapper, IDjInfoReadDal djInfoReadDal)
        {
            _mapper = mapper;
            _djInfoReadDal = djInfoReadDal;
        }

        public async Task<GetDjInfoQueryResponse> Handle(GetDjInfoQueryRequest request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<GetDjInfoQueryResponse>(await _djInfoReadDal.GetByIdAsync(request.id));
            return value;
        }
    }
}
