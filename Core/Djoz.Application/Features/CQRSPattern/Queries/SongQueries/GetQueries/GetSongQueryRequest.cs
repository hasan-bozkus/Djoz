using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Queries.SongQueries.GetQueries
{
    public class GetSongQueryRequest : IRequest<GetSongQueryResponse>
    {
        public int id { get; set; }
    }
}