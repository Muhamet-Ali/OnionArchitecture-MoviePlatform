using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.USER.HomePageQueries;

namespace Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserHomePageController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserHomePageController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await mediator.Send(new HomePageQuery());
            return Ok(values);
        }


    }
}
