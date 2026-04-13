using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Commands.SeriesCastCommands
{
    public class RemoveSeriesCastCommand:IRequest
    {
        public int Id {  get; set; }

        public RemoveSeriesCastCommand(int id)
        {
            Id = id;
        }
    }
}
