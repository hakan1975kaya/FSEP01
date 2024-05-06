using Business.Abstract.PLC.Machine;
using Core.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.PLC.Machine
{
    [Route("api/[controller]")]
    [ApiController]
    public class PLCRewinderPressuresController : ControllerBase
    {
        private IPLCRewinderPressureService _plcRewinderPressureService;
        public PLCRewinderPressuresController(IPLCRewinderPressureService plcRewinderPressureService)
        {
            _plcRewinderPressureService = plcRewinderPressureService;
        }

        [HttpGet("readRewinderOnePressureLaySetScaled")]
        public async Task<IActionResult> ReadRewinderOnePressureLaySetScaled()
        {
            var dataResult = await _plcRewinderPressureService.ReadRewinderOnePressureLaySetScaled();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderOnePressureLaySetScaled")]
        public async Task<IActionResult> WriteRewinderOnePressureLaySetScaled(decimal rewinderOnePressureLaySetScaled)
        {
            var result = await _plcRewinderPressureService.WriteRewinderOnePressureLaySetScaled(rewinderOnePressureLaySetScaled);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderOnePressureLayCalculateCharScaled")]
        public async Task<IActionResult> ReadRewinderOnePressureLayCalculateCharScaled()
        {
            var dataResult = await _plcRewinderPressureService.ReadRewinderOnePressureLayCalculateCharScaled();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderOnePressureLayCalculateCharScaled")]
        public async Task<IActionResult> WriteRewinderOnePressureLayCalculateCharScaled(decimal rewinderOnePressureLayCalculateCharScaled)
        {
            var result = await _plcRewinderPressureService.WriteRewinderOnePressureLayCalculateCharScaled(rewinderOnePressureLayCalculateCharScaled);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderOnePresureLayBalance")]
        public async Task<IActionResult> ReadRewinderOnePresureLayBalance()
        {
            var dataResult = await _plcRewinderPressureService.ReadRewinderOnePresureLayBalance();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderOnePresureLayBalance")]
        public async Task<IActionResult> WriteRewinderOnePresureLayBalance(int rewinderOnePresureLayBalance)
        {
            var result = await _plcRewinderPressureService.WriteRewinderOnePresureLayBalance(rewinderOnePresureLayBalance);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpGet("readRewinderOnePressureLayCalculateRight")]
        public async Task<IActionResult> ReadRewinderOnePressureLayCalculateRight()
        {
            var dataResult = await _plcRewinderPressureService.ReadRewinderOnePressureLayCalculateRight();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderOnePressureLayCalculateRight")]
        public async Task<IActionResult> WriteRewinderOnePressureLayCalculateRight(decimal rewinderOnePressureLayCalculateRight)
        {
            var result = await _plcRewinderPressureService.WriteRewinderOnePressureLayCalculateRight(rewinderOnePressureLayCalculateRight);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderOnePressureLayCalculateLeft")]
        public async Task<IActionResult> ReadRewinderOnePressureLayCalculateLeft()
        {
            var dataResult = await _plcRewinderPressureService.ReadRewinderOnePressureLayCalculateLeft();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderOnePressureLayCalculateLeft")]
        public async Task<IActionResult> WriteRewinderOnePressureLayCalculateLeft(decimal rewinderOnePressureLayCalculateLeft)
        {
            var result = await _plcRewinderPressureService.WriteRewinderOnePressureLayCalculateLeft(rewinderOnePressureLayCalculateLeft);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderOnePressureContactSetScaled")]
        public async Task<IActionResult> ReadRewinderOnePressureContactSetScaled()
        {
            var dataResult = await _plcRewinderPressureService.ReadRewinderOnePressureContactSetScaled();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderOnePressureContactSetScaled")]
        public async Task<IActionResult> WriteRewinderOnePressureContactSetScaled(decimal rewinderOnePressureContactSetScaled)
        {
            var result = await _plcRewinderPressureService.WriteRewinderOnePressureContactSetScaled(rewinderOnePressureContactSetScaled);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderOnePressureContactCalculateCharScaled")]
        public async Task<IActionResult> ReadRewinderOnePressureContactCalculateCharScaled()
        {
            var dataResult = await _plcRewinderPressureService.ReadRewinderOnePressureContactCalculateCharScaled();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderOnePressureContactCalculateCharScaled")]
        public async Task<IActionResult> WriteRewinderOnePressureContactCalculateCharScaled(decimal rewinderOnePressureContactCalculateCharScaled)
        {
            var result = await _plcRewinderPressureService.WriteRewinderOnePressureContactCalculateCharScaled(rewinderOnePressureContactCalculateCharScaled);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderOnePressureContactBalance")]
        public async Task<IActionResult> ReadRewinderOnePressureContactBalance()
        {
            var dataResult = await _plcRewinderPressureService.ReadRewinderOnePressureContactBalance();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderOnePressureContactBalance")]
        public async Task<IActionResult> WriteRewinderOnePressureContactBalance(int rewinderOnePressureContactBalance)
        {
            var result = await _plcRewinderPressureService.WriteRewinderOnePressureContactBalance(rewinderOnePressureContactBalance);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderOnePressureContactCalculateRight")]
        public async Task<IActionResult> ReadRewinderOnePressureContactCalculateRight()
        {
            var dataResult = await _plcRewinderPressureService.ReadRewinderOnePressureContactCalculateRight();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderOnePressureContactCalculateRight")]
        public async Task<IActionResult> WriteRewinderOnePressureContactCalculateRight(decimal rewinderOnePressureContactCalculateRight)
        {
            var result = await _plcRewinderPressureService.WriteRewinderOnePressureContactCalculateRight(rewinderOnePressureContactCalculateRight);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpGet("readRewinderOnePressureContactCalculateLeft")]
        public async Task<IActionResult> ReadRewinderOnePressureContactCalculateLeft()
        {
            var dataResult = await _plcRewinderPressureService.ReadRewinderOnePressureContactCalculateLeft();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderOnePressureContactCalculateLeft")]
        public async Task<IActionResult> WriteRewinderOnePressureContactCalculateLeft(decimal rewinderOnePressureContactCalculateLeft)
        {
            var result = await _plcRewinderPressureService.WriteRewinderOnePressureContactCalculateLeft(rewinderOnePressureContactCalculateLeft);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderTwoPressureContanctSetScaled")]
        public async Task<IActionResult> ReadRewinderTwoPressureContanctSetScaled()
        {
            var dataResult = await _plcRewinderPressureService.ReadRewinderTwoPressureContanctSetScaled();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderTwoPressureContanctSetScaled")]
        public async Task<IActionResult> WriteRewinderTwoPressureContanctSetScaled(decimal rewinderTwoPressureContanctSetScaled)
        {
            var result = await _plcRewinderPressureService.WriteRewinderTwoPressureContanctSetScaled(rewinderTwoPressureContanctSetScaled);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderTwoPressureContactCalculateCharScaled")]
        public async Task<IActionResult> ReadRewinderTwoPressureContactCalculateCharScaled()
        {
            var dataResult = await _plcRewinderPressureService.ReadRewinderTwoPressureContactCalculateCharScaled();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderTwoPressureContactCalculateCharScaled")]
        public async Task<IActionResult> WriteRewinderTwoPressureContactCalculateCharScaled(decimal rewinderTwoPressureContactCalculateCharScaled)
        {
            var result = await _plcRewinderPressureService.WriteRewinderTwoPressureContactCalculateCharScaled(rewinderTwoPressureContactCalculateCharScaled);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderTwoPressureContanctBalance")]
        public async Task<IActionResult> ReadRewinderTwoPressureContanctBalance()
        {
            var dataResult = await _plcRewinderPressureService.ReadRewinderTwoPressureContanctBalance();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderTwoPressureContanctBalance")]
        public async Task<IActionResult> WriteRewinderTwoPressureContanctBalance(int rewinderTwoPressureContanctBalance)
        {
            var result = await _plcRewinderPressureService.WriteRewinderTwoPressureContanctBalance(rewinderTwoPressureContanctBalance);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderTwoPressureContactCalculateRight")]
        public async Task<IActionResult> ReadRewinderTwoPressureContactCalculateRight()
        {
            var dataResult = await _plcRewinderPressureService.ReadRewinderTwoPressureContactCalculateRight();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderTwoPressureContactCalculateRight")]
        public async Task<IActionResult> WriteRewinderTwoPressureContactCalculateRight(decimal rewinderTwoPressureContactCalculateRight)
        {
            var result = await _plcRewinderPressureService.WriteRewinderTwoPressureContactCalculateRight(rewinderTwoPressureContactCalculateRight);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderTwoPressureContactCalculateLeft")]
        public async Task<IActionResult> ReadRewinderTwoPressureContactCalculateLeft()
        {
            var dataResult = await _plcRewinderPressureService.ReadRewinderTwoPressureContactCalculateLeft();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderTwoPressureContactCalculateLeft")]
        public async Task<IActionResult> WriteRewinderTwoPressureContactCalculateLeft(decimal rewinderTwoPressureContactCalculateLeft)
        {
            var result = await _plcRewinderPressureService.WriteRewinderTwoPressureContactCalculateLeft(rewinderTwoPressureContactCalculateLeft);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderTwoPressureSupportCalculateCharScaled")]
        public async Task<IActionResult> ReadRewinderTwoPressureSupportCalculateCharScaled()
        {
            var dataResult = await _plcRewinderPressureService.ReadRewinderTwoPressureSupportCalculateCharScaled();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderTwoPressureSupportCalculateCharScaled")]
        public async Task<IActionResult> WriteRewinderTwoPressureSupportCalculateCharScaled(decimal rewinderTwoPressureSupportCalculateCharScaled)
        {
            var result = await _plcRewinderPressureService.WriteRewinderTwoPressureSupportCalculateCharScaled(rewinderTwoPressureSupportCalculateCharScaled);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderTwoPressureSupportBalance")]
        public async Task<IActionResult> ReadRewinderTwoPressureSupportBalance()
        {
            var dataResult = await _plcRewinderPressureService.ReadRewinderTwoPressureSupportBalance();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderTwoPressureSupportBalance")]
        public async Task<IActionResult> WriteRewinderTwoPressureSupportBalance(int rewinderTwoPressureSupportBalance)
        {
            var result = await _plcRewinderPressureService.WriteRewinderTwoPressureSupportBalance(rewinderTwoPressureSupportBalance);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpGet("readRewinderTwoPressureSupportCalcuteRight")]
        public async Task<IActionResult> ReadRewinderTwoPressureSupportCalcuteRight()
        {
            var dataResult = await _plcRewinderPressureService.ReadRewinderTwoPressureSupportCalcuteRight();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderTwoPressureSupportCalcuteRight")]
        public async Task<IActionResult> WriteRewinderTwoPressureSupportCalcuteRight(decimal rewinderTwoPressureSupportCalcuteRight)
        {
            var result = await _plcRewinderPressureService.WriteRewinderTwoPressureSupportCalcuteRight(rewinderTwoPressureSupportCalcuteRight);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderTwoPressureSupportCalcuteLeft")]
        public async Task<IActionResult> ReadRewinderTwoPressureSupportCalcuteLeft()
        {
            var dataResult = await _plcRewinderPressureService.ReadRewinderTwoPressureSupportCalcuteLeft();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderTwoPressureSupportCalcuteLeft")]
        public async Task<IActionResult> WriteRewinderTwoPressureSupportCalcuteLeft(decimal rewinderTwoPressureSupportCalcuteLeft)
        {
            var result = await _plcRewinderPressureService.WriteRewinderTwoPressureSupportCalcuteLeft(rewinderTwoPressureSupportCalcuteLeft);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
