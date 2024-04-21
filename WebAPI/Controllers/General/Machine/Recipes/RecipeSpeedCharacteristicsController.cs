using Business.Abstract.General.General;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Recipes;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.General.Machine.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeSpeedCharacteristicsController : ControllerBase
    {
        private IRecipeSpeedCharacteristicService _recipeSpeedCharacteristicService;
        public RecipeSpeedCharacteristicsController(IRecipeSpeedCharacteristicService recipeSpeedCharacteristicService)
        {
            _recipeSpeedCharacteristicService = recipeSpeedCharacteristicService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(RecipeSpeedCharacteristic recipeSpeedCharacteristic)
        {
            var result = await _recipeSpeedCharacteristicService.Add(recipeSpeedCharacteristic);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(RecipeSpeedCharacteristic recipeSpeedCharacteristic)
        {
            var result = await _recipeSpeedCharacteristicService.Update(recipeSpeedCharacteristic);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _recipeSpeedCharacteristicService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dataResult = await _recipeSpeedCharacteristicService.GetById(id);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var dataResult = await _recipeSpeedCharacteristicService.GetAll();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(FilterDto filterDto)
        {
            var dataResult = await _recipeSpeedCharacteristicService.Search(filterDto);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }
    }
}
