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
    public class UpdateSeriesCommandHandler:IRequestHandler<UpdateSeriesCommand>
    {
        private readonly MovieContext _context;

        public UpdateSeriesCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateSeriesCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.Serieses.FindAsync(request.Id);
            value.Title = request.Title;
            value.CoverImageUrl= request.CoverImageUrl;
            value.Rating = request.Rating;
            value.Description = request.Description;
            value.FirstAirDate = request.FirstAirDate;
            value.AverageEpisodeDuration = request.AverageEpisodeDuration;
            value.Status = request.Status;
            value.CategoryId= request.CategoryId;
            await _context.SaveChangesAsync();


        }
    }
}
