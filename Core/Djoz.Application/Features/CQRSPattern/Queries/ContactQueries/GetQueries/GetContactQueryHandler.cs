using AutoMapper;
using Djoz.Application.Features.RepositoryPattern.Abstract.ContactDal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Queries.ContactQueries.GetQueries
{
    public class GetContactQueryHandler : IRequestHandler<GetContactQueryRequest, GetContactQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IContactReadDal _contactReadDal;

        public GetContactQueryHandler(IMapper mapper, IContactReadDal contactReadDal)
        {
            _mapper = mapper;
            _contactReadDal = contactReadDal;
        }

        public async Task<GetContactQueryResponse> Handle(GetContactQueryRequest request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<GetContactQueryResponse>(await _contactReadDal.GetByIdAsync(request.id));
            return value;
        }
    }
}
