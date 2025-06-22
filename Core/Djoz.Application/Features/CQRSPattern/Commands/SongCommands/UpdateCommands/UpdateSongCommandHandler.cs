using Djoz.Application.Features.RepositoryPattern.Abstract.SongDal;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Commands.SongCommands.UpdateCommands
{
    public class UpdateSongCommandHandler : IRequestHandler<UpdateSongCommandRequest, UpdateSongCommandResponse>
    {
        private readonly ISongReadDal _songReadDal;
        private readonly ISongWriteDal _songWriteDal;
        private readonly IValidator<UpdateSongCommandRequest> _validator;

        public UpdateSongCommandHandler(ISongReadDal songReadDal, ISongWriteDal songWriteDal, IValidator<UpdateSongCommandRequest> validator)
        {
            _songReadDal = songReadDal;
            _songWriteDal = songWriteDal;
            _validator = validator;
        }

        public async Task<UpdateSongCommandResponse> Handle(UpdateSongCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if(!validationResult.IsValid)
            {
                return new UpdateSongCommandResponse()
                {
                    Success = false,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            var song = await _songReadDal.GetByIdAsync(request.SongId);

            //yeni dosya yüklenmiş ise
            song.SongName = request.SongName;
            song.Singer = request.Singer;

            if (request.SongFile != null && request.SongFile.Length > 0)
            {
                var extension = Path.GetExtension(request.SongFile.FileName);

                var rawName = $"{request.SongName}_{request.Singer}";
                var safeName = string.Concat(rawName.Split(Path.GetInvalidFileNameChars()))
                    .Replace(" ", "_").ToLower();
                var fileName = $"{safeName}_{Guid.NewGuid()}{extension}";
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/songs", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await request.SongFile.CopyToAsync(stream);
                }

                //var yeni dosyayı ekle, yok ise eskiyi koru
                song.SongUrl = "songs/" + fileName;
            }
            else
            {
                // dosya yüklenmemiş ise mevcut dosyayı yolunu koru
                song.SongUrl = request.SongUrl;
            }

            await _songWriteDal.UpdateAsync(song);
            await _songWriteDal.SaveAsync();

            return new()
            {
                Success = true
            };
        }
    }
}
