using Business.Abstract.PLC.Machine;
using Core.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.PLC.Machine
{
    [Route("api/[controller]")]
    [ApiController]
    public class PLCRewinderTensionsController : ControllerBase
    {
        private IPLCRewinderTensionService _plcRewinderTensionService;
        public PLCRewinderTensionsController(IPLCRewinderTensionService plcRewinderTensionService)
        {
            _plcRewinderTensionService = plcRewinderTensionService;
        }

        [HttpGet("readRewinderOneTensionSetScaled")]
        public async Task<IActionResult> ReadRewinderOneTensionSetScaled()
        {
            var dataResult = await _plcRewinderTensionService.ReadRewinderOneTensionSetScaled();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderOneTensionSetScaled")]
        public async Task<IActionResult> WriteRewinderOneTensionSetScaled(decimal rewinderOneTensionSetScaled)
        {
            var result = await _plcRewinderTensionService.WriteRewinderOneTensionSetScaled(rewinderOneTensionSetScaled);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderOneTensionCalculateCharScaled")]
        public async Task<IActionResult> ReadRewinderOneTensionCalculateCharScaled()
        {
            var dataResult = await _plcRewinderTensionService.ReadRewinderOneTensionCalculateCharScaled();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderOneTensionCalculateCharScaled")]
        public async Task<IActionResult> WriteRewinderOneTensionCalculateCharScaled(decimal rewinderOneTensionCalculateCharScaled)
        {
            var result = await _plcRewinderTensionService.WriteRewinderOneTensionCalculateCharScaled(rewinderOneTensionCalculateCharScaled);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderOneTensionActuelMeasureScaled")]
        public async Task<IActionResult> ReadRewinderOneTensionActuelMeasureScaled()
        {
            var dataResult = await _plcRewinderTensionService.ReadRewinderOneTensionActuelMeasureScaled();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderOneTensionActuelMeasureScaled")]
        public async Task<IActionResult> WriteRewinderOneTensionActuelMeasureScaled(decimal rewinderOneTensionActuelMeasureScaled)
        {
            var result = await _plcRewinderTensionService.WriteRewinderOneTensionActuelMeasureScaled(rewinderOneTensionActuelMeasureScaled);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderOneTensionCalculateCharNewton")]
        public async Task<IActionResult> ReadRewinderOneTensionCalculateCharNewton()
        {
            var dataResult = await _plcRewinderTensionService.ReadRewinderOneTensionCalculateCharNewton();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderOneTensionCalculateCharNewton")]
        public async Task<IActionResult> WriteRewinderOneTensionCalculateCharNewton(decimal rewinderOneTensionCalculateCharNewton)
        {
            var result = await _plcRewinderTensionService.WriteRewinderOneTensionCalculateCharNewton(rewinderOneTensionCalculateCharNewton);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderOneTensionActuelMeasureNewton")]
        public async Task<IActionResult> ReadRewinderOneTensionActuelMeasureNewton()
        {
            var dataResult = await _plcRewinderTensionService.ReadRewinderOneTensionActuelMeasureNewton();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderOneTensionActuelMeasureNewton")]
        public async Task<IActionResult> WriteRewinderOneTensionActuelMeasureNewton(decimal rewinderOneTensionActuelMeasureNewton)
        {
            var result = await _plcRewinderTensionService.WriteRewinderOneTensionActuelMeasureNewton(rewinderOneTensionActuelMeasureNewton);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderOneTensionContactSetScaled")]
        public async Task<IActionResult> ReadRewinderOneTensionContactSetScaled()
        {
            var dataResult = await _plcRewinderTensionService.ReadRewinderOneTensionContactSetScaled();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderOneTensionContactSetScaled")]
        public async Task<IActionResult> WriteRewinderOneTensionContactSetScaled(decimal rewinderOneTensionContactSetScaled)
        {
            var result = await _plcRewinderTensionService.WriteRewinderOneTensionContactSetScaled(rewinderOneTensionContactSetScaled);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderOneMaterialWidth")]
        public async Task<IActionResult> ReadRewinderOneMaterialWidth()
        {
            var dataResult = await _plcRewinderTensionService.ReadRewinderOneMaterialWidth();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderOneMaterialWidth")]
        public async Task<IActionResult> WriteRewinderOneMaterialWidth(short rewinderOneMaterialWidth)
        {
            var result = await _plcRewinderTensionService.WriteRewinderOneMaterialWidth(rewinderOneMaterialWidth);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderOneShaft")]
        public async Task<IActionResult> ReadRewinderOneShaft()
        {
            var dataResult = await _plcRewinderTensionService.ReadRewinderOneShaft();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderOneShaft")]
        public async Task<IActionResult> WriteRewinderOneShaft(short rewinderOneShaft)
        {
            var result = await _plcRewinderTensionService.WriteRewinderOneShaft(rewinderOneShaft);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderTwoTensionContactSetScaled")]
        public async Task<IActionResult> ReadRewinderTwoTensionContactSetScaled()
        {
            var dataResult = await _plcRewinderTensionService.ReadRewinderTwoTensionContactSetScaled();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderTwoTensionContactSetScaled")]
        public async Task<IActionResult> WriteRewinderTwoTensionContactSetScaled(decimal rewinderTwoTensionContactSetScaled)
        {
            var result = await _plcRewinderTensionService.WriteRewinderTwoTensionContactSetScaled(rewinderTwoTensionContactSetScaled);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderTwoTensionSetScaled")]
        public async Task<IActionResult> ReadRewinderTwoTensionSetScaled()
        {
            var dataResult = await _plcRewinderTensionService.ReadRewinderTwoTensionSetScaled();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderTwoTensionSetScaled")]
        public async Task<IActionResult> WriteRewinderTwoTensionSetScaled(decimal rewinderTwoTensionSetScaled)
        {
            var result = await _plcRewinderTensionService.WriteRewinderTwoTensionSetScaled(rewinderTwoTensionSetScaled);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpGet("readRewinderTwoTensionCalculeteCharScaled")]
        public async Task<IActionResult> ReadRewinderTwoTensionCalculeteCharScaled()
        {
            var dataResult = await _plcRewinderTensionService.ReadRewinderTwoTensionCalculeteCharScaled();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderTwoTensionCalculeteCharScaled")]
        public async Task<IActionResult> WriteRewinderTwoTensionCalculeteCharScaled(decimal rewinderTwoTensionCalculeteCharScaled)
        {
            var result = await _plcRewinderTensionService.WriteRewinderTwoTensionCalculeteCharScaled(rewinderTwoTensionCalculeteCharScaled);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderTwoTensionActuelMeasureScaled")]
        public async Task<IActionResult> ReadRewinderTwoTensionActuelMeasureScaled()
        {
            var dataResult = await _plcRewinderTensionService.ReadRewinderTwoTensionActuelMeasureScaled();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderTwoTensionActuelMeasureScaled")]
        public async Task<IActionResult> WriteRewinderTwoTensionActuelMeasureScaled(decimal rewinderTwoTensionActuelMeasureScaled)
        {
            var result = await _plcRewinderTensionService.WriteRewinderTwoTensionActuelMeasureScaled(rewinderTwoTensionActuelMeasureScaled);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderTwoTensionCalculateCharNewton")]
        public async Task<IActionResult> ReadRewinderTwoTensionCalculateCharNewton()
        {
            var dataResult = await _plcRewinderTensionService.ReadRewinderTwoTensionCalculateCharNewton();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderTwoTensionCalculateCharNewton")]
        public async Task<IActionResult> WriteRewinderTwoTensionCalculateCharNewton(short rewinderTwoTensionCalculateCharNewton)
        {
            var result = await _plcRewinderTensionService.WriteRewinderTwoTensionCalculateCharNewton(rewinderTwoTensionCalculateCharNewton);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderTwoTensionActuelMeasureNewton")]
        public async Task<IActionResult> ReadRewinderTwoTensionActuelMeasureNewton()
        {
            var dataResult = await _plcRewinderTensionService.ReadRewinderTwoTensionActuelMeasureNewton();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderTwoTensionActuelMeasureNewton")]
        public async Task<IActionResult> WriteRewinderTwoTensionActuelMeasureNewton(short rewinderTwoTensionActuelMeasureNewton)
        {
            var result = await _plcRewinderTensionService.WriteRewinderTwoTensionActuelMeasureNewton(rewinderTwoTensionActuelMeasureNewton);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderTwoMaterialWidth")]
        public async Task<IActionResult> ReadRewinderTwoMaterialWidth()
        {
            var dataResult = await _plcRewinderTensionService.ReadRewinderTwoMaterialWidth();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderTwoMaterialWidth")]
        public async Task<IActionResult> WriteRewinderTwoMaterialWidth(short rewinderTwoMaterialWidth)
        {
            var result = await _plcRewinderTensionService.WriteRewinderTwoMaterialWidth(rewinderTwoMaterialWidth);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderTwoShaft")]
        public async Task<IActionResult> ReadRewinderTwoShaft()
        {
            var dataResult = await _plcRewinderTensionService.ReadRewinderTwoShaft();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderTwoShaft")]
        public async Task<IActionResult> WriteRewinderTwoShaft(short rewinderTwoShaft)
        {
            var result = await _plcRewinderTensionService.WriteRewinderTwoShaft(rewinderTwoShaft);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
