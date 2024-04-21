using Business.Abstract.General.General;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Recipes;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.General.Machine.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeRewinderOneTensionsController : ControllerBase
    {
        private IRecipeRewinderOneTensionService _recipeRewinderOneTensionService;
        public RecipeRewinderOneTensionsController(IRecipeRewinderOneTensionService recipeRewinderOneTensionService)
        {
            _recipeRewinderOneTensionService = recipeRewinderOneTensionService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(RecipeRewinderOneTension recipeRewinderOneTension)
        {
            var result = await _recipeRewinderOneTensionService.Add(recipeRewinderOneTension);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(RecipeRewinderOneTension recipeRewinderOneTension)
        {
            var result = await _recipeRewinderOneTensionService.Update(recipeRewinderOneTension);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _recipeRewinderOneTensionService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dataResult = await _recipeRewinderOneTensionService.GetById(id);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var dataResult = await _recipeRewinderOneTensionService.GetAll();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(FilterDto filterDto)
        {
            var dataResult = await _recipeRewinderOneTensionService.Search(filterDto);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }
    }
}
