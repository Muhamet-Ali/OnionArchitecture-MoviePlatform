using AutoMapper;
using MediatR;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.SeriesCastCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Handlers.SeriesCastHandler
{
    internal class RemoveSeriesCastCommandHandle : IRequestHandler<RemoveSeriesCastCommand>
    {
        private readonly IMapper _mapper;
        private readonly MovieContext _context;

        public RemoveSeriesCastCommandHandle(IMapper mapper, MovieContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(RemoveSeriesCastCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.SeriesCasts.FindAsync(request.Id);
            _context.SeriesCasts.Remove(value);
            await _context.SaveChangesAsync();

        }
    }
}
