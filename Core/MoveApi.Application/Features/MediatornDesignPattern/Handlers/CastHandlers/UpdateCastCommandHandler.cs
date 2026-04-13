using AutoMapper;
using MediatR;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.CastCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Handlers.CastHandlers
{
    public class UpdateCastCommandHandler:IRequestHandler<UpdateCastCommand>
    {
        private readonly MovieContext _context;
        private readonly IMapper _mapper;

        public UpdateCastCommandHandler(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Handle(UpdateCastCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.Casts.FindAsync(request.Id);
           

            _mapper.Map(request, value);

            await _context.SaveChangesAsync();
            
        }
    }
}
