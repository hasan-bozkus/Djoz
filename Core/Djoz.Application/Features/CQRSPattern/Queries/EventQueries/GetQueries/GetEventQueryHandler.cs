using AutoMapper;
using Djoz.Application.Features.RepositoryPattern.Abstract.EventDal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Queries.EventQueries.GetQueries
{
    public class GetEventQueryHandler : IRequestHandler<GetEventQueryRequest, GetEventQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEventReadDal _eventReadDal;

        public GetEventQueryHandler(IMapper mapper, IEventReadDal eventReadDal)
        {
            _mapper = mapper;
            _eventReadDal = eventReadDal;
        }

        public async Task<GetEventQueryResponse> Handle(GetEventQueryRequest request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<GetEventQueryResponse>(await _eventReadDal.GetByIdAsync(request.id));
            return value;
        }
    }
}
