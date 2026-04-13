using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.EpisodeQueries;
using MoveApi.Application.Features.MediatornDesignPattern.Results.EpisodeResult;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Handlers.EpisodeHandlers
{
    public class GetEpisodeCommandHandle : IRequestHandler<GetEpisodeQuery, List<GetEpisodeQueryResult>>
    {
        private readonly IMapper _mapper;
        private readonly MovieContext _context;

        public GetEpisodeCommandHandle(IMapper mapper, MovieContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<GetEpisodeQueryResult>> Handle(GetEpisodeQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Episodes
            .Include(x => x.Season)
            .ToListAsync();
            return _mapper.Map<List<GetEpisodeQueryResult>>(values);
        }
    }
}
