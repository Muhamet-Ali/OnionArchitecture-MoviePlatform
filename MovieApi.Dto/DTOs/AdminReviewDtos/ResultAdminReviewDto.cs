using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Dto.DTOs.AdminReviewDtos
{
    public class ResultAdminReviewDto
    {
        public int Id { get; set; }
        public string ReviewComment { get; set; }//yorum icerik
        public byte UserRating { get; set; }// kullnaci kac yildiz verdi
        public DateTime ReviewDate { get; set; } // yazma tarihi
        public bool Status { get; set; } //DURUMMU aktifmi pasifmi silmek yerinne pasif yapariz
        public string UserId { get; set; } //hangi userin
        public int? MovieId { get; set; } //hangi filmin  
        public string programName { get; set; }//movie-episode-series
        public int? SeriesId { get; set; }
        public int? EpisodeId { get; set; }
        //data analiz
        public bool IsSpoiler { get; set; } //spoiler iceryormu
        public int LikeCount { get; set; } //begen sayisi
        public decimal? SentimentScore { get; set; } //duygu durumu
    }
}
