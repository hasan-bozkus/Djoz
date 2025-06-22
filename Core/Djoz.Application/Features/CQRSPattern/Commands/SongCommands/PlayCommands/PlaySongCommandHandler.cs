using AutoMapper;
using Djoz.Application.Dtos.SongDtos;
using Djoz.Application.Features.RepositoryPattern.Abstract.AppUserDal;
using Djoz.Application.Features.RepositoryPattern.Abstract.SongDal;
using Djoz.Application.Services.AuthenticationServices;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Commands.SongCommands.PlayCommands
{
    public class PlaySongCommandHandler : IRequestHandler<PlaySongCommandRequest, PlaySongCommandResponse>
    {
        private readonly ISongReadDal _songReadDal;
        private readonly IMapper _mapper;

        public PlaySongCommandHandler(ISongReadDal songReadDal, IMapper mapper)
        {
            _songReadDal = songReadDal;
            _mapper = mapper;
        }

        public async Task<PlaySongCommandResponse> Handle(PlaySongCommandRequest request, CancellationToken cancellationToken)
        {
            var song = await _songReadDal.GetSongByUrlAsync(request.SongUrl);
            if (song != null)
                return _mapper.Map<PlaySongCommandResponse>(song);

            throw new NotImplementedException();
        }
    }
}
