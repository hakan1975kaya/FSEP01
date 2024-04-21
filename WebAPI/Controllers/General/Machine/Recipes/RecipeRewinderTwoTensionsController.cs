using Business.Abstract.General.General;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Recipes;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.General.Machine.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeRewinderTwoTensionsController : ControllerBase
    {
        private IRecipeRewinderTwoTensionService _recipeRewinderTwoTensionService;
        public RecipeRewinderTwoTensionsController(IRecipeRewinderTwoTensionService recipeRewinderTwoTensionService)
        {
            _recipeRewinderTwoTensionService = recipeRewinderTwoTensionService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(RecipeRewinderTwoTension recipeRewinderTwoTension)
        {
            var result = await _recipeRewinderTwoTensionService.Add(recipeRewinderTwoTension);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(RecipeRewinderTwoTension recipeRewinderTwoTension)
        {
            var result = await _recipeRewinderTwoTensionService.Update(recipeRewinderTwoTension);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _recipeRewinderTwoTensionService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dataResult = await _recipeRewinderTwoTensionService.GetById(id);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var dataResult = await _recipeRewinderTwoTensionService.GetAll();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(FilterDto filterDto)
        {
            var dataResult = await _recipeRewinderTwoTensionService.Search(filterDto);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }
    }
}
