using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Results.EpisodeResult
{
    public class GetEpisodeByIdQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int EpisodeNumber { get; set; }
        public int SeasonId { get; set; }
        public string SeasonName { get; set; }

        public string ParentType { get; set; } //movie or series
        public string ParentName { get; set; }

    }
}
