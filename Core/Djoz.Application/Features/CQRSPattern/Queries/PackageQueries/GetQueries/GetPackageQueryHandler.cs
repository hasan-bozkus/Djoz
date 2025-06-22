using AutoMapper;
using Djoz.Application.Features.RepositoryPattern.Abstract.PackageDal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Queries.PackageQueries.GetQueries
{
    public class GetPackageQueryHandler : IRequestHandler<GetPackageQueryRequest, GetPackageQueryResponse>
    {
        private readonly IPackageReadDal _packageReadDal;
        private readonly IMapper _mapper;

        public GetPackageQueryHandler(IPackageReadDal packageReadDal, IMapper mapper)
        {
            _packageReadDal = packageReadDal;
            _mapper = mapper;
        }

        public async Task<GetPackageQueryResponse> Handle(GetPackageQueryRequest request, CancellationToken cancellationToken)
        {
            var packages = await _packageReadDal.GetPackageWithSongsByIdAsync(request.id);
            var result = _mapper.Map<GetPackageQueryResponse>(packages);

            //mevcut şakrı isimleri ve id değerleri
            result.SongIds = packages.Songs!.Select(x => x.SongId).ToList();
            result.CurrentSongNames = packages.Songs!.Select(x => x.SongName).ToList();

            return result;
        }
    }
}
