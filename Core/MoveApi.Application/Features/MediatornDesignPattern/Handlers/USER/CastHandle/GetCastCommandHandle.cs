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
    public class GetCastCommandHandle : IRequestHandler<UserGetCastQuery, List<UserGetCastQueryResult>>

    {
        private readonly IMapper _mapper;
        private readonly MovieContext _context;

        public GetCastCommandHandle(IMapper mapper, MovieContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<UserGetCastQueryResult>> Handle(UserGetCastQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Casts.ToListAsync(cancellationToken);

            return _mapper.Map<List<UserGetCastQueryResult>>(values);

        }
    }
}
