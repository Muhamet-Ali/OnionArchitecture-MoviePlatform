using AutoMapper;
using MediatR;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.EpisodeCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Handlers.EpisodeHandlers
{
    public class RemoveEpisodeCommandHandle : IRequestHandler<RemoveEpisodeCommand>
    {
        private readonly MovieContext _context;
        public RemoveEpisodeCommandHandle(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveEpisodeCommand request, CancellationToken cancellationToken)
        {
            var value =await _context.Episodes.FindAsync(request.Id);
            _context.Episodes.Remove(value);
            await _context.SaveChangesAsync();
        }
    }
}
