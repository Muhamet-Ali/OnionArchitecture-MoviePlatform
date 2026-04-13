using AutoMapper;
using MediatR;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.ReviewCommands;
using MovieAp.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Handlers.ReviewHandles
{
    internal class CreateReviewCommandHandle : IRequestHandler<CreateReviewCommand>
    {
        private readonly IMapper _mapper;
        private readonly MovieContext _context;

        public CreateReviewCommandHandle(IMapper mapper, MovieContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var value=_mapper.Map<Review>(request);
            _context.Reviews.Add(value);    
            await _context.SaveChangesAsync();

        }
    }
}
