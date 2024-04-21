using Business.Abstract.General.General;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.General.Machine.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParameterSpeedCharacteristicsController : ControllerBase
    {
        private IParameterSpeedCharacteristicService _parameterSpeedCharacteristicService;
        public ParameterSpeedCharacteristicsController(IParameterSpeedCharacteristicService parameterSpeedCharacteristicService)
        {
            _parameterSpeedCharacteristicService = parameterSpeedCharacteristicService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(ParameterSpeedCharacteristic parameterSpeedCharacteristic)
        {
            var result = await _parameterSpeedCharacteristicService.Add(parameterSpeedCharacteristic);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(ParameterSpeedCharacteristic parameterSpeedCharacteristic)
        {
            var result = await _parameterSpeedCharacteristicService.Update(parameterSpeedCharacteristic);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _parameterSpeedCharacteristicService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dataResult = await _parameterSpeedCharacteristicService.GetById(id);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var dataResult = await _parameterSpeedCharacteristicService.GetAll();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(FilterDto filterDto)
        {
            var dataResult = await _parameterSpeedCharacteristicService.Search(filterDto);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }
    }
}
