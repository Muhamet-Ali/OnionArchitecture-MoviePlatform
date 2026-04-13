using MediatR;
using Microsoft.AspNetCore.Identity;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.UserRegister;
using MovieApi.Persistence.Context;
using MovieApi.Persistence.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Handlers.UserRegisterHandlers
{
    public class CreateUserRegisterCommandHandler : IRequestHandler<CreateUserRegisterCommand, IdentityResult>
    {
        private readonly MovieContext _context;
        private readonly UserManager<AppUser> _userManager;

        public CreateUserRegisterCommandHandler(UserManager<AppUser> userManager, MovieContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IdentityResult> Handle(CreateUserRegisterCommand request, CancellationToken cancellationToken)
        {
            var User = new AppUser
            {
                Name=request.Name,
                Surname=request.Surname,
                UserName=request.UserName,
                Email=request.Email
            };
            return await _userManager.CreateAsync(User, request.Password);
        }
    }
}
