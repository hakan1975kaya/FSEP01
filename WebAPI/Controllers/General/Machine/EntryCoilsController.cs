using Business.Abstract.General.Machine;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.General.Machine
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryCoilsController : ControllerBase
    {
        private IEntryCoilService _entryCoilService;
        public EntryCoilsController(IEntryCoilService entryCoilService)
        {
            _entryCoilService = entryCoilService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(EntryCoil entryCoil)
        {
            var result = await _entryCoilService.Add(entryCoil);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(EntryCoil entryCoil)
        {
            var result = await _entryCoilService.Update(entryCoil);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _entryCoilService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dataResult = await _entryCoilService.GetById(id);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var dataResult = await _entryCoilService.GetAll();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(FilterDto filterDto)
        {
            var dataResult = await _entryCoilService.Search(filterDto);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }
    }
}
