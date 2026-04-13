using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoveApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MoveApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using MoveApi.Application.Features.CQRSDesignPattern.Queries.CategoryQueries;

namespace Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;
        public CategoriesController(GetCategoryQueryHandler getCategoryQueryHandler, 
            GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, 
            CreateCategoryCommandHandler createCategoryCommandHandler, 
            UpdateCategoryCommandHandler updateCategoryCommandHandler, 
            RemoveCategoryCommandHandler removeCategoryCommandHandler)

        {
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
            _removeCategoryCommandHandler = removeCategoryCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var Values =await _getCategoryQueryHandler.Handle();
            return Ok(Values);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommands _command)
        {
            await _createCategoryCommandHandler.Handler(_command);
            return Ok("The Created Action has been Sucsfully");
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommands(Id));
            return Ok("The Remove Action has been Sucsfully");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryCommands _command)
        {
            await _updateCategoryCommandHandler.Handle(_command);
            return Ok("The Update Action Has Been Suscfully");
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCategoryById(int Id)
        {
            var Value = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(Id));
            return Ok(Value);
        }



    }
}
