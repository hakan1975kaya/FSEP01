using Business.Abstract.General.General;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.InputCoils;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.General.Machine.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class InputCoilRemarksController : ControllerBase
    {
        private IInputCoilRemarkService _inputCoilRemarkService;
        public InputCoilRemarksController(IInputCoilRemarkService inputCoilRemarkService)
        {
            _inputCoilRemarkService = inputCoilRemarkService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(InputCoilRemark inputCoilRemark)
        {
            var result = await _inputCoilRemarkService.Add(inputCoilRemark);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(InputCoilRemark inputCoilRemark)
        {
            var result = await _inputCoilRemarkService.Update(inputCoilRemark);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _inputCoilRemarkService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dataResult = await _inputCoilRemarkService.GetById(id);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var dataResult = await _inputCoilRemarkService.GetAll();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(FilterDto filterDto)
        {
            var dataResult = await _inputCoilRemarkService.Search(filterDto);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }
    }
}
