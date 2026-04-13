using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands
{
    public class RemoveMovieCommands
    {
        public RemoveMovieCommands(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
       
    }
}
