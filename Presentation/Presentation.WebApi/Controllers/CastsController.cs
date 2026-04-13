using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.CastCommands;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.MovieCastCommands;
using MoveApi.Application.Features.MediatornDesignPattern.Queries;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.CastQueries;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.MovieCastQueries;

namespace Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastsController : ControllerBase
    {
        private readonly IMediator mediator;

        public CastsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetListCast()
        {
            var Values = await mediator.Send(new GetCastQuery());
            return Ok(Values);
        }
        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetCast(int Id)
        {
            var Value=await mediator.Send(new GetCastByIdQuery(Id));
            return Ok(Value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCast(CreateCastCommand command)
        {
            await mediator.Send(command);
            return Ok("the created action succfully");
        }
        [HttpPut]
        public async Task<IActionResult> UpdatCast(UpdateCastCommand command)
        {
            await mediator.Send(command);
            return Ok("thecreated action succfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCast(int Id)
        {
            await mediator.Send(new RemoveCastCommand(Id));
            return Ok("delete action has been succfully");
        }

       
    }
}
