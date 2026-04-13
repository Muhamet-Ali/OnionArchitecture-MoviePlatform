using MediatR;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.SeasonCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Handlers.SeasonHandles
{
    public class RemoveSeasonCommandHandle : IRequestHandler<RemoveSeasonCommand>
    {
        private readonly MovieContext _context;

        public RemoveSeasonCommandHandle(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveSeasonCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.seasons.FindAsync(request.Id);
            _context.seasons.Remove(value);
            await _context.SaveChangesAsync();

        }
    }
}
