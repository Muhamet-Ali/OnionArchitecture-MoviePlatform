using MediatR;
using MoveApi.Application.Features.MediatornDesignPattern.Results.SeasonResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Queries.SeasonQueries
{
    public class GetSeasonByIdQuery:IRequest<GetSeasonByIdQueryResult>
    {
        public int Id { get; set; }

        public GetSeasonByIdQuery(int id)
        {
            Id = id;
        }
    }
}
