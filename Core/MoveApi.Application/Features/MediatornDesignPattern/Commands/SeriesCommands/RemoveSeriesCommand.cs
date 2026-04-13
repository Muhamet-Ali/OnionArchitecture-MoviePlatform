using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Commands.SeriesCommands
{
    public class RemoveSeriesCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveSeriesCommand(int id)
        {
            Id = id;
        }
    }
}
