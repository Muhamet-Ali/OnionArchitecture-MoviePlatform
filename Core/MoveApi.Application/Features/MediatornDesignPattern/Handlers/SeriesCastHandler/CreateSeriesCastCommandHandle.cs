using AutoMapper;
using MediatR;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.SeriesCastCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Handlers.SeriesCastHandler
{
    public class CreateSeriesCastCommandHandle : IRequestHandler<CreateSeriesCastCommand>
    {
        private readonly IMapper _mapper;
        private readonly MovieContext _context;

        public CreateSeriesCastCommandHandle(IMapper mapper, MovieContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(CreateSeriesCastCommand request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<SeriesCast>(request);
            _context.SeriesCasts.Add(value);
            await _context.SaveChangesAsync();
        }
    }
}
