using MovieAp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Domain.Entities
{
    public class MovieCast
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int CastId { get; set; }
        

        public string? CharacterName { get; set; } // oynadığı karakter


        public Movie Movie { get; set; }
        public Cast Cast { get; set; }

    }
}
