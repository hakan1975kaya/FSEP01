using Business.Abstract.General.General;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Recipes;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.General.Machine.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeRewinderTwoPressuresController : ControllerBase
    {
        private IRecipeRewinderTwoPressureService _recipeRewinderTwoPressureService;
        public RecipeRewinderTwoPressuresController(IRecipeRewinderTwoPressureService recipeRewinderTwoPressureService)
        {
            _recipeRewinderTwoPressureService = recipeRewinderTwoPressureService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(RecipeRewinderTwoPressure recipeRewinderTwoPressure)
        {
            var result = await _recipeRewinderTwoPressureService.Add(recipeRewinderTwoPressure);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(RecipeRewinderTwoPressure recipeRewinderTwoPressure)
        {
            var result = await _recipeRewinderTwoPressureService.Update(recipeRewinderTwoPressure);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _recipeRewinderTwoPressureService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dataResult = await _recipeRewinderTwoPressureService.GetById(id);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var dataResult = await _recipeRewinderTwoPressureService.GetAll();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(FilterDto filterDto)
        {
            var dataResult = await _recipeRewinderTwoPressureService.Search(filterDto);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }
    }
}
