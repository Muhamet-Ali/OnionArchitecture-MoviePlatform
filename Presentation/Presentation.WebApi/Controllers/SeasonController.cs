using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.SeasonCommands;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.SeasonQueries;

namespace Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonController : ControllerBase
    {
        private readonly IMediator mediator;
        public SeasonController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetSeason()
        {
            var Values = await mediator.Send(new GetSeasonQuery());
            return Ok(Values);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetSeasonById(int Id)
        {
            var Value = await mediator.Send(new GetSeasonByIdQuery(Id));
            return Ok(Value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeason(CreateSeasonCommand command)
        {
            await mediator.Send(command);
            return Ok("The Create new Season has been sucfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSeason(UpdateSeasonCommand command)
        {
            await mediator.Send(command);
            return Ok("The Update new Season has been sucfully");
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveEpisod(int Id)
        {
            await mediator.Send(new RemoveSeasonCommand(Id));
            return Ok("The Delete new Episode has been sucfully");
        }
    }
}
