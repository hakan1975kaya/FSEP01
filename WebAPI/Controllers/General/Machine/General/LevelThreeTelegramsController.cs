﻿using Business.Abstract.General.General;
using Core.Entities.Concrete;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.General;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.General.Machine.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelThreeTelegramsController : ControllerBase
    {
        private ILevelThreeTelegramService _levelThreeTelegramService;
        public LevelThreeTelegramsController(ILevelThreeTelegramService levelThreeTelegramService)
        {
            _levelThreeTelegramService = levelThreeTelegramService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(LevelThreeTelegram levelThreeTelegram)
        {
            var result = await _levelThreeTelegramService.Add(levelThreeTelegram);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(LevelThreeTelegram levelThreeTelegram)
        {
            var result = await _levelThreeTelegramService.Update(levelThreeTelegram);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _levelThreeTelegramService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dataResult = await _levelThreeTelegramService.GetById(id);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var dataResult = await _levelThreeTelegramService.GetAll();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(FilterDto filterDto)
        {
            var dataResult = await _levelThreeTelegramService.Search(filterDto);
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }

            return BadRequest(dataResult);
        }
    }
}
