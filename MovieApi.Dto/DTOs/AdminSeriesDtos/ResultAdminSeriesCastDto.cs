using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Dto.DTOs.AdminSeriesDtos
{
    public class ResultAdminSeriesCastDto
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int CastId { get; set; }

        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public string? CharacterName { get; set; } // oynadığı karakter
    }
}
