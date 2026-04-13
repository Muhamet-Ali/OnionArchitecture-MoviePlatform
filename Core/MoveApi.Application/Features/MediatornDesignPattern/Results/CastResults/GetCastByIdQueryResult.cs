using MovieAp.Domain.Entities;
using MovieApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace MoveApi.Application.Features.MediatornDesignPattern.Results.CastResults
{
    public class GetCastByIdQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        public string? OverView { get; set; } //hakkinda
        public string? Biography { get; set; }

        public int FilmographyCount { get; set; }
        public List<String> Movies { get; set; }
        public List<String> Serieses { get; set; }

    }
}
