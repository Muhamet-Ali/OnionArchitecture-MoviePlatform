using AutoMapper;
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
    public class UpdateSeasonCommandHandle : IRequestHandler<UpdateSeasonCommand>
    {
        private readonly IMapper _mapper;
        private readonly MovieContext _context;

        public UpdateSeasonCommandHandle(IMapper mapper, MovieContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(UpdateSeasonCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.seasons.FindAsync(request.Id);
            _mapper.Map(request, value);
            await _context.SaveChangesAsync();

        }
    }
}
