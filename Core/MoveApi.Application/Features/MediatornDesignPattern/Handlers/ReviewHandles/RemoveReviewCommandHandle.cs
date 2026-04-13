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
    public class RemoveReviewCommandHandle : IRequestHandler<RemoveReviewCommand>
    {
        private readonly MovieContext _context;

        public RemoveReviewCommandHandle(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveReviewCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.Reviews.FindAsync(request.Id);
            _context.Reviews.Remove(value);
            await _context.SaveChangesAsync();
        }
    }
}
