using AutoMapper;
using MediatR;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.EpisodeCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Handlers.EpisodeHandlers
{
    public class CreateEpisodeCommandHandle : IRequestHandler<CreateEpisodeCommand>
    {
        private readonly MovieContext _context;
        private readonly IMapper _mapper;

        public CreateEpisodeCommandHandle(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Handle(CreateEpisodeCommand request, CancellationToken cancellationToken)
        {
            var Entity = _mapper.Map<Episode>(request);
             _context.Episodes.Add(Entity);
            await _context.SaveChangesAsync();

        }
    }
}
