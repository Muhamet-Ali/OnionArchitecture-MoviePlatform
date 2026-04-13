using Microsoft.EntityFrameworkCore;
using MoveApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries;
using MoveApi.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieByIdQueryHandler
    {
        private readonly MovieContext _context;

        public GetMovieByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<GetMovieByIdQueryResult> Handle(GetMovieByIdQuery query)
        {
            //  public int SeasonsCount { get; set; }
        //public int EpisodesCount { get; set; }
        var value = await _context.Movies
            .Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.Id == query.Id);

            var seasonsCount = await _context.seasons
                .CountAsync(x => x.MovieId == query.Id);
            var episodesCount = await _context.Episodes
                .Where(x => x.Season.MovieId == query.Id)
                .CountAsync();
            var reviewCount = await _context.Reviews
                .CountAsync(x => x.MovieId == query.Id);

            return new GetMovieByIdQueryResult {
                Id=value.Id,
                Title = value.Title,
                CoverImageUrl = value.CoverImageUrl,
                Rating = value.Rating,
                Description = value.Description,
                Duration = value.Duration,
                RelaseDate = value.RelaseDate,
                CreatedYear = value.CreatedYear,
                Status = value.Status,
                CategoryId = value.Category.Id,
                CategoryName=value.Category.Name,
                ReviewCount = reviewCount,
                SeasonsCount =seasonsCount,
                EpisodesCount=episodesCount,
            };
        }
    }
}
