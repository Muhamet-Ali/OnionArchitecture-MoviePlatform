using MediatR;
using MoveApi.Application.Features.MediatornDesignPattern.Results.EpisodeResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Queries.EpisodeQueries
{
    public class GetEpisodeByIdQuery:IRequest<GetEpisodeByIdQueryResult>
    {
        public int Id { get; set; }

        public GetEpisodeByIdQuery(int id)
        {
            Id = id;
        }
    }
}
