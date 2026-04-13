using AutoMapper;
using MediatR;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.SeriesCastQueries;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.SeriesQueries;
using MoveApi.Application.Features.MediatornDesignPattern.Results.SeriesCastResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Handlers.SeriesCastHandler
{
    public class GetSeriesCastByIdCommandHandle : IRequestHandler<GetSeriesCastByIdQuery, GetSeriesCastByIdQueryResult>
    {
        private readonly IMapper _mapper;
        private readonly MovieContext _context;

        public GetSeriesCastByIdCommandHandle(IMapper mapper, MovieContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<GetSeriesCastByIdQueryResult> Handle(GetSeriesCastByIdQuery request, CancellationToken cancellationToken)
        {

            var value = await _context.SeriesCasts.FindAsync(request.Id);
           return  _mapper.Map<GetSeriesCastByIdQueryResult>(value);


        }
    }
}
