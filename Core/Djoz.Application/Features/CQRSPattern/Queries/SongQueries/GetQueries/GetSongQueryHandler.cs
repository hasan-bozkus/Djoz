using AutoMapper;
using Djoz.Application.Features.RepositoryPattern.Abstract.SongDal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Queries.SongQueries.GetQueries
{
    public class GetSongQueryHandler : IRequestHandler<GetSongQueryRequest, GetSongQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISongReadDal _songReadDal;

        public GetSongQueryHandler(IMapper mapper, ISongReadDal songReadDal)
        {
            _mapper = mapper;
            _songReadDal = songReadDal;
        }

        public async Task<GetSongQueryResponse> Handle(GetSongQueryRequest request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<GetSongQueryResponse>(await _songReadDal.GetByIdAsync(request.id));
            return value;
        }
    }
}
