using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Commands.SeriesCastCommands
{
    public class UpdateSeriesCastCommand:IRequest
    {
        public int Id { get; set; }

        public int SeriesId { get; set; }

        public int CastId { get; set; }

        public string? CharacterName { get; set; } // oynadığı karakter

    }
}
