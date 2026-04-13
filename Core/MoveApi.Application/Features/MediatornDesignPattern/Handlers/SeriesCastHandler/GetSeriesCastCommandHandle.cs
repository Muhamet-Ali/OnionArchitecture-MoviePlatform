using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.SeriesCastQueries;
using MoveApi.Application.Features.MediatornDesignPattern.Results.SeriesCastResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Handlers.SeriesCastHandler
{
    public class GetSeriesCastCommandHandle : IRequestHandler<GetSeriesCastQuery, List<GetSeriesCastQueryResult>>
    {
        private readonly IMapper _mapper;
        private readonly MovieContext _context;

        public GetSeriesCastCommandHandle(IMapper mapper, MovieContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<GetSeriesCastQueryResult>> Handle(GetSeriesCastQuery request, CancellationToken cancellationToken)
        {
            var Values = await _context.SeriesCasts.Where(x=> x.SeriesId == request.SeriesId)
                .Select(x =>new  GetSeriesCastQueryResult{
                    SeriesId = x.SeriesId,
                    SeriesName=x.series.Title,
                    CastId=x.CastId,
                    CastName=x.Cast.Name,
                    CastImageUrl=x.Cast.ImageUrl,
                    CharacterName=x.CharacterName,
                }).ToListAsync(cancellationToken);

            return Values;

            
        }
    }
}
