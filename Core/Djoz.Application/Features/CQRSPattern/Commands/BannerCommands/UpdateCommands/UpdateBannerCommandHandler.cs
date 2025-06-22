using AutoMapper;
using Djoz.Application.Features.CQRSPattern.Commands.BannerCommands.CreateCommands;
using Djoz.Application.Features.RepositoryPattern.Abstract.BannerDal;
using Djoz.Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Commands.BannerCommands.UpdateCommands
{
    public class UpdateBannerCommandHandler : IRequestHandler<UpdatSongCommandRequest, UpdateBannerCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBannerWriteDal _bannerWriteDal;
        private readonly IValidator<UpdatSongCommandRequest> _validator;

        public UpdateBannerCommandHandler(IMapper mapper, IBannerWriteDal bannerWriteDal, IValidator<UpdatSongCommandRequest> validator)
        {
            _mapper = mapper;
            _bannerWriteDal = bannerWriteDal;
            _validator = validator;
        }

        public async Task<UpdateBannerCommandResponse> Handle(UpdatSongCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if(!validationResult.IsValid)
            {
                return new UpdateBannerCommandResponse
                {
                    Success = false,
                    Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var result = _mapper.Map<Banner>(request);
            await _bannerWriteDal.UpdateAsync(result);
            await _bannerWriteDal.SaveAsync();
            return new()
            {
                Success = true,
            };
        }
    }
}
