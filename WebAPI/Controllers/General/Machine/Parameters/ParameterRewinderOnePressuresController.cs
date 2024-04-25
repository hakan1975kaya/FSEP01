using Business.Abstract.General.General;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.General.Machine.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParameterRewinderOnePressuresController : ControllerBase
    {
        private IParameterRewinderOnePressureService _parameterRewinderOnePressureService;
        public ParameterRewinderOnePressuresController(IParameterRewinderOnePressureService parameterRewinderOnePressureService)
        {
            _parameterRewinderOnePressureService = parameterRewinderOnePressureService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(ParameterRewinderOnePressure parameterRewinderOnePressure)
        {
            var result = await _parameterRewinderOnePressureService.Add(parameterRewinderOnePressure);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(ParameterRewinderOnePressure parameterRewinderOnePressure)
        {
            var result = await _parameterRewinderOnePressureService.Update(parameterRewinderOnePressure);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _parameterRewinderOnePressureService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dataResult = await _parameterRewinderOnePressureService.GetById(id);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var dataResult = await _parameterRewinderOnePressureService.GetAll();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(FilterDto filterDto)
        {
            var dataResult = await _parameterRewinderOnePressureService.Search(filterDto);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }
    }
}
