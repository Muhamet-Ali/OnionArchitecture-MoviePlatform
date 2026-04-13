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
    public class GetReviewEpisodeCommandHandle : IRequestHandler<GetReviewEpisodeQuery, List<GetReviewEpisodeQureyResult>>
    {
        private readonly IMapper mapper;
        private readonly MovieContext context;

        public GetReviewEpisodeCommandHandle(IMapper mapper, MovieContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<List<GetReviewEpisodeQureyResult>> Handle(GetReviewEpisodeQuery request, CancellationToken cancellationToken)
        {
            var values=await context.Reviews.Where(x=>x.EpisodeId.HasValue).ToListAsync(cancellationToken);
            return mapper.Map<List<GetReviewEpisodeQureyResult>>(values);
        }
    }
}
