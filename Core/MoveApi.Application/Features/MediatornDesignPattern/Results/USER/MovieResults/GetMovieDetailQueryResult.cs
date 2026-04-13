using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Results.USER.MovieResults
{
    public class GetMovieDetailQueryResult
    {
        public int Id { get; set; }
        public bool IsPurchased { get; set; }
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public decimal Rating { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public DateTime RelaseDate { get; set; }
        public string CategoryName { get; set; }

        // Cast
        public List<CastItem> Casts { get; set; }

        // Seasons
        public List<SeasonItem> Seasons { get; set; }

        // Reviews
        public List<ReviewItem> Reviews { get; set; }

        public class CastItem
        {
            public int CastId { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string ImageUrl { get; set; }
            public string CharacterName { get; set; }
        }

        public class SeasonItem
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public int SeasonNumber { get; set; }
            public string Description { get; set; }
            public int EpisodeCount { get; set; }
        }

        public class ReviewItem
        {
            public int Id { get; set; }
            public string UserName { get; set; }
            public string UserImageUrl { get; set; }
            public string Comment { get; set; }
            public int Rating { get; set; }
            public int LikeCount { get; set; }
            public bool IsSpoiler { get; set; }
            public DateTime CreatedDate { get; set; }
        }

    }
}

