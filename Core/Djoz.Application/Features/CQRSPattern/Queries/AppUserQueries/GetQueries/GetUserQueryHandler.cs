using AutoMapper;
using Djoz.Application.Features.RepositoryPattern.Abstract.AppUserDal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Queries.AppUserQueries.GetQueries
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQueryRequest, GetUserQueryResponse>
    {
        private readonly IAppUserReadDal _appUserReadDal;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IAppUserReadDal appUserReadDal, IMapper mapper)
        {
            _appUserReadDal = appUserReadDal;
            _mapper = mapper;
        }

        public async Task<GetUserQueryResponse> Handle(GetUserQueryRequest request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<GetUserQueryResponse>(await _appUserReadDal.GetByIdAsync(request.id));
            return value;
        }
    }
}
