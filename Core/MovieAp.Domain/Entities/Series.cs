using MovieAp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Domain.Entities
{
    public class Series
    {
        public int Id { get; set; }       
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public string Description { get; set; }
        public DateTime FirstAirDate { get; set; }
        public bool Status { get; set; }                  // Durum (aktif/pasif veya yayınlanıyor mu)
        public int? AverageEpisodeDuration { get; set; } // Ortalama bölüm süresi (dakika, boş olabilir)
        public int CategoryId { get; set; }
        public decimal Rating { get; set; } //filim puani -
        public int Price { get; set; }

        public Category Category { get; set; }

        public List<Review> Reviews { get; set; }
        public List<Season> Seasons { get; set; }
        public List<SeriesCast> SeriesCasts { get; set; } = new();
    }
}
