using MediatR;
using Microsoft.EntityFrameworkCore;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.SeriesQueries;
using MoveApi.Application.Features.MediatornDesignPattern.Results.SeriesResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Handlers.SeriesHandlers
{
    public class GetSeriesByIdCommandHandler : IRequestHandler<GetSeriesByIdQuery,GetSeriesByIdQueryResult>
    {
        private readonly MovieContext _context;

        public GetSeriesByIdCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<GetSeriesByIdQueryResult> Handle(GetSeriesByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _context.Serieses.FindAsync(request.Id);


            var seasonsCount = await _context.seasons
                .CountAsync(x => x.SeriesId == request.Id, cancellationToken);

            var episodesCount = await _context.Episodes
                .CountAsync(x => x.Season.SeriesId == request.Id, cancellationToken);

            var reviewsCount = await _context.Reviews
                .CountAsync(x => x.SeriesId == request.Id, cancellationToken);

            return new GetSeriesByIdQueryResult
            {
                Id = value.Id,
                Title = value.Title,
                Description = value.Description,
                CoverImageUrl = value.CoverImageUrl,
                Rating = value.Rating,
                FirstAirDate = value.FirstAirDate,
                AverageEpisodeDuration = value.AverageEpisodeDuration,
                Status = value.Status,
                CategoryId = value.CategoryId,
                seasonsCount= seasonsCount,
                episodesCount= episodesCount,
                reviewsCount= reviewsCount
            };
        }
    }
}
