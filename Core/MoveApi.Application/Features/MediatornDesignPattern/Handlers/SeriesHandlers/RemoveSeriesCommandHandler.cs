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
    public class RemoveSeriesCommandHandler : IRequestHandler<RemoveSeriesCommand>
    {
        private readonly MovieContext _context;

        public RemoveSeriesCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveSeriesCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.Serieses.FindAsync(request.Id);
            _context.Serieses.Remove(value);
            await _context.SaveChangesAsync();

        }
    }
}
