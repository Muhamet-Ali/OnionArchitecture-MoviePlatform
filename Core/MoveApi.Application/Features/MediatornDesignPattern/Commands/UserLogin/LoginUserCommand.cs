using MediatR;
using Microsoft.AspNetCore.Identity;
using MoveApi.Application.Features.MediatornDesignPattern.Results.UserLoginResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Commands.UserLogin
{
    public class LoginUserCommand:IRequest<LoginUserCommandResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }    

    }
}
