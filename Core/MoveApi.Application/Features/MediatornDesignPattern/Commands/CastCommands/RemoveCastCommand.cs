using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace MoveApi.Application.Features.MediatornDesignPattern.Commands.CastCommands
{
    public class RemoveCastCommand:IRequest
    {
        public int Id { get; set; }
        public RemoveCastCommand(int id)
        {
            this.Id = id;
        }

      


    }
}
