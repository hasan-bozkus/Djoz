using MediatR;

namespace Djoz.Application.Features.CQRSPattern.Queries.SongQueries.ListQueries
{
    public class ResultSongListQueryRequest : IRequest<List<ResultSongListQueryResponse>>
    {
    }
}