using AutoMapper;
using Djoz.Application.Features.RepositoryPattern.Abstract.BannerDal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Commands.BannerCommands.DeleteCommands
{
    public class DeleteBannerCommandHandler : IRequestHandler<DeleteBannerCommandRequest, DeleteBannerCommandResponse>
    {
        private readonly IBannerReadDal _bannerReadDal;
        private readonly IBannerWriteDal _bannerWriteDal;

        public DeleteBannerCommandHandler(IBannerWriteDal bannerWriteDal, IBannerReadDal bannerReadDal)
        {
            _bannerWriteDal = bannerWriteDal;
            _bannerReadDal = bannerReadDal;
        }

        public async Task<DeleteBannerCommandResponse> Handle(DeleteBannerCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _bannerReadDal.GetByIdAsync(request.id);
            await _bannerWriteDal.DeleteAsync(result);
            await _bannerWriteDal.SaveAsync();
            return new();
        }
    }
}
