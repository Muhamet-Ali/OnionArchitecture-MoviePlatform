using MovieAp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Domain.Entities
{
    public class Season
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int SeasonNumber { get; set; }
        
        //br filmiin sezonu Ise:
        public int? MovieId { get; set; }

        //bir  Dizinin Sezonu Ise:
        public int? SeriesId { get; set; }
        public Movie Movie { get; set; }
        public Series Series { get; set; }
        public List<Episode> Episodes { get; set; }
    }
}
