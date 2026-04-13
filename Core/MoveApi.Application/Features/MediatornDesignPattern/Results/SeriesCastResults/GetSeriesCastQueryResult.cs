using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApi.Application.Features.MediatornDesignPattern.Results.SeriesCastResults
{
    public class GetSeriesCastQueryResult
    {

        public int Id { get; set; }
        
        public int SeriesId { get; set; }
        public string SeriesName { get; set; }

        public int CastId { get; set; }
        public string CastName { get; set; }
        public string CastImageUrl { get; set; }
        public string? CharacterName { get; set; } // oynadığı karakter
    }
}