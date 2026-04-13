using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.CastQueries;
using MoveApi.Application.Features.MediatornDesignPattern.Results.CastResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Handlers.CastHandlers
{
    public class GetCastCommandHandler:IRequestHandler<GetCastQuery,List<GetCastQueryResult>>
    {
        private readonly MovieContext _context;
        private readonly IMapper _mapper;

        public GetCastCommandHandler(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetCastQueryResult>> Handle(GetCastQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Casts
                .Include(x => x.MovieCasts)
                .Include(x => x.SeriesCasts)
                .ToListAsync();
            return _mapper.Map<List<GetCastQueryResult>>(values);
            
        }
    }
}
