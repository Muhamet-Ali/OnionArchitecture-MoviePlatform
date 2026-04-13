using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.SeriesCommands;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.SeriesQueries;

namespace Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesesController : ControllerBase
    {
        private readonly IMediator mediator;

        public SeriesesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetSeries()
        {
            var Values = await mediator.Send(new GetSeriesQuery());
            return Ok(Values);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetSeriesById(int Id)
        {
            var Value = await mediator.Send(new GetSeriesByIdQuery(Id));
            return Ok(Value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeries(CreateSeriesCommand command)
        {
            await mediator.Send(command);
            return Ok("The Create Action has been suscfully");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSeries(UpdateSeriesCommand command)
        {
            await mediator.Send(command);
            return Ok("The Update Action has been suscfully");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveSeries(int Id)
        {
            await mediator.Send(new RemoveSeriesCommand(Id));
            return Ok("The Delete Action has been suscfully");
        }

    }
}
