using AutoMapper;
using MediatR;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.CastCommands;
using MovieAp.Domain.Entities;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Handlers.CastHandlers
{
    public class CreateCastCommandHandler : IRequestHandler<CreateCastCommand>
    {
        private readonly IMapper _mapper;
        private readonly MovieContext _context;

        public CreateCastCommandHandler(IMapper mapper, MovieContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(CreateCastCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Cast>(request);

            _context.Casts.Add(entity);

            await _context.SaveChangesAsync();
        }
    }
}
