using AutoMapper;
using Djoz.Application.Features.RepositoryPattern.Abstract.BannerDal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Queries.BannerQueries.ListQueries
{
    public class ResultBannerListQueryHandler : IRequestHandler<ResultBannerListQueryRequest, List<ResultBannerListQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBannerReadDal _bannerReadDal;

        public ResultBannerListQueryHandler(IMapper mapper, IBannerReadDal bannerReadDal)
        {
            _mapper = mapper;
            _bannerReadDal = bannerReadDal;
        }

        public async Task<List<ResultBannerListQueryResponse>> Handle(ResultBannerListQueryRequest request, CancellationToken cancellationToken)
        {
            var values = _mapper.Map<List<ResultBannerListQueryResponse>>(await _bannerReadDal.GetListAllAsync());
            return values;
        }
    }
}
