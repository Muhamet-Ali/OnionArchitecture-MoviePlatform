using MediatR;
using MovieApi.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Commands.UserPurchaseCommands
{
    public class CreatePurchaseCommand : IRequest
    {
        public string UserId { get; set; }
        public int ContentId { get; set; }
        public ContentType ContentType { get; set; }
    }
}
