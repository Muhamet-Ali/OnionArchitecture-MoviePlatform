using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.USER.HomePageQueries;
using MoveApi.Application.Features.MediatornDesignPattern.Results.USER.HomePageResult;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Handlers.USER.HomePageHandle
{
    public class GetHomePageCommandHandle:IRequestHandler<HomePageQuery, List<HomePageQuerytResult>>
    {
        private readonly IMapper _mapper;
        private readonly MovieContext _context;

        public GetHomePageCommandHandle(IMapper mapper, MovieContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<HomePageQuerytResult>> Handle(HomePageQuery request, CancellationToken cancellationToken)
        {

            var movies = await _context.Movies
               .Include(x => x.Category)
               .ToListAsync(cancellationToken);

            var serieses = await _context.Serieses
                .Include(x => x.Category)
                .ToListAsync(cancellationToken);

            var movieDto = _mapper.Map<List<HomePageQuerytResult>>(movies);
            var seriesesDto = _mapper.Map<List<HomePageQuerytResult>>(serieses);

            return movieDto.Concat(seriesesDto)
                .OrderBy(x => Guid.NewGuid())
                .Take(10)
                .ToList();
        }
    }
}
