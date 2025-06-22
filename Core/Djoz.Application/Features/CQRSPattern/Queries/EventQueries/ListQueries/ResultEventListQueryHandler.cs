using AutoMapper;
using Djoz.Application.Features.RepositoryPattern.Abstract.EventDal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Queries.EventQueries.ListQueries
{
    public class ResultEventListQueryHandler : IRequestHandler<ResultEventListQueryRequest, List<ResultEventListQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IEventReadDal _eventReadDal;

        public ResultEventListQueryHandler(IMapper mapper, IEventReadDal eventReadDal)
        {
            _mapper = mapper;
            _eventReadDal = eventReadDal;
        }

        public async Task<List<ResultEventListQueryResponse>> Handle(ResultEventListQueryRequest request, CancellationToken cancellationToken)
        {
            var values = _mapper.Map<List<ResultEventListQueryResponse>>(await _eventReadDal.GetListAllAsync());
            return values;
        }
    }
}
