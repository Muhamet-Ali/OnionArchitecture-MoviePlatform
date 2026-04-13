using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.EpisodeCommands;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.ReviewCommands;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.EpisodeQueries;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.ReviewQueries;
using MoveApi.Application.Features.MediatornDesignPattern.Queries.ReviewQueries.GetReviewProgramById;

namespace Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IMediator mediator;
        public ReviewController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetReview()
        {
            var Values = await mediator.Send(new GetReviewQuery());
            return Ok(Values);
        }

        [HttpGet("GetReviewMovie")]
        public async Task<IActionResult> GetReviewMovie()
        {
            var Values = await mediator.Send(new GetReviewMovieQuery());
            return Ok(Values);
        }
        [HttpGet("GetReviewSeries")]
        public async Task<IActionResult> GetReviewSeries()
        {
            var Values = await mediator.Send(new GetReviewSeriesQuery());
            return Ok(Values);
        }
        [HttpGet("GetReviewEpisode")]
        public async Task<IActionResult> GetReviewEpisode()
        {
            var Values = await mediator.Send(new GetReviewEpisodeQuery());
            return Ok(Values);
        }


        [HttpGet("GetReviewMovieById/{Id}")]
        public async Task<IActionResult> GetReviewMovieById(int Id)
        {
            var Values = await mediator.Send(new GetReviewMovieQueryById(Id));
            return Ok(Values);
        }
        [HttpGet("GetReviewSeriesByIdById/{Id}")]
        public async Task<IActionResult> GetReviewSeriesById(int Id)
        {
            var Values = await mediator.Send(new GetReviewSeriesQueryById(Id));
            return Ok(Values);
        }
        [HttpGet("GetReviewEpisodeById/{Id}")]
        public async Task<IActionResult> GetReviewEpisodeById(int Id)
        {
            var Values = await mediator.Send(new GetReviewEpisodeQueryById(Id));
            return Ok(Values);
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetReviewById(int Id)
        {
            var Value = await mediator.Send(new GetReviewByIdQuery(Id));
            return Ok(Value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateReviewCommand command)
        {
            await mediator.Send(command);
            return Ok("The Create new Review has been sucfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReview(UpdateReviewCommand command)
        {
            await mediator.Send(command);
            return Ok("The Update new Review has been sucfully");
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveEpisod(int Id)
        {
            await mediator.Send(new RemoveReviewCommand(Id));
            return Ok("The Delete new Episode has been sucfully");
        }



    }
}
