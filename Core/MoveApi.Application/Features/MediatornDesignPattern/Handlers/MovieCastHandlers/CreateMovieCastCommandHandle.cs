using AutoMapper;
using MediatR;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.CastCommands;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.MovieCastCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Handlers.MovieCastHandlers
{
    public class CreateMovieCastCommandHandle : IRequestHandler<CreateMovieCastCommand>
    {
        private readonly IMapper _mapper;
        private readonly MovieContext _context;

        public CreateMovieCastCommandHandle(IMapper mapper, MovieContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public async Task Handle(CreateMovieCastCommand request, CancellationToken cancellationToken)
        {
            var Values = _mapper.Map<MovieCast>(request);
            _context.MovieCasts.Add(Values);
            await _context.SaveChangesAsync();
        }
    }
}
