using AutoMapper;
using Djoz.Application.Features.RepositoryPattern.Abstract.PackageDal;
using Djoz.Application.Features.RepositoryPattern.Abstract.SongDal;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Commands.PackageCommands.UpdateCommands
{
    public class UpdatePackageCommandHandler : IRequestHandler<UpdatePackageCommandRequest, UpdatePackageCommandResponse>
    {
        private readonly ISongReadDal _songReadDal;
        private readonly IPackageWriteDal _packageWriteDal;
        private readonly IPackageReadDal _packageReadDal;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdatePackageCommandRequest> _validator;

        public UpdatePackageCommandHandler(ISongReadDal songReadDal, IPackageWriteDal packageWriteDal, IPackageReadDal packageReadDal, IMapper mapper, IValidator<UpdatePackageCommandRequest> validator)
        {
            _songReadDal = songReadDal;
            _packageWriteDal = packageWriteDal;
            _packageReadDal = packageReadDal;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<UpdatePackageCommandResponse> Handle(UpdatePackageCommandRequest request, CancellationToken cancellationToken)
        {
            var songs = await _songReadDal.GetListAllAsync();

            var validationResult = await _validator.ValidateAsync(request);
            if(!validationResult.IsValid)
            {
                return new UpdatePackageCommandResponse()
                {
                    Success = false,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            var package = await _packageReadDal.GetPackageWithSongsByIdAsync(request.PackageId);

            //paket adının güncellenme işlmei
            package.Name = request.Name;

            //seçilen şarıklar
            var selectedSongIds = request.SongIds ?? new List<int>();

            //mevcut şarkıların listesi
            var existingSongIds = package.Songs.Select(x => x.SongId).ToList();

            //mevcut şarkılar hariç yeni eklenenler
            var songsToAddIds = selectedSongIds.Except(existingSongIds).ToList();

            //eklenen şarkılar liste
            var songsToAdd = songs.Where(song => songsToAddIds.Contains(song.SongId)).ToList();

            //çıkarılan şarkılar hariç
            var extractedSongs = existingSongIds.Except(selectedSongIds).ToList();

            //çıkarılan şarkılar
            var extractedsSong = package.Songs.Where(song => extractedSongs.Contains(song.SongId)).ToList();

            //yenileri ekle
            foreach(var item in songsToAdd)
            {
                package.Songs.Add(item);
            }

            //eskileri kaldır
            foreach(var song in extractedsSong)
            {
                package.Songs.Remove(song);
            }

            //işlemlerin topunu güncelle
            await _packageWriteDal.UpdateAsync(package);
            await _packageWriteDal.SaveAsync();

            return new()
            {
                Success = true
            };
        }
    }
}
