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
    public class HeadTailScrapsController : ControllerBase
    {
        private IHeadTailScrapService _headTailScrapService;
        public HeadTailScrapsController(IHeadTailScrapService headTailScrapService)
        {
            _headTailScrapService = headTailScrapService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(HeadTailScrap headTailScrap)
        {
            var result = await _headTailScrapService.Add(headTailScrap);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(HeadTailScrap headTailScrap)
        {
            var result = await _headTailScrapService.Update(headTailScrap);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _headTailScrapService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dataResult = await _headTailScrapService.GetById(id);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var dataResult = await _headTailScrapService.GetAll();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(FilterDto filterDto)
        {
            var dataResult = await _headTailScrapService.Search(filterDto);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }
    }
}
