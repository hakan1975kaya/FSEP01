using Business.Abstract.General.General;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Recipes;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.General.Machine.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeApplyingUnitsController : ControllerBase
    {
        private IRecipeApplyingUnitService _recipeApplyingUnitService;
        public RecipeApplyingUnitsController(IRecipeApplyingUnitService recipeApplyingUnitService)
        {
            _recipeApplyingUnitService = recipeApplyingUnitService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(RecipeApplyingUnit recipeApplyingUnit)
        {
            var result = await _recipeApplyingUnitService.Add(recipeApplyingUnit);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(RecipeApplyingUnit recipeApplyingUnit)
        {
            var result = await _recipeApplyingUnitService.Update(recipeApplyingUnit);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _recipeApplyingUnitService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dataResult = await _recipeApplyingUnitService.GetById(id);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var dataResult = await _recipeApplyingUnitService.GetAll();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(FilterDto filterDto)
        {
            var dataResult = await _recipeApplyingUnitService.Search(filterDto);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }
    }
}
