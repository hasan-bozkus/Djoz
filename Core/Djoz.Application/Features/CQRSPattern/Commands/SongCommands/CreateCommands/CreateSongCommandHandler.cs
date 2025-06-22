using AutoMapper;
using Djoz.Application.Dtos.SongDtos;
using Djoz.Application.Features.RepositoryPattern.Abstract.SongDal;
using Djoz.Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Commands.SongCommands.CreateCommands
{
    public class CreateSongCommandHandler : IRequestHandler<CreateSongCommandRequest, CreateSongCommandResponse>
    {
        private readonly ISongWriteDal _songWriteDal;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateSongCommandRequest> _validator;

        public CreateSongCommandHandler(ISongWriteDal songWriteDal, IMapper mapper, IValidator<CreateSongCommandRequest> validator)
        {
            _songWriteDal = songWriteDal;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<CreateSongCommandResponse> Handle(CreateSongCommandRequest request, CancellationToken cancellationToken)
        {
            //var result = _mapper.Map<Song>(request);

            var valdiationResult = await _validator.ValidateAsync(request);
            if (!valdiationResult.IsValid)
            {
                return new CreateSongCommandResponse()
                {
                    Success = false,
                    Errors = valdiationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            if (request.SongFile != null && request.SongFile.Length > 0)
            {
                var extension = Path.GetExtension(request.SongFile.FileName);

                var rawName = $"{request.SongName}_{request.Singer}";
                var safeName = string.Concat(rawName.Split(Path.GetInvalidFileNameChars()))
                    .Replace(" ", "_")
                    .ToLower();

                var fileName = $"{safeName}_{Guid.NewGuid()}{extension}";
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/songs", fileName);

                //var songsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "songs");

                // Eğer klasör yoksa oluştur
                //if (!Directory.Exists(path))
                //    Directory.CreateDirectory(path);


                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await request.SongFile.CopyToAsync(stream);
                }

                var song = new Song
                {
                    SongName = request.SongName,
                    Singer = request.Singer,
                    SongUrl = "songs/" + fileName
                };


                await _songWriteDal.CreateAsync(song);
                await _songWriteDal.SaveAsync();
            }
            return new()
            {
                Success = true
            };
        }
    }
}
