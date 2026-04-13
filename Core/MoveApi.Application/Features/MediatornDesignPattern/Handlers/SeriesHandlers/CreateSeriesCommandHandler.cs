using MediatR;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.SeriesCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Handlers.SeriesHandlers
{
    public class CreateSeriesCommandHandler:IRequestHandler<CreateSeriesCommand>
    {
        private readonly MovieContext _context;

        public CreateSeriesCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateSeriesCommand request, CancellationToken cancellationToken)
        {
            _context.Serieses.Add(new MovieApi.Domain.Entities.Series
            {
                Title = request.Title,
                CoverImageUrl = request.CoverImageUrl,
                Description = request.Description,
                Rating = request.Rating,
                FirstAirDate = request.FirstAirDate,
                AverageEpisodeDuration = request.AverageEpisodeDuration,
                Status = request.Status,
                CategoryId = request.CategoryId,
            }
                );
            await _context.SaveChangesAsync();
        }
    }
}
