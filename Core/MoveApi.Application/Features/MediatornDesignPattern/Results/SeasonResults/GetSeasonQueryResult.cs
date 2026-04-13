using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Results.SeasonResults
{
    public class GetSeasonQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int SeasonNumber { get; set; }

        //br filmiin sezonu Ise:
        public int? MovieId { get; set; }

        //bir  Dizinin Sezonu Ise:
        public int? SeriesId { get; set; }
        public string? MovieName { get; set; }
        public string? SeriesName { get; set; }
    }
}
