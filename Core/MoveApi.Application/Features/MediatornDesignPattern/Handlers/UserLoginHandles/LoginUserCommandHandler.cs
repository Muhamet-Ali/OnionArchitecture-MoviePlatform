using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.UserLogin;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.UserRegister;
using MoveApi.Application.Features.MediatornDesignPattern.Results.UserLoginResult;
using MovieApi.Persistence.Context;
using MovieApi.Persistence.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApi.Persistence.Interfaces;

namespace MoveApi.Application.Features.MediatornDesignPattern.Handlers.UserLoginHandles
{
    public  class LoginUserCommandHandler: IRequestHandler<LoginUserCommand, LoginUserCommandResult>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;

        public LoginUserCommandHandler(UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<LoginUserCommandResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
           var User= await _userManager.FindByEmailAsync(request.Email);

            if (User == null)
            {
                return new LoginUserCommandResult
                {
                    IsSuccess = false,
                    Message = "Not found User",
                };
            }

            var PasswordCorrect= await _userManager.CheckPasswordAsync(User,request.Password);
            if(!PasswordCorrect)
            {
                return new LoginUserCommandResult
                {
                    IsSuccess = false,
                    Message = "Password false",
                };
            }

            var roles = await _userManager.GetRolesAsync(User);
            var token = _tokenService.CreateToken(User, roles);
            return new LoginUserCommandResult
            {
                IsSuccess = true,
                Message = "Login has been sucfully",
                UserId = User.Id,
                UserName = User.UserName,
                UserEmail=User.Email,
                AccessToken = token
            };
        }
    }
}
