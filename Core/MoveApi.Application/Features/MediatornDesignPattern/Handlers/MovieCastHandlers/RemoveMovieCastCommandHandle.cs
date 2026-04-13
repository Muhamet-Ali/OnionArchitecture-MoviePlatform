using AutoMapper;
using MediatR;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.MovieCastCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Handlers.MovieCastHandlers
{
    public class RemoveMovieCastCommandHandle : IRequestHandler<RemoveMovieCastCommand>
    {
        private readonly IMapper _mapper;
        private readonly MovieContext _context;

        public RemoveMovieCastCommandHandle(IMapper mapper, MovieContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(RemoveMovieCastCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.MovieCasts.FindAsync(request.Id);
            _context.MovieCasts.Remove(value);
            await _context.SaveChangesAsync();
        }
    }
}
