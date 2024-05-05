using Business.Abstract.General.General;
using Business.Abstract.PLC.General;
using Business.Abstract.PSI.Transfers;
using Core.Utilities.Results.Abstract;
using Entities.Concrete.Enums.PLC.Machine;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSI.Dtos.Telegrams;

namespace WebAPI.Controllers.PLC.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class PLCGeneralsController : ControllerBase
    {
        private IPLCGeneralService _plcGeneralService;
        public PLCGeneralsController(IPLCGeneralService plcGeneralService)
        {
            _plcGeneralService = plcGeneralService;
        }

        [HttpGet("readRecipeNameLast")]
        public async Task<IActionResult> ReadRecipeNameLast()
        {
            var dataResult = await _plcGeneralService.ReadRecipeNameLast();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRecipeNameLast")]
        public async Task<IActionResult> WriteRecipeNameLast(string recipeNameLast)
        {
            var result = await _plcGeneralService.WriteRecipeNameLast(recipeNameLast);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readMachineMode")]
        public async Task<IActionResult> ReadMachineMode()
        {
            var dataResult = await _plcGeneralService.ReadMachineMode();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeMachineMode")]
        public async Task<IActionResult> WriteMachineMode(ServiceEnum machineMode)
        {
            var result = await _plcGeneralService.WriteMachineMode(machineMode);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readMachineState")]
        public async Task<IActionResult> ReadMachineState()
        {
            var dataResult = await _plcGeneralService.ReadMachineState();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeMachineState")]
        public async Task<IActionResult> WriteMachineState(MachineEnum machineState)
        {
            var result = await _plcGeneralService.WriteMachineState(machineState);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readMachineSpeedSet")]
        public async Task<IActionResult> ReadMachineSpeedSet()
        {
            var dataResult = await _plcGeneralService.ReadMachineSpeedSet();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeMachineSpeedSet")]
        public async Task<IActionResult> WriteMachineSpeedSet(short machineSpeedSet)
        {
            var result = await _plcGeneralService.WriteMachineSpeedSet(machineSpeedSet);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readMachineSpeedActuel")]
        public async Task<IActionResult> ReadMachineSpeedActuel()
        {
            var dataResult = await _plcGeneralService.ReadMachineSpeedActuel();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeMachineSpeedActuel")]
        public async Task<IActionResult> WWriteMachineSpeedActuel(short machineSpeedActuel)
        {
            var result = await _plcGeneralService.WriteMachineSpeedActuel(machineSpeedActuel);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readMachineSpeedMaximum")]
        public async Task<IActionResult> ReadMachineSpeedMaximum()
        {
            var dataResult = await _plcGeneralService.ReadMachineSpeedMaximum();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeMachineSpeedMaximum")]
        public async Task<IActionResult> WriteMachineSpeedMaximum(short machineSpeedMaximum)
        {
            var result = await _plcGeneralService.WriteMachineSpeedMaximum(machineSpeedMaximum);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
