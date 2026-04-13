using AutoMapper;
using MediatR;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.CastQueries;
using MoveApi.Application.Features.MediatornDesignPattern.Results.CastResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace MoveApi.Application.Features.MediatornDesignPattern.Handlers.CastHandlers
{
    public class GetCastByIdCommandHandler:IRequestHandler<GetCastByIdQuery,GetCastByIdQueryResult>
    {
        private readonly MovieContext _context;
        private readonly IMapper _mapper;

        public GetCastByIdCommandHandler(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetCastByIdQueryResult> Handle(GetCastByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _context.Casts
           .Where(x => x.Id == request.Id)
           .Select(x => new GetCastByIdQueryResult
           {
               Id = x.Id,
               Title = x.Title,
               Name = x.Name,
               Surname = x.Surname,
               ImageUrl = x.ImageUrl,
               OverView = x.OverView,
               Biography = x.Biography,

               FilmographyCount = x.MovieCasts.Count + x.SeriesCasts.Count,

               Movies = x.MovieCasts
                   .Select(mc => mc.Movie.Title)
                   .ToList(),

               Serieses = x.SeriesCasts
                   .Select(sc => sc.series.Title)
                   .ToList()
           })
           .FirstOrDefaultAsync();

                return value;

        }
    }
}
