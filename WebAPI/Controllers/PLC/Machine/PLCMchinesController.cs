using Business.Abstract.PLC.Machine;
using Core.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.PLC.Machine
{
    [Route("api/[controller]")]
    [ApiController]
    public class PLCMchinesController : ControllerBase
    {
        private IPLCMachineService _plcMachineService;
        public PLCMchinesController(IPLCMachineService plcMachineService)
        {
            _plcMachineService = plcMachineService;
        }


        [HttpGet("readMachineSpeedSet")]
        public async Task<IActionResult> ReadMachineSpeedSet()
        {
            var dataResult = await _plcMachineService.ReadMachineSpeedSet();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeMachineSpeedSet")]
        public async Task<IActionResult> WriteMachineSpeedSet(long machineSpeedSet)
        {
            var result = await _plcMachineService.WriteMachineSpeedSet(machineSpeedSet);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readTransportOneTensionSet")]
        public async Task<IActionResult> ReadTransportOneTensionSet()
        {
            var dataResult = await _plcMachineService.ReadTransportOneTensionSet();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeTransportOneTensionSet")]
        public async Task<IActionResult> WriteTransportOneTensionSet(long transportOneTensionSet)
        {
            var result = await _plcMachineService.WriteTransportOneTensionSet(transportOneTensionSet);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readTransportTwoTensionSet")]
        public async Task<IActionResult> ReadTransportTwoTensionSet()
        {
            var dataResult = await _plcMachineService.ReadTransportTwoTensionSet();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeTransportTwoTensionSet")]
        public async Task<IActionResult> WriteTransportTwoTensionSet(long transportTwoTensionSet)
        {
            var result = await _plcMachineService.WriteTransportTwoTensionSet(transportTwoTensionSet);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readWeightRewinderOne")]
        public async Task<IActionResult> ReadWeightRewinderOne()
        {
            var dataResult = await _plcMachineService.ReadWeightRewinderOne();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeWeightRewinderOne")]
        public async Task<IActionResult> WriteWeightRewinderOne(long weightRewinderOne)
        {
            var result = await _plcMachineService.WriteWeightRewinderOne(weightRewinderOne);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readWeightRewinderTwo")]
        public async Task<IActionResult> ReadWeightRewinderTwo()
        {
            var dataResult = await _plcMachineService.ReadWeightRewinderTwo();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeWeightRewinderTwo")]
        public async Task<IActionResult> WriteWeightRewinderTwo(long weightRewinderTwo)
        {
            var result = await _plcMachineService.WriteWeightRewinderTwo(weightRewinderTwo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderOneDiameterSet")]
        public async Task<IActionResult> ReadRewinderOneDiameterSet()
        {
            var dataResult = await _plcMachineService.ReadRewinderOneDiameterSet();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderOneDiameterSet")]
        public async Task<IActionResult> WriteRewinderOneDiameterSet(long rewinderOneDiameterSet)
        {
            var result = await _plcMachineService.WriteRewinderOneDiameterSet(rewinderOneDiameterSet);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderOneDiameterActuel")]
        public async Task<IActionResult> ReadRewinderOneDiameterActuel()
        {
            var dataResult = await _plcMachineService.ReadRewinderOneDiameterActuel();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderOneDiameterActuel")]
        public async Task<IActionResult> WriteRewinderOneDiameterActuel(long rewinderOneDiameterActuel)
        {
            var result = await _plcMachineService.WriteRewinderOneDiameterActuel(rewinderOneDiameterActuel);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderOneLengthSet")]
        public async Task<IActionResult> ReadRewinderOneLengthSet()
        {
            var dataResult = await _plcMachineService.ReadRewinderOneLengthSet();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderOneLengthSet")]
        public async Task<IActionResult> WriteRewinderOneLengthSet(long rewinderOneLengthSet)
        {
            var result = await _plcMachineService.WriteRewinderOneLengthSet(rewinderOneLengthSet);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderOneLengthActuel")]
        public async Task<IActionResult> ReadRewinderOneLengthActuel()
        {
            var dataResult = await _plcMachineService.ReadRewinderOneLengthActuel();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderOneLengthActuel")]
        public async Task<IActionResult> WriteRewinderOneLengthActuel(long rewinderOneLengthActuel)
        {
            var result = await _plcMachineService.WriteRewinderOneLengthActuel(rewinderOneLengthActuel);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderTwoDiameterSet")]
        public async Task<IActionResult> ReadRewinderTwoDiameterSet()
        {
            var dataResult = await _plcMachineService.ReadRewinderTwoDiameterSet();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderTwoDiameterSet")]
        public async Task<IActionResult> WriteRewinderTwoDiameterSet(long rewinderTwoDiameterSet)
        {
            var result = await _plcMachineService.WriteRewinderTwoDiameterSet(rewinderTwoDiameterSet);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderTwoDiameterActuel")]
        public async Task<IActionResult> ReadRewinderTwoDiameterActuel()
        {
            var dataResult = await _plcMachineService.ReadRewinderTwoDiameterActuel();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderTwoDiameterActuel")]
        public async Task<IActionResult> WriteRewinderTwoDiameterActuel(long rewinderTwoDiameterActuel)
        {
            var result = await _plcMachineService.WriteRewinderTwoDiameterActuel(rewinderTwoDiameterActuel);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderTwoLengthSet")]
        public async Task<IActionResult> ReadRewinderTwoLengthSet()
        {
            var dataResult = await _plcMachineService.ReadRewinderTwoLengthSet();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderTwoLengthSet")]
        public async Task<IActionResult> WriteRewinderTwoLengthSet(long rewinderTwoLengthSet)
        {
            var result = await _plcMachineService.WriteRewinderTwoLengthSet(rewinderTwoLengthSet);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderTwoLengthActuel")]
        public async Task<IActionResult> ReadRewinderTwoLengthActuel()
        {
            var dataResult = await _plcMachineService.ReadRewinderTwoLengthActuel();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderTwoLengthActuel")]
        public async Task<IActionResult> WriteRewinderTwoLengthActuel(long rewinderTwoLengthActuel)
        {
            var result = await _plcMachineService.WriteRewinderTwoLengthActuel(rewinderTwoLengthActuel);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readUnwinderOneDiameterSet")]
        public async Task<IActionResult> ReadUnwinderOneDiameterSet()
        {
            var dataResult = await _plcMachineService.ReadUnwinderOneDiameterSet();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeUnwinderOneDiameterSet")]
        public async Task<IActionResult> WriteUnwinderOneDiameterSet(long unwinderOneDiameterSet)
        {
            var result = await _plcMachineService.WriteUnwinderOneDiameterSet(unwinderOneDiameterSet);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpGet("readUnwinderOneDiameterActuel")]
        public async Task<IActionResult> ReadUnwinderOneDiameterActuel()
        {
            var dataResult = await _plcMachineService.ReadUnwinderOneDiameterActuel();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeUnwinderOneDiameterActuel")]
        public async Task<IActionResult> WriteUnwinderOneDiameterActuel(long unwinderOneDiameterActuel)
        {
            var result = await _plcMachineService.WriteUnwinderOneDiameterActuel(unwinderOneDiameterActuel);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderOneResetLength")]
        public async Task<IActionResult> ReadRewinderOneResetLength()
        {
            var dataResult = await _plcMachineService.ReadRewinderOneResetLength();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderOneResetLength")]
        public async Task<IActionResult> WriteRewinderOneResetLength(bool rewinderOneResetLength)
        {
            var result = await _plcMachineService.WriteRewinderOneResetLength(rewinderOneResetLength);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderTwoResetLength")]
        public async Task<IActionResult> ReadRewinderTwoResetLength()
        {
            var dataResult = await _plcMachineService.ReadRewinderTwoResetLength();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderTwoResetLength")]
        public async Task<IActionResult> WriteRewinderTwoResetLength(bool rewinderTwoResetLength)
        {
            var result = await _plcMachineService.WriteRewinderTwoResetLength(rewinderTwoResetLength);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
