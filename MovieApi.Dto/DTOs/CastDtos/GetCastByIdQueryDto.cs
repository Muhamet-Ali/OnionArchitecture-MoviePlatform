using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Dto.DTOs.CastDtos
{
    public class GetCastByIdQueryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        public string? OverView { get; set; } //hakkinda
        public string? Biography { get; set; }
        public List<MovieCast> MovieCasts { get; set; } = new();
        public List<SeriesCast> SeriesCasts { get; set; } = new();
        public class MovieCast
        {
            public int MovieId { get; set; }
            public string MovieName { get; set; }
            public string? CharacterName { get; set; } // oynadığı karakter
        }
        public class SeriesCast
        {
            public int SeriesId { get; set; }
            public string SeriesName { get; set; }
            public string? CharacterName { get; set; } // oynadığı karakter
        }
    }
}
