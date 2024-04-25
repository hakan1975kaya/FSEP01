using Business.Abstract.General.General;
using Core.Entities.Concrete;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.General;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.General.Machine.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class LubracationRollsController : ControllerBase
    {
        private ILubracationRollService _lubracationRollService;
        public LubracationRollsController(ILubracationRollService lubracationRollService)
        {
            _lubracationRollService = lubracationRollService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(LubracationRoll lubracationRoll)
        {
            var result = await _lubracationRollService.Add(lubracationRoll);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(LubracationRoll lubracationRoll)
        {
            var result = await _lubracationRollService.Update(lubracationRoll);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _lubracationRollService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dataResult = await _lubracationRollService.GetById(id);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var dataResult = await _lubracationRollService.GetAll();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(FilterDto filterDto)
        {
            var dataResult = await _lubracationRollService.Search(filterDto);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }
    }
}
