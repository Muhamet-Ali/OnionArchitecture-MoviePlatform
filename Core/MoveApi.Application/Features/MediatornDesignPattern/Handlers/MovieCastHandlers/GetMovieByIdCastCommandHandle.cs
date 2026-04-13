using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.MovieCastQueries;
using MoveApi.Application.Features.MediatornDesignPattern.Results.MovieCastResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Handlers.MovieCastHandlers
{
    public class GetMovieByIdCastCommandHandle : IRequestHandler<GetMovieCastByIdQuery, GetMovieCastByIdQueryResult>
    {
        private readonly IMapper _mapper;
        private readonly MovieContext _context;

        public GetMovieByIdCastCommandHandle(IMapper mapper, MovieContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<GetMovieCastByIdQueryResult> Handle(GetMovieCastByIdQuery request, CancellationToken cancellationToken)
        {
             var value= await _context.MovieCasts.Where(x => x.Id == request.Id).
                Select(x => new GetMovieCastByIdQueryResult
                {
                    Id = x.Id,
                    MovieId = x.MovieId,
                    MovieName=x.Movie.Title,
                    CastId = x.CastId,
                    CastName = x.Cast.Name,
                    CastImageUrl = x.Cast.ImageUrl,
                    CharacterName = x.CharacterName,

                }).FirstOrDefaultAsync(cancellationToken);
            return value;

        }
    }
}
