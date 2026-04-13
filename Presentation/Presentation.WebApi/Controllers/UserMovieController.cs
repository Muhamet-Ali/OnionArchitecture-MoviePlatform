using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.USER.MovieQueries;
using Newtonsoft.Json.Linq;
using System;
using System.Runtime.Intrinsics.X86;

namespace Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMovieController : ControllerBase
    {
        private readonly IMediator mediator;
        public UserMovieController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetMovieDetail/{Id}/{userId}")]
        public async Task<IActionResult> GetMovieDetail(int Id , string userId)  
        {
            var Value = await mediator.Send(new GetMovieDetailQuery(Id, userId));
            return Ok(Value);
        }

    }
}
