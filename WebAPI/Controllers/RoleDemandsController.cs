using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete.Dtos.Genaral;
using Entities.Concrete.Entities.WEB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleDemandsController : ControllerBase
    {
        private IRoleDemandService _roleDemandService;
        public RoleDemandsController(IRoleDemandService roleDemandService)
        {
            _roleDemandService = roleDemandService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(RoleDemand roleDemand)
        {
            var result = await _roleDemandService.Add(roleDemand);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(RoleDemand roleDemand)
        {
            var result = await _roleDemandService.Update(roleDemand);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _roleDemandService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dataResult= await _roleDemandService.GetById(id);
            if(dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var dataResult = await _roleDemandService.GetAll();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(FilterDto filterDto)
        {
            var dataResult = await _roleDemandService.Search(filterDto);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }


    }
}
