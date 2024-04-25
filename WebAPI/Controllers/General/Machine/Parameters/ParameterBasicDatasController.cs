using Business.Abstract.General.General;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.General.Machine.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParameterBasicDatasController : ControllerBase
    {
        private IParameterBasicDataService _parameterBasicDataService;
        public ParameterBasicDatasController(IParameterBasicDataService parameterBasicDataService)
        {
            _parameterBasicDataService = parameterBasicDataService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(ParameterBasicData parameterBasicData)
        {
            var result = await _parameterBasicDataService.Add(parameterBasicData);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(ParameterBasicData parameterBasicData)
        {
            var result = await _parameterBasicDataService.Update(parameterBasicData);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _parameterBasicDataService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dataResult = await _parameterBasicDataService.GetById(id);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var dataResult = await _parameterBasicDataService.GetAll();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(FilterDto filterDto)
        {
            var dataResult = await _parameterBasicDataService.Search(filterDto);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }
    }
}
