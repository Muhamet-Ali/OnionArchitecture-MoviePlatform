using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Dto.DTOs.CategoryAdminDtos
{
    public class ResultAdminCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MovieCount { get; set; }   // Film sayısı
        public int SeriesCount { get; set; }   // dizi sayısı
        public int ReviewCount { get; set; }  // Yorum sayısı
        public double AvgRating { get; set; } // Ortalama puan
    }
}
