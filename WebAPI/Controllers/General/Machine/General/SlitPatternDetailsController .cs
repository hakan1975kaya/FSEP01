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
    public class SlitPatternDetailsController : ControllerBase
    {
        private ISlitPatternDetailService _slitPatternDetailService;
        public SlitPatternDetailsController(ISlitPatternDetailService slitPatternDetailService)
        {
            _slitPatternDetailService = slitPatternDetailService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(SlitPatternDetail slitPatternDetail)
        {
            var result = await _slitPatternDetailService.Add(slitPatternDetail);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(SlitPatternDetail slitPatternDetail)
        {
            var result = await _slitPatternDetailService.Update(slitPatternDetail);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _slitPatternDetailService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dataResult = await _slitPatternDetailService.GetById(id);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var dataResult = await _slitPatternDetailService.GetAll();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(FilterDto filterDto)
        {
            var dataResult = await _slitPatternDetailService.Search(filterDto);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }
    }
}
