using MediatR;
using MoveApi.Application.Features.MediatornDesignPattern.Results.MovieCastResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Queries.MovieCastQueries
{
    public class GetMovieCastQuery:IRequest<List< GetMovieCastQueryResult>>
    {
        public int MovieId { get; set; }

        public GetMovieCastQuery(int movieId)
        {
            MovieId = movieId;
        }
    }
}
