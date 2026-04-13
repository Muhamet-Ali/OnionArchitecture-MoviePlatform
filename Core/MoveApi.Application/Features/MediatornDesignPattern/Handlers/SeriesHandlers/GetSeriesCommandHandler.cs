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
    public class GetSeriesCommandHandler : IRequestHandler<GetSeriesQuery, List<GetSeriesQueryResult>>
    {
        private readonly MovieContext _context;

        public GetSeriesCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<List<GetSeriesQueryResult>> Handle(GetSeriesQuery request, CancellationToken cancellationToken)
        {
            var Values = await _context.Serieses.Include(x=>x.Category).ToListAsync();

            return Values.Select(x=> new GetSeriesQueryResult {
                Id=x.Id,
                Title = x.Title,
                Description =x.Description,
                CoverImageUrl = x.CoverImageUrl,
                Rating = x.Rating,
                FirstAirDate = x.FirstAirDate,
                AverageEpisodeDuration = x.AverageEpisodeDuration,
                Status = x.Status,
                CategoryId = x.CategoryId,
                CategoryName=x.Category.Name,
            }).ToList();
            
        }
    }
}
