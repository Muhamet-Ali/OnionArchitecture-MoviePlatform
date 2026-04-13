using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Results.SeriesResults
{
    public class GetSeriesByIdQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public decimal Rating { get; set; } //filim puani
        public string Description { get; set; }

        public DateTime FirstAirDate { get; set; }
        public int? AverageEpisodeDuration { get; set; }
  
        public bool Status { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int reviewsCount { get; set; }
        public int episodesCount { get; set; }
        public int seasonsCount { get; set; }

    


    }
}
