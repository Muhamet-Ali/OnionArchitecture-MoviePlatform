using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.ReviewQueries;
using MoveApi.Application.Features.MediatornDesignPattern.Results.ReviewResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Handlers.ReviewHandles
{
    public class GetReviewCommandHandle : IRequestHandler<GetReviewQuery, List<GetReviewQureyResult>>
    {
        private readonly IMapper _mapper;
        private readonly MovieContext _context;

        public GetReviewCommandHandle(IMapper mapper, MovieContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<GetReviewQureyResult>> Handle(GetReviewQuery request, CancellationToken cancellationToken)
        {
            var values =await _context.Reviews
                .Include(x=>x.Movie)
                .Include(x=>x.Series)
                .Include(x=>x.Episode)
                .ToListAsync(cancellationToken);

            return _mapper.Map< List<GetReviewQureyResult> >(values);
        }
    }
}
