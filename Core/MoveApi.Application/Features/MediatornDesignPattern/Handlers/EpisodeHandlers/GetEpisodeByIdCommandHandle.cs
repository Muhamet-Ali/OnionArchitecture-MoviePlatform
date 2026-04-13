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
    public class GetEpisodeByIdCommandHandle : IRequestHandler<GetEpisodeByIdQuery, GetEpisodeByIdQueryResult>
    {
        private readonly IMapper _mapper;
        private readonly MovieContext _context;

        public GetEpisodeByIdCommandHandle(IMapper mapper, MovieContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<GetEpisodeByIdQueryResult> Handle(GetEpisodeByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _context.Episodes
               .Include(x => x.Season)
                   .ThenInclude(s => s.Movie)
               .Include(x => x.Season)
                   .ThenInclude(s => s.Series)
               .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            return _mapper.Map<GetEpisodeByIdQueryResult>(value);

        }
    }
}
