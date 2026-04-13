using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoveApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MoveApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using MoveApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MoveApi.Application.Features.CQRSDesignPattern.Queries.CategoryQueries;
using MoveApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries;

namespace Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly GetMovieByIdQueryHandler _getMovieByIdQueryHandler;
        private readonly GetMovieQueryHandler _getMovieQueryHandler;
        private readonly CreateMovieCommandHandler _createMovieCommandHandler;
        private readonly UpdateMovieCommandHandler _updateMovieCommandHandler;
        private readonly RemoveMovieCommandHandler _removeMovieCommandHandler;

        public MoviesController(GetMovieByIdQueryHandler getMovieByIdQueryHandler, GetMovieQueryHandler getMovieQueryHandler, CreateMovieCommandHandler createMovieCommandHandler, UpdateMovieCommandHandler updateMovieCommandHandler, RemoveMovieCommandHandler removeMovieCommandHandler)
        {
            _getMovieByIdQueryHandler = getMovieByIdQueryHandler;
            _getMovieQueryHandler = getMovieQueryHandler;
            _createMovieCommandHandler = createMovieCommandHandler;
            _updateMovieCommandHandler = updateMovieCommandHandler;
            _removeMovieCommandHandler = removeMovieCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var Values = await _getMovieQueryHandler.Handle();
            return Ok(Values);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdMovie(int Id)
        {
            var Value = await _getMovieByIdQueryHandler.Handle(new GetMovieByIdQuery(Id));
            return Ok(Value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMovieCommands command)
        {
            await _createMovieCommandHandler.Handler(command);
            return Ok("The Created Action Has been Sucsfully");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateMovieCommands command)
        {
            await _updateMovieCommandHandler.Handle(command);
            return Ok("The Update Action Has been Sucsfully");
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            await _removeMovieCommandHandler.Handle(new RemoveMovieCommands(Id));
            return Ok("The Delete Action Has been Sucsfully");

        }
    }
}
