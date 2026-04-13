using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.ReviewQueries.GetReviewProgramById;
using MoveApi.Application.Features.MediatornDesignPattern.Results.ReviewResults.GetReviewProgramById;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Handlers.ReviewHandles.GetReviewProgramByIdHandle
{
    public class GetReviewSeriesByIdCommandHandle : IRequestHandler<GetReviewSeriesQueryById, List<GetReviewSeriesQueryResultById>>
    {
        private readonly IMapper mapper;
        private readonly MovieContext context;

        public GetReviewSeriesByIdCommandHandle(IMapper mapper, MovieContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<List<GetReviewSeriesQueryResultById>> Handle(GetReviewSeriesQueryById request, CancellationToken cancellationToken)
        {
            var values= await context.Reviews.Where(x=>x.SeriesId==request.Id).ToListAsync(cancellationToken);
            return mapper.Map<List<GetReviewSeriesQueryResultById>>(values);
        }
    }
}
