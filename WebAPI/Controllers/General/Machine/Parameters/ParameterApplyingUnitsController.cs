using Business.Abstract.General.General;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.General.Machine.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParameterApplyingUnitsController : ControllerBase
    {
        private IParameterApplyingUnitService _parameterApplyingUnitService;
        public ParameterApplyingUnitsController(IParameterApplyingUnitService parameterApplyingUnitService)
        {
            _parameterApplyingUnitService = parameterApplyingUnitService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(ParameterApplyingUnit parameterApplyingUnit)
        {
            var result = await _parameterApplyingUnitService.Add(parameterApplyingUnit);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(ParameterApplyingUnit parameterApplyingUnit)
        {
            var result = await _parameterApplyingUnitService.Update(parameterApplyingUnit);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _parameterApplyingUnitService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dataResult = await _parameterApplyingUnitService.GetById(id);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var dataResult = await _parameterApplyingUnitService.GetAll();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(FilterDto filterDto)
        {
            var dataResult = await _parameterApplyingUnitService.Search(filterDto);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }
    }
}
