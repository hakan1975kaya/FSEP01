using Business.Abstract.General.General;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Recipes;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.General.Machine.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeRewinderOnePressuresController : ControllerBase
    {
        private IRecipeRewinderOnePressureService _recipeRewinderOnePressureService;
        public RecipeRewinderOnePressuresController(IRecipeRewinderOnePressureService recipeRewinderOnePressureService)
        {
            _recipeRewinderOnePressureService = recipeRewinderOnePressureService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(RecipeRewinderOnePressure recipeRewinderOnePressure)
        {
            var result = await _recipeRewinderOnePressureService.Add(recipeRewinderOnePressure);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(RecipeRewinderOnePressure recipeRewinderOnePressure)
        {
            var result = await _recipeRewinderOnePressureService.Update(recipeRewinderOnePressure);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _recipeRewinderOnePressureService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dataResult = await _recipeRewinderOnePressureService.GetById(id);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var dataResult = await _recipeRewinderOnePressureService.GetAll();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(FilterDto filterDto)
        {
            var dataResult = await _recipeRewinderOnePressureService.Search(filterDto);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }
    }
}
