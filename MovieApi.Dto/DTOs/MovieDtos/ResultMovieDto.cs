using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Dto.DTOs.MovieDtos
{
    public class ResultMovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public decimal Rating { get; set; } //filim puani
        public string Description { get; set; }
        public int Duration { get; set; } //film suresu
        public DateTime RelaseDate { get; set; }
        public string CreatedYear { get; set; }

        public bool Status { get; set; }
    }
}
