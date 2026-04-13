using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.MovieCastQueries;
using MoveApi.Application.Features.MediatornDesignPattern.Results.MovieCastResults;
using MovieAp.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Handlers.MovieCastHandlers
{
    public class GetMovieCastCommandHandle : IRequestHandler<GetMovieCastQuery, List<GetMovieCastQueryResult>>
    {
        private readonly IMapper _mapper;
        private readonly MovieContext _context;

        public GetMovieCastCommandHandle(IMapper mapper, MovieContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<GetMovieCastQueryResult>> Handle(GetMovieCastQuery request, CancellationToken cancellationToken)
        {
             return  await _context.MovieCasts.
                Where(x=>x.MovieId == request.MovieId )
                .Select(x=>new GetMovieCastQueryResult {
                 Id=x.Id,
                 MovieId= x.MovieId,
                 CastId= x.CastId,
                 Name=x.Cast.Name,
                 ImageUrl= x.Cast.ImageUrl,
                 CharacterName=x.CharacterName
                }).ToListAsync(cancellationToken);

        }
    }
}
