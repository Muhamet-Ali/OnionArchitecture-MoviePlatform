using MoveApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieAp.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler
    {
        private readonly MovieContext _context;
        public CreateCategoryCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handler(CreateCategoryCommands command)
        {
            _context.Categories.Add(new Category
            {
                Name=command.Name,
            });
            await _context.SaveChangesAsync();
        }


    }
}
