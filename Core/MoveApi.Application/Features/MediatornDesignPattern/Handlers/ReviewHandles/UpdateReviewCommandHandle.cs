using AutoMapper;
using MediatR;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.ReviewCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Handlers.ReviewHandles
{
    internal class UpdateReviewCommandHandle : IRequestHandler<UpdateReviewCommand>
    {
        private readonly IMapper _mapper;
        private readonly MovieContext _context;

        public UpdateReviewCommandHandle(IMapper mapper, MovieContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.Reviews.FindAsync(request.Id);
            _mapper.Map(request, value);
            await _context.SaveChangesAsync();

        }
    }
}
