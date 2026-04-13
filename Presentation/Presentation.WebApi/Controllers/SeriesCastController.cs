using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.SeriesCastCommands;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.SeriesCastQueries;

namespace Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesCastController : ControllerBase
    {
        private readonly IMediator mediator;
        public SeriesCastController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetSeriesCast/{Id}")]
        public async Task<IActionResult> GetSeriesCast(int Id)
        {
            var Values = await mediator.Send(new GetSeriesCastQuery(Id));
            return Ok(Values);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetSeriesCastById(int Id)
        {
            var Value = await mediator.Send(new GetSeriesCastByIdQuery(Id));
            return Ok(Value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeriesCast(CreateSeriesCastCommand command)
        {
            await mediator.Send(command);
            return Ok("The Create new SeriesCast has been sucfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSeriesCast(UpdateSeriesCastCommand command)
        {
            await mediator.Send(command);
            return Ok("The Update new SeriesCast has been sucfully");
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveEpisod(int Id)
        {
            await mediator.Send(new RemoveSeriesCastCommand(Id));
            return Ok("The Delete new Episode has been sucfully");
        }
    }
}
