using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Dto.DTOs.AdminCastDtos
{
    public class ResultAdminCastDto
    {
       
            public int Id { get; set; }
            public string Title { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string FullName => $"{Title} {Name} {Surname}".Trim();
            public string ImageUrl { get; set; }
            public string? OverView { get; set; }
            public string? Biography { get; set; }

            public int FilmographyCount { get; set; }

            public List<String> Movies { get; set; } = new();
            public List<String> Serieses { get; set; } = new();
        
    }
}
