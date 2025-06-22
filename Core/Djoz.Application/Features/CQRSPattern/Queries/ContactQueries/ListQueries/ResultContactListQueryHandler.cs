using AutoMapper;
using Djoz.Application.Features.RepositoryPattern.Abstract.ContactDal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Queries.ContactQueries.ListQueries
{
    public class ResultContactListQueryHandler : IRequestHandler<ResultContactListQueryRequest, List<ResultContactListQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IContactReadDal _contactReadDal;

        public ResultContactListQueryHandler(IMapper mapper, IContactReadDal contactReadDal)
        {
            _mapper = mapper;
            _contactReadDal = contactReadDal;
        }

        public async Task<List<ResultContactListQueryResponse>> Handle(ResultContactListQueryRequest request, CancellationToken cancellationToken)
        {
            var values = _mapper.Map<List<ResultContactListQueryResponse>>(await _contactReadDal.GetListAllAsync());
            return values;
        }
    }
}
