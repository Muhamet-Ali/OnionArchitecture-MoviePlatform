using AutoMapper;
using MediatR;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.SeasonCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Handlers.SeasonHandles
{
    public class CreateSeasonCommandHandle : IRequestHandler<CreateSeasonCommand>
    {
        private readonly IMapper _mapper;
        private readonly MovieContext _context;

        public CreateSeasonCommandHandle(IMapper mapper, MovieContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(CreateSeasonCommand request, CancellationToken cancellationToken)
        {
            var values=_mapper.Map<Season>(request);
            _context.seasons.Add(values);   

            await _context.SaveChangesAsync(); 
        }
    }
}
