using Microsoft.EntityFrameworkCore;
using MoveApi.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MoveApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieQueryHandler
    {
        private readonly MovieContext _context;

        public GetMovieQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<List<GetMovieQueryResult>> Handle()
        {
            var Entity =await _context.Movies.Include(query => query.Category).ToListAsync();

        
            return Entity.Select(x=> new GetMovieQueryResult {
                Id=x.Id,
                Title = x.Title,
                CoverImageUrl = x.CoverImageUrl,
                Rating = x.Rating,
                Description = x.Description,
                Duration = x.Duration,
                RelaseDate = x.RelaseDate,
                CreatedYear = x.CreatedYear,
                Status = x.Status,
                CategoryId = x.CategoryId,
                CategoryName=x.Category.Name,
                SeasonsCount = _context.seasons.Count(s => s.MovieId == x.Id),
                EpisodesCount = _context.Episodes
                    .Count(e => e.Season.MovieId == x.Id)


            }).ToList();
        }
    }
}
