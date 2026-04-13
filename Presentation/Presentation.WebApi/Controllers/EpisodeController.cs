using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.EpisodeCommands;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.EpisodeQueries;

namespace Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodeController : ControllerBase
    {
        private readonly IMediator mediator;
        public EpisodeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetEpisode()
        {
            var Values = await mediator.Send(new GetEpisodeQuery());
            return Ok(Values);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetEpisodeById(int Id)
        {
            var Value = await mediator.Send(new GetEpisodeByIdQuery(Id));
            return Ok(Value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEpisode(CreateEpisodeCommand command)
        {
            await mediator.Send(command);
            return Ok("The Create new Episode has been sucfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEpisode(UpdateEpisodeCommand command)
        {
            await mediator.Send(command);
            return Ok("The Update new Episode has been sucfully");
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveEpisod(int Id)
        {
            await mediator.Send(new RemoveEpisodeCommand(Id));
            return Ok ("The Delete new Episode has been sucfully");
        }
        [HttpGet("GetSezonEpisode/{Id}")]
        public async Task<IActionResult> GetSezonEpisode(int Id)
        {
            var values=await mediator.Send(new GetEpisodesBySeasonQuery(Id));
            return Ok(values);
        }




    }
}
