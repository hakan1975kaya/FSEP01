using Business.Abstract.General.General;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.General.Machine.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParameterSuctionsController : ControllerBase
    {
        private IParameterSuctionService _parameterSuctionService;
        public ParameterSuctionsController(IParameterSuctionService parameterSuctionService)
        {
            _parameterSuctionService = parameterSuctionService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(ParameterSuction parameterSuction)
        {
            var result = await _parameterSuctionService.Add(parameterSuction);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(ParameterSuction parameterSuction)
        {
            var result = await _parameterSuctionService.Update(parameterSuction);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _parameterSuctionService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dataResult = await _parameterSuctionService.GetById(id);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var dataResult = await _parameterSuctionService.GetAll();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(FilterDto filterDto)
        {
            var dataResult = await _parameterSuctionService.Search(filterDto);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }
    }
}
