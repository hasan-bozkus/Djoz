using AutoMapper;
using Djoz.Application.Features.RepositoryPattern.Abstract.BannerDal;
using Djoz.Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Commands.BannerCommands.CreateCommands
{
    public class CreateBannerCommandHandler : IRequestHandler<CreateBannerCommandRequest, CreateBannerCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBannerWriteDal _bannerWriteDal;
        private readonly IValidator<CreateBannerCommandRequest> _validator;

        public CreateBannerCommandHandler(IMapper mapper, IBannerWriteDal bannerWriteDal, IValidator<CreateBannerCommandRequest> validator)
        {
            _mapper = mapper;
            _bannerWriteDal = bannerWriteDal;
            _validator = validator;
        }

        public async Task<CreateBannerCommandResponse> Handle(CreateBannerCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return new CreateBannerCommandResponse
                {
                    Success = false,
                    Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var result = _mapper.Map<Banner>(request);
            await _bannerWriteDal.CreateAsync(result);
            await _bannerWriteDal.SaveAsync();
            return new()
            {
                Success = true,
                CreatedId = result.BannerId
            };

        }
    }
}
