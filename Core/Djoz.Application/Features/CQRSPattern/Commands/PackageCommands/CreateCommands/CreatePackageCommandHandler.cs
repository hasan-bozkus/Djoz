using AutoMapper;
using Djoz.Application.Dtos.PackageDtos;
using Djoz.Application.Features.RepositoryPattern.Abstract.PackageDal;
using Djoz.Application.Features.RepositoryPattern.Abstract.SongDal;
using Djoz.Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Commands.PackageCommands.CreateCommands
{
    public class CreatePackageCommandHandler : IRequestHandler<CreatePackageCommandRequest, CreatePackageCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPackageWriteDal _packageWriteDal;
        private readonly ISongReadDal _songReadDal;
        private readonly IValidator<CreatePackageCommandRequest> _validator;

        public CreatePackageCommandHandler(IMapper mapper, IPackageWriteDal packageWriteDal, ISongReadDal songReadDal, IValidator<CreatePackageCommandRequest> validator)
        {
            _mapper = mapper;
            _packageWriteDal = packageWriteDal;
            _songReadDal = songReadDal;
            _validator = validator;
        }

        public async Task<CreatePackageCommandResponse> Handle(CreatePackageCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return new CreatePackageCommandResponse()
                {
                    Success = false,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            var result = _mapper.Map<Package>(request);
            var songs = await _songReadDal.GetListAllAsync();

            if(request.SongIds != null || request.SongIds.Any())
            {
                var selectedSongs = songs.Where(song => request.SongIds.Contains(song.SongId)).ToList();
               result.Songs = selectedSongs;

            }
            await _packageWriteDal.CreateAsync(result);
            await _packageWriteDal.SaveAsync();

            return new()
            {
                Success = true
            };
        }
    }
}
