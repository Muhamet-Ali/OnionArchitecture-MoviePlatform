using MediatR;
using MoveApi.Application.Features.MediatornDesignPattern.Results.SeasonResults;
using MoveApi.Application.Features.MediatornDesignPattern.Results.SeriesCastResults;
using MoveApi.Application.Features.MediatornDesignPattern.Results.SeriesResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Queries.SeriesCastQueries
{
    public class GetSeriesCastByIdQuery:IRequest<GetSeriesCastByIdQueryResult>
    {
        public int Id { get; set; }

        public GetSeriesCastByIdQuery(int id)
        {
            Id = id;
        }
    }
}
