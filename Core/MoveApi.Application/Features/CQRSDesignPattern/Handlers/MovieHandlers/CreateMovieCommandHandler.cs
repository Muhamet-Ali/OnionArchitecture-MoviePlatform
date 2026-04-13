using MoveApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieAp.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class CreateMovieCommandHandler
    {
        private readonly MovieContext _context;
        public CreateMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handler(CreateMovieCommands command)
        {
            _context.Movies.Add(new Movie
            {
                Title = command.Title,
                CoverImageUrl = command.CoverImageUrl,
                Rating = command.Rating,
                Description = command.Description,
                Duration = command.Duration,
                RelaseDate = command.RelaseDate,
               CreatedYear = command.CreatedYear,
               Status = command.Status,
               CategoryId = command.CategoryId
            });
            await _context.SaveChangesAsync();
        }

    }
}
