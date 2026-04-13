using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.UserPurchaseCommands;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.USER.purchaseQueries;

namespace Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserpurchaseController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserpurchaseController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Createpurchase(CreatePurchaseCommand command)
        {
            await mediator.Send(command);
            return Ok("The Create purchase has been succfully");
        }

        [HttpGet("MyProgram/{Id}")]
        public async Task<IActionResult> GetMyPurchase( [FromRoute] string Id  )
        {
            var values = await mediator.Send(new GetpurchaseByIdQuery(Id));
            return Ok(values);
        }
    }
}
