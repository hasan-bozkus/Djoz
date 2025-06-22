using AutoMapper;
using Djoz.Application.Features.RepositoryPattern.Abstract.CountDownDal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Queries.CountDownQueries.GetQueries
{
    public class GetCountDownQueryHandler : IRequestHandler<GetCountDownQueryRequest, GetCountDownQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICountDownReadDal _countDownReadDal;

        public GetCountDownQueryHandler(IMapper mapper, ICountDownReadDal countDownReadDal)
        {
            _mapper = mapper;
            _countDownReadDal = countDownReadDal;
        }

        public async Task<GetCountDownQueryResponse> Handle(GetCountDownQueryRequest request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<GetCountDownQueryResponse>(await _countDownReadDal.GetByIdAsync(request.id));
            return value;
        }

       
    }
}
