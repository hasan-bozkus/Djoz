using AutoMapper;
using Djoz.Application.Features.RepositoryPattern.Abstract.CountDownDal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Queries.CountDownQueries.ListQueries
{
    public class ResultCountDownListQueryHandler : IRequestHandler<ResultCountDownListQueryRequest, List<ResultCountDownListQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICountDownReadDal _countDownReadDal;

        public ResultCountDownListQueryHandler(IMapper mapper, ICountDownReadDal countDownReadDal)
        {
            _mapper = mapper;
            _countDownReadDal = countDownReadDal;
        }

        public async Task<List<ResultCountDownListQueryResponse>> Handle(ResultCountDownListQueryRequest request, CancellationToken cancellationToken)
        {
            var values = _mapper.Map<List<ResultCountDownListQueryResponse>>(await _countDownReadDal.GetListAllAsync());
            return values;
        }
    }
}
