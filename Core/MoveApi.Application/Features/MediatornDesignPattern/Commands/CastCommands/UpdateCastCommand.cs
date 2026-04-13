using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace MoveApi.Application.Features.MediatornDesignPattern.Commands.CastCommands
{
    public class UpdateCastCommand:IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        public string? OverView { get; set; } //hakkinda
        public string? Biography { get; set; }


    }
}
