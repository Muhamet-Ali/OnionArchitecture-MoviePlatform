using MovieApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAp.Domain.Entities
{
    public class Cast //oyuncu
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

    }
}
