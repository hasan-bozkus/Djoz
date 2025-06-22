using Djoz.Application.Features.RepositoryPattern.Abstract.SongDal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Features.CQRSPattern.Commands.SongCommands.DeleteCommands
{
    public class DeleteSongCommandHandler : IRequestHandler<DeleteSongCommandRequest, DeleteSongCommandResponse>
    {
        private readonly ISongReadDal _songReadDal;
        private readonly ISongWriteDal _songWriteDal;

        public DeleteSongCommandHandler(ISongReadDal songReadDal, ISongWriteDal songWriteDal)
        {
            _songReadDal = songReadDal;
            _songWriteDal = songWriteDal;
        }

        public async Task<DeleteSongCommandResponse> Handle(DeleteSongCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _songReadDal.GetByIdAsync(request.id);
            await _songWriteDal.DeleteAsync(result);
            await _songWriteDal.SaveAsync();
            return new();
        }
    }
}
