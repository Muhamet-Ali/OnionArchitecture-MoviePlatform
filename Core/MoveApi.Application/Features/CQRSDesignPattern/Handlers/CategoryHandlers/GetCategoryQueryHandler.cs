using Microsoft.EntityFrameworkCore;
using MoveApi.Application.Features.CQRSDesignPattern.Results.CategoryResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly MovieContext _context;

        public GetCategoryQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var values = await _context.Categories
                .Select(x => new GetCategoryQueryResult
                {
                    Id = x.Id,
                    Name = x.Name,

                    MovieCount = x.Movies.Count(),

                    SeriesCount = x.Serieses.Count(),

                    ReviewCount =
                        x.Movies.SelectMany(m => m.Reviews).Count() +
                        x.Serieses.SelectMany(s => s.Reviews).Count(),

                    AvgRating =
                        x.Movies.SelectMany(m => m.Reviews)
                        .Select(r => (double?)r.UserRating)
                        .Concat(
                            x.Serieses.SelectMany(s => s.Reviews)
                            .Select(r => (double?)r.UserRating)
                        ).Average() ?? 0
                })
                .ToListAsync();

            return values;
        }
    }
}
