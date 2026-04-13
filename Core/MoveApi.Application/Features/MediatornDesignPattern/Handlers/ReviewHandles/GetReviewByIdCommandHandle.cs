using AutoMapper;
using MediatR;
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
    internal class GetReviewByIdCommandHandle : IRequestHandler<GetReviewByIdQuery, GetReviewByIdQureyResult>
    {
        private readonly IMapper _mapper;
        private readonly MovieContext _context;

        public GetReviewByIdCommandHandle(IMapper mapper, MovieContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<GetReviewByIdQureyResult> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _context.Reviews.FindAsync(request.Id);
            return _mapper.Map<GetReviewByIdQureyResult>(value);

        }
    }
}
