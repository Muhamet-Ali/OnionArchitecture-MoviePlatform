using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.USER.MovieQueries;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.USER.SeriesQueries;

namespace Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSeriesController : ControllerBase
    {
        private readonly IMediator mediator;
        public UserSeriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetSeriesDetail/{Id}/{userId}")]
        public async Task<IActionResult> GetSeriesDetail(int Id,string userId)
        {
            var Value = await mediator.Send(new GetSeriesDetailQuery(Id, userId));
            return Ok(Value);
        }
    }
}
