using MovieAp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Domain.Entities
{
    public class SeriesCast
    {
        public int Id { get; set; }

        public int SeriesId { get; set; }

        public int CastId { get; set; }

        public string? CharacterName { get; set; } // oynadığı karakter
        public Series series { get; set; }
        public Cast Cast { get; set; }



    }
}
