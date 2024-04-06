using Business.Abstract.General;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebLogsController : ControllerBase
    {
        private IWebLogService _webLogService;
        public WebLogsController(IWebLogService webLogService)
        {
            _webLogService = webLogService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(WebLog webLog)
        {
            var result = await _webLogService.Add(webLog);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(WebLog webLog)
        {
            var result = await _webLogService.Update(webLog);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _webLogService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dataResult = await _webLogService.GetById(id);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var dataResult = await _webLogService.GetAll();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(FilterDto filterDto)
        {
            var dataResult = await _webLogService.Search(filterDto);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

    }
}
