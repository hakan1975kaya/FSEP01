using Business.Abstract.General.General;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.General.Machine.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParameterRewinderTwoTensionsController : ControllerBase
    {
        private IParameterRewinderTwoTensionService _parameterRewinderTwoTensionService;
        public ParameterRewinderTwoTensionsController(IParameterRewinderTwoTensionService parameterRewinderTwoTensionService)
        {
            _parameterRewinderTwoTensionService = parameterRewinderTwoTensionService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(ParameterRewinderTwoTension parameterRewinderTwoTension)
        {
            var result = await _parameterRewinderTwoTensionService.Add(parameterRewinderTwoTension);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(ParameterRewinderTwoTension parameterRewinderTwoTension)
        {
            var result = await _parameterRewinderTwoTensionService.Update(parameterRewinderTwoTension);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _parameterRewinderTwoTensionService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dataResult = await _parameterRewinderTwoTensionService.GetById(id);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var dataResult = await _parameterRewinderTwoTensionService.GetAll();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(FilterDto filterDto)
        {
            var dataResult = await _parameterRewinderTwoTensionService.Search(filterDto);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }
    }
}
