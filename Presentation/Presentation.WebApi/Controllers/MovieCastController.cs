using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.CastCommands;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.MovieCastCommands;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.CastQueries;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.MovieCastQueries;

namespace Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieCastController : ControllerBase
    {

        private readonly IMediator mediator;

        public MovieCastController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetMovieCast/{Id}")]
        public async Task<IActionResult> GetListMovieCast(int  Id)
        {
            var Values = await mediator.Send(new GetMovieCastQuery(Id));
            return Ok(Values);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetMovieCast(int Id)
        {
            var Value = await mediator.Send(new GetMovieCastByIdQuery(Id));
            return Ok(Value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMovieCast(CreateMovieCastCommand command)
        {
            await mediator.Send(command);
            return Ok("the created action succfully");
        }
        [HttpPut]
        public async Task<IActionResult> UpdatMovieCast(UpdateMovieCastCommand command)
        {
            await mediator.Send(command);
            return Ok("thecreated action succfully");
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteMovieCast(int id)
        {
            await mediator.Send(new RemoveMovieCastCommand(id));
            return Ok("delete action has been succfully");
        }


    }
}
