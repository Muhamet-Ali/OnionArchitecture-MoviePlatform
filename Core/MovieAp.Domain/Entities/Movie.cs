using MovieApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAp.Domain.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public decimal Rating { get; set; } //filim puani
        public string Description { get; set; }
        public int Duration { get; set; } //film suresu
        public DateTime RelaseDate { get; set; }
        public string CreatedYear { get; set; }
        public bool Status { get; set; } //afktif pasif
        public int  CategoryId { get; set; }
        public int Price { get; set; }
        public Category Category { get; set; }


        //aldiklari seyler
        public List<Review>Reviews { get; set; }
        public List<Season> Seasons { get; set; }
        public List<MovieCast> MovieCasts { get; set; } = new();

    }
}
