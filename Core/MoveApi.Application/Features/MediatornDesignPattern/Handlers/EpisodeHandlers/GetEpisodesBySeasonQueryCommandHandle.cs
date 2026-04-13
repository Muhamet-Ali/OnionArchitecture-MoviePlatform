using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.EpisodeQueries;
using MoveApi.Application.Features.MediatornDesignPattern.Results.EpisodeResult;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Handlers.EpisodeHandlers
{
    public class GetEpisodesBySeasonQueryCommandHandle : IRequestHandler<GetEpisodesBySeasonQuery, List<GetEpisodesBySeasonQueryResult>>
    {
        private readonly IMapper _mapper;
        private readonly MovieContext _context;

        public GetEpisodesBySeasonQueryCommandHandle(IMapper mapper, MovieContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<GetEpisodesBySeasonQueryResult>> Handle(GetEpisodesBySeasonQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Episodes
            .Where(x => x.SeasonId == request.SeasonId)
            .Include(x => x.Season)
            .ToListAsync();

            return _mapper.Map<List<GetEpisodesBySeasonQueryResult>>(values);
        }
    }
}
