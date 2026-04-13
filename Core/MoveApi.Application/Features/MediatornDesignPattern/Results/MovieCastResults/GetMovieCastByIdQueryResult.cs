using MovieAp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Results.MovieCastResults
{
    public class GetMovieCastByIdQueryResult
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string MovieName { get; set; }

        public int CastId { get; set; }

        public string CastName { get; set; }
        public string CastImageUrl { get; set; }

        public string? CharacterName { get; set; } // oynadığı karakter




    }
}
