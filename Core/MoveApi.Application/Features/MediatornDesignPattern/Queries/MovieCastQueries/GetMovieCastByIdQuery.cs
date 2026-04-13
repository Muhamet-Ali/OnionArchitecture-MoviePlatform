using MediatR;
using MoveApi.Application.Features.MediatornDesignPattern.Results.MovieCastResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Queries.MovieCastQueries
{
    public class GetMovieCastByIdQuery:IRequest<GetMovieCastByIdQueryResult>
    {
        public int Id {  get; set; }

        public GetMovieCastByIdQuery(int id)
        {
            Id = id;
        }
    }
}
