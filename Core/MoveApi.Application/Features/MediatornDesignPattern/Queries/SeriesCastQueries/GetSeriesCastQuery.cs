using MediatR;
using MoveApi.Application.Features.MediatornDesignPattern.Results.SeriesCastResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Queries.SeriesCastQueries
{
    public class GetSeriesCastQuery:IRequest<List<GetSeriesCastQueryResult>>
    {
        public int SeriesId { get; set; }

        public GetSeriesCastQuery(int seriesId)
        {
            SeriesId = seriesId;
        }
    }
}
