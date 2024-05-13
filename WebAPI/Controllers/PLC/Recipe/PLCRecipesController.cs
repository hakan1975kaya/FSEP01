using Business.Abstract.PLC.Machine;
using Entities.Concrete.Entities.PLC.Recipe;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.PLC.Recipe
{
    [Route("api/[controller]")]
    [ApiController]
    public class PLCRecipesController : ControllerBase
    {
        private IPLCRecipeService _plcRecipeService;
        public PLCRecipesController(IPLCRecipeService plcRecipeService)
        {
            _plcRecipeService = plcRecipeService;
        }

        [HttpGet("readRecipe")]
        public async Task<IActionResult> ReadRecipe()
        {
            var dataResult = await _plcRecipeService.ReadRecipe();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRecipe")]
        public async Task<IActionResult> WriteRecipe(PLCRecipe plcCRecipe)
        {
            var result = await _plcRecipeService.WriteRecipe(plcCRecipe);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
