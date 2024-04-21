﻿using Business.Abstract.General.General;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.General.Machine.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParameterRewinderOneTensionsController : ControllerBase
    {
        private IParameterRewinderOneTensionService _parameterRewinderOneTensionService;
        public ParameterRewinderOneTensionsController(IParameterRewinderOneTensionService parameterRewinderOneTensionService)
        {
            _parameterRewinderOneTensionService = parameterRewinderOneTensionService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(ParameterRewinderOneTension parameterRewinderOneTension)
        {
            var result = await _parameterRewinderOneTensionService.Add(parameterRewinderOneTension);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(ParameterRewinderOneTension parameterRewinderOneTension)
        {
            var result = await _parameterRewinderOneTensionService.Update(parameterRewinderOneTension);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _parameterRewinderOneTensionService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dataResult = await _parameterRewinderOneTensionService.GetById(id);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var dataResult = await _parameterRewinderOneTensionService.GetAll();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(FilterDto filterDto)
        {
            var dataResult = await _parameterRewinderOneTensionService.Search(filterDto);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }
    }
}
