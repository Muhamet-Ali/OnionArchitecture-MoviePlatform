using MediatR;
using MoveApi.Application.Features.MediatornDesignPattern.Results.USER.MovieResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Queries.USER.MovieQueries
{
    public class GetMovieDetailQuery:IRequest<GetMovieDetailQueryResult>
    {
        public int Id { get; set; }
        public string UserId { get; set; } // ← ekle

        public GetMovieDetailQuery(int id, string userId)
        {
            Id = id;
            UserId = userId;
        }

      
    }
}
