using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Commands.MovieCastCommands
{
    public class RemoveMovieCastCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveMovieCastCommand(int id)
        {
            Id = id;
        }
    }
}
