using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Commands.EpisodeCommands
{
    public class RemoveEpisodeCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveEpisodeCommand(int id)
        {
            Id = id;
        }
    }
}
