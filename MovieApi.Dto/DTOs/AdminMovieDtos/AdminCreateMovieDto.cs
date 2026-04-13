using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Dto.DTOs.MovieAdminDtos
{
    public class AdminCreateMovieDto
    {
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; } //film suresu
        public DateTime RelaseDate { get; set; }
        public string CreatedYear { get; set; }
        public int CategoryId { get; set; }
        public bool Status { get; set; }
    }
}
