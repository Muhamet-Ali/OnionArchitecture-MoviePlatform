using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Commands.EpisodeCommands
{
    public class CreateEpisodeCommand:IRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int EpisodeNumber { get; set; }
        public int SeasonId { get; set; }
    }
}
