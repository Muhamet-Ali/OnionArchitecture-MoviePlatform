using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.SeasonQueries;
using MoveApi.Application.Features.MediatornDesignPattern.Results.SeasonResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Handlers.SeasonHandles
{
    public class GetSeasonByIdCommandHandle : IRequestHandler<GetSeasonByIdQuery, GetSeasonByIdQueryResult>
    {
        private readonly IMapper _mapper;
        private readonly MovieContext _context;

        public GetSeasonByIdCommandHandle(IMapper mapper, MovieContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<GetSeasonByIdQueryResult> Handle(GetSeasonByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.seasons
              .Include(x => x.Movie)
              .Include(x => x.Series)
              .FirstOrDefaultAsync(x => x.Id == request.Id);
            return _mapper.Map<GetSeasonByIdQueryResult>(values);


        }
    }
}
