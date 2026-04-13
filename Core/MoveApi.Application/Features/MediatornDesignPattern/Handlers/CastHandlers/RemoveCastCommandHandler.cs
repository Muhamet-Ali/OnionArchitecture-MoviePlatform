using MediatR;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.CastCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Handlers.CastHandlers
{
    public class RemoveCastCommandHandler:IRequestHandler<RemoveCastCommand>
    {
        private readonly MovieContext _context;

        public RemoveCastCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveCastCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.Casts.FindAsync(request.Id);
           _context.Casts.Remove(value);
            await _context.SaveChangesAsync();
        }
    }
}
