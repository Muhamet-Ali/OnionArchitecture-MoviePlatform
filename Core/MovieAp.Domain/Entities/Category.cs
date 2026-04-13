using MovieApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAp.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool Status { get; set; }
        public List<Movie> Movies { get; set; } = new();
        public List<Series> Serieses { get; set; } = new();
    }
}
