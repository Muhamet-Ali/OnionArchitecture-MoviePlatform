using MediatR;
using MoveApi.Application.Features.MediatornDesignPattern.Results.SeriesResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Queries.SeriesQueries
{
    public class GetSeriesByIdQuery:IRequest<GetSeriesByIdQueryResult>
    {
        public int Id { get; set; }

        public GetSeriesByIdQuery(int Id)
        {
            this.Id = Id;
        }
    }
}
