using MovieAp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Domain.Entities
{
    public class Episode
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int EpisodeNumber { get; set; }
        public int SeasonId { get; set; }
        public Season Season { get; set; }

        public List<Review> Reviews { get; set; }
    }
}
