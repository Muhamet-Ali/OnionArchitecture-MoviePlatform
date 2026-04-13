using MediatR;
using MoveApi.Application.Features.MediatornDesignPattern.Results.USER.SeriesResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Queries.USER.SeriesQueries
{
    public class GetSeriesDetailQuery:IRequest<GetSeriesDetailQueryResult>
    {
        public GetSeriesDetailQuery(int id, string userId)
        {
            Id = id;
            UserId = userId;
        }

        public int Id { get; set; }
        public string UserId { get; set; }

       
    }
}
