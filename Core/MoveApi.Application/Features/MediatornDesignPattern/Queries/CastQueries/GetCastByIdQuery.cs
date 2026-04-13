using MediatR;
using MoveApi.Application.Features.MediatornDesignPattern.Results.CastResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Queries.CastQueries
{
    public class GetCastByIdQuery:IRequest<GetCastByIdQueryResult>
    {
        public GetCastByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
