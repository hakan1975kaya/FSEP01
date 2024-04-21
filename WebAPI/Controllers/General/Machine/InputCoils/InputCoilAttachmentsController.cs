using Business.Abstract.General.General;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.InputCoils;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.General.Machine.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class InputCoilAttachmentsController : ControllerBase
    {
        private IInputCoilAttachmentService _inputCoilAttachmentService;
        public InputCoilAttachmentsController(IInputCoilAttachmentService inputCoilAttachmentService)
        {
            _inputCoilAttachmentService = inputCoilAttachmentService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(InputCoilAttachment inputCoilAttachment)
        {
            var result = await _inputCoilAttachmentService.Add(inputCoilAttachment);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(InputCoilAttachment inputCoilAttachment)
        {
            var result = await _inputCoilAttachmentService.Update(inputCoilAttachment);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _inputCoilAttachmentService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dataResult = await _inputCoilAttachmentService.GetById(id);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var dataResult = await _inputCoilAttachmentService.GetAll();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(FilterDto filterDto)
        {
            var dataResult = await _inputCoilAttachmentService.Search(filterDto);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }
    }
}
