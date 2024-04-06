using Business.Abstract.General;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiLogsController : ControllerBase
    {
        private IApiLogService _apiLogService;
        public ApiLogsController(IApiLogService apiLogService)
        {
            _apiLogService = apiLogService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(ApiLog ApiLog)
        {
            var result = await _apiLogService.Add(ApiLog);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(ApiLog apiLog)
        {
            var result = await _apiLogService.Update(apiLog);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _apiLogService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dataResult = await _apiLogService.GetById(id);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var dataResult = await _apiLogService.GetAll();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(FilterDto filterDto)
        {
            var dataResult = await _apiLogService.Search(filterDto);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

    }
}
