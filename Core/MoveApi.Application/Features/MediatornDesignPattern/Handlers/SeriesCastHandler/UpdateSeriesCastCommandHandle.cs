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
    public class UpdateSeriesCastCommandHandle : IRequestHandler<UpdateSeriesCastCommand>
    {
        private readonly IMapper _mapper;
        private readonly MovieContext _context;

        public UpdateSeriesCastCommandHandle(IMapper mapper, MovieContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(UpdateSeriesCastCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.SeriesCasts.FindAsync(request.Id);
            _mapper.Map(request, value);
            await _context.SaveChangesAsync();
        }
    }
}
