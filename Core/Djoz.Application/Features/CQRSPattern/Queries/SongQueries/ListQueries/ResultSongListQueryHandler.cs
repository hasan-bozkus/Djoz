using AutoMapper;
using Djoz.Application.Features.RepositoryPattern.Abstract.SongDal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Queries.SongQueries.ListQueries
{
    public class ResultSongListQueryHandler : IRequestHandler<ResultSongListQueryRequest, List<ResultSongListQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ISongReadDal _songReadDal;

        public ResultSongListQueryHandler(IMapper mapper, ISongReadDal songReadDal)
        {
            _mapper = mapper;
            _songReadDal = songReadDal;
        }

        public async Task<List<ResultSongListQueryResponse>> Handle(ResultSongListQueryRequest request, CancellationToken cancellationToken)
        {
            var values = _mapper.Map<List<ResultSongListQueryResponse>>(await _songReadDal.GetListAllAsync());
            return values;
        }
    }
}
