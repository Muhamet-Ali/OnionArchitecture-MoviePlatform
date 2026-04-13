using Azure.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Results.UserLoginResult
{
    public class LoginUserCommandResult
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public string? UserEmail { get; set; }
        public string? AccessToken { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set; }
    }
}
