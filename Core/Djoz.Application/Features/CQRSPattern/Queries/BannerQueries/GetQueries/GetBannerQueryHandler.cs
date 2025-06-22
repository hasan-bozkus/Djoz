using AutoMapper;
using Djoz.Application.Features.RepositoryPattern.Abstract.BannerDal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Queries.BannerQueries.GetQueries
{
    public class GetBannerQueryHandler : IRequestHandler<GetBannerQueryRequest, GetBannerQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBannerReadDal _bannerReadDal;
        public GetBannerQueryHandler(IMapper mapper, IBannerReadDal bannerReadDal)
        {
            _mapper = mapper;
            _bannerReadDal = bannerReadDal;
        }

        public async Task<GetBannerQueryResponse> Handle(GetBannerQueryRequest request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<GetBannerQueryResponse>(await _bannerReadDal.GetByIdAsync(request.id));
            return value;
        }
    }
}
