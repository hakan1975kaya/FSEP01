using Business.Abstract.General.General;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.General.Machine.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParameterRewinderTwoPressuresController : ControllerBase
    {
        private IParameterRewinderTwoPressureService _parameterRewinderTwoPressureService;
        public ParameterRewinderTwoPressuresController(IParameterRewinderTwoPressureService parameterRewinderTwoPressureService)
        {
            _parameterRewinderTwoPressureService = parameterRewinderTwoPressureService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(ParameterRewinderTwoPressure parameterRewinderTwoPressure)
        {
            var result = await _parameterRewinderTwoPressureService.Add(parameterRewinderTwoPressure);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(ParameterRewinderTwoPressure parameterRewinderTwoPressure)
        {
            var result = await _parameterRewinderTwoPressureService.Update(parameterRewinderTwoPressure);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _parameterRewinderTwoPressureService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dataResult = await _parameterRewinderTwoPressureService.GetById(id);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var dataResult = await _parameterRewinderTwoPressureService.GetAll();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(FilterDto filterDto)
        {
            var dataResult = await _parameterRewinderTwoPressureService.Search(filterDto);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }
    }
}
