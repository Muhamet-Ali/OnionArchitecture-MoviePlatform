using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Results.USER.HomePageResult
{
    public class HomePageQuerytResult
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

        public string Type { get; set; }
      
    }
}
