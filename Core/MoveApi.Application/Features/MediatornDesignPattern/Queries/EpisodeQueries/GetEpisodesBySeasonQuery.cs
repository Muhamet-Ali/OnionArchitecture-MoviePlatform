using MediatR;
using MoveApi.Application.Features.MediatornDesignPattern.Results.EpisodeResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Queries.EpisodeQueries
{
    public class GetEpisodesBySeasonQuery:IRequest<List <GetEpisodesBySeasonQueryResult>>
    {
        public int SeasonId { get; set; }

        public GetEpisodesBySeasonQuery(int SeasonId)
        {
            this.SeasonId = SeasonId;
        }
    }
}
