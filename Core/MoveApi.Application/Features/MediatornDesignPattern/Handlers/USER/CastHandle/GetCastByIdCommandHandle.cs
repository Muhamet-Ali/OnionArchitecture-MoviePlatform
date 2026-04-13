using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.CastQueries;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.USER.CastQueries;
using MoveApi.Application.Features.MediatornDesignPattern.Results.CastResults;
using MoveApi.Application.Features.MediatornDesignPattern.Results.USER.CastResult;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Handlers.USER.CastHandle
{
    public class GetCastByIdCommandHandle :IRequestHandler<UserGetCastByIdQuery,UserGetCastByIdQueryResult>
    {
        private readonly IMapper _mapper;
        private readonly MovieContext _context;

        public GetCastByIdCommandHandle(IMapper mapper, MovieContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<UserGetCastByIdQueryResult> Handle(UserGetCastByIdQuery request, CancellationToken cancellationToken)
        {

            var values = await _context.Casts.Where(x => x.Id == request.Id).
                 Select(x => new UserGetCastByIdQueryResult
                 {
                     Id = x.Id,
                     Title = x.Title,
                     Name = x.Name,
                     Surname = x.Surname,
                     ImageUrl = x.ImageUrl,
                     OverView = x.OverView,
                     Biography = x.Biography,

                     MovieCasts=x.MovieCasts.Select(mc=> new UserGetCastByIdQueryResult.MovieCast
                     {
                         MovieId = mc.MovieId,
                         MovieName=mc.Movie.Title,
                         CharacterName=mc.CharacterName,

                     }).ToList(),
                     SeriesCasts=x.SeriesCasts.Select(sc=>new UserGetCastByIdQueryResult.SeriesCast
                     {
                         SeriesId = sc.SeriesId,
                         SeriesName=sc.series.Title,
                         CharacterName=sc.CharacterName,    
                     }).ToList(),


                 }).FirstOrDefaultAsync();

            return values;

        }




    }
}
