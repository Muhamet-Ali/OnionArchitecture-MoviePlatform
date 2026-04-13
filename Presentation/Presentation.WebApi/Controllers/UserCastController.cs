using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.USER.CastQueries;

namespace Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCastController : ControllerBase
    {
        private readonly IMediator mediator;
        public UserCastController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetCast()
        {
            var values = await mediator.Send(new UserGetCastQuery());
            return Ok(values);

        }
        [HttpGet("GetCastById/{Id}")]
        public async Task<IActionResult> GetCastById(int Id)
        {
            var value=await mediator.Send(new UserGetCastByIdQuery(Id));

            return Ok(value);
        }

    }
}
