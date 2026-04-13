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
    public class UpdateEpisodeCommandHandle : IRequestHandler<UpdateEpisodeCommand>
    {
        private readonly MovieContext _context;
        private readonly IMapper _mapper;

        public UpdateEpisodeCommandHandle(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Handle(UpdateEpisodeCommand request, CancellationToken cancellationToken)
        {
            var value =await _context.Episodes.FindAsync(request.Id);
            _mapper.Map(request,value);
            await _context.SaveChangesAsync();

        }
    }
}
