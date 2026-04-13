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
    public class UpdateMovieCommandHandler
    {
        private readonly MovieContext _context;

        public UpdateMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task Handle(UpdateMovieCommands command)
        {
            var value = await _context.Movies.FindAsync(command.Id);

            value.Title= command.Title;
            value.CoverImageUrl = command.CoverImageUrl;
            value.Description = command.Description;
            value.Duration = command.Duration;
            value.RelaseDate = command.RelaseDate;
            value.CreatedYear = command.CreatedYear;
            value.Status = command.Status;
            value.CategoryId = command.CategoryId;

            await _context.SaveChangesAsync();
        }
    }
}
