using Business.Abstract.PLC.Machine;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.PLC.Machine
{
    [Route("api/[controller]")]
    [ApiController]
    public class PLCMachineOverviewsController : ControllerBase
    {
        private IPLCMachineOverviewService _plcMachineOverviewService;
        public PLCMachineOverviewsController(IPLCMachineOverviewService plcMachineOverviewService)
        {
            _plcMachineOverviewService = plcMachineOverviewService;
        }


        [HttpGet("readUnwinderOneDiameterActuel")]
        public async Task<IActionResult> ReadUnwinderOneDiameterActuel()
        {
            var dataResult = await _plcMachineOverviewService.ReadUnwinderOneDiameterActuel();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeUnwinderOneDiameterActuel")]
        public async Task<IActionResult> WriteUnwinderOneDiameterActuel(long unwinderOneDiameterActuel)
        {
            var result = await _plcMachineOverviewService.WriteUnwinderOneDiameterActuel(unwinderOneDiameterActuel);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readTransportOneTensionSet")]
        public async Task<IActionResult> ReadTransportOneTensionSet()
        {
            var dataResult = await _plcMachineOverviewService.ReadTransportOneTensionSet();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeTransportOneTensionSet")]
        public async Task<IActionResult> WriteTransportOneTensionSet(long transportOneTensionSet)
        {
            var result = await _plcMachineOverviewService.WriteTransportOneTensionSet(transportOneTensionSet);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readTransportTwoTensionSet")]
        public async Task<IActionResult> ReadTransportTwoTensionSet()
        {
            var dataResult = await _plcMachineOverviewService.ReadTransportTwoTensionSet();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeTransportTwoTensionSet")]
        public async Task<IActionResult> WriteTransportTwoTensionSet(long transportTwoTensionSet)
        {
            var result = await _plcMachineOverviewService.WriteTransportTwoTensionSet(transportTwoTensionSet);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpGet("readRewinderOneTensionLaySetScaled")]
        public async Task<IActionResult> ReadRewinderOneTensionLaySetScaled()
        {
            var dataResult = await _plcMachineOverviewService.ReadRewinderOneTensionLaySetScaled();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderOneTensionLaySetScaled")]
        public async Task<IActionResult> WriteRewinderOneTensionLaySetScaled(decimal rewinderOneTensionLaySetScaled)
        {
            var result = await _plcMachineOverviewService.WriteRewinderOneTensionLaySetScaled(rewinderOneTensionLaySetScaled);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderOneTensionCalculateCharScaled")]
        public async Task<IActionResult> ReadRewinderOneTensionCalculateCharScaled()
        {
            var dataResult = await _plcMachineOverviewService.ReadRewinderOneTensionCalculateCharScaled();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderOneTensionCalculateCharScaled")]
        public async Task<IActionResult> WriteRewinderOneTensionCalculateCharScaled(decimal rewinderOneTensionCalculateCharScaled)
        {
            var result = await _plcMachineOverviewService.WriteRewinderOneTensionCalculateCharScaled(rewinderOneTensionCalculateCharScaled);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderOneLengthActuel")]
        public async Task<IActionResult> ReadRewinderOneLengthActuel()
        {
            var dataResult = await _plcMachineOverviewService.ReadRewinderOneLengthActuel();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderOneLengthActuel")]
        public async Task<IActionResult> WriteRewinderOneLengthActuel(long rewinderOneLengthActuel)
        {
            var result = await _plcMachineOverviewService.WriteRewinderOneLengthActuel(rewinderOneLengthActuel);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpGet("readRewinderOneDiameterActuel")]
        public async Task<IActionResult> ReadRewinderOneDiameterActuel()
        {
            var dataResult = await _plcMachineOverviewService.ReadRewinderOneDiameterActuel();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderOneDiameterActuel")]
        public async Task<IActionResult> WriteRewinderOneDiameterActuel(long rewinderOneDiameterActuel)
        {
            var result = await _plcMachineOverviewService.WriteRewinderOneDiameterActuel(rewinderOneDiameterActuel);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readContactOneTensionActuel")]
        public async Task<IActionResult> ReadContactOneTensionActuel()
        {
            var dataResult = await _plcMachineOverviewService.ReadContactOneTensionActuel();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeContactOneTensionActuel")]
        public async Task<IActionResult> WriteContactOneTensionActuel(decimal contactOneTensionActuel)
        {
            var result = await _plcMachineOverviewService.WriteContactOneTensionActuel(contactOneTensionActuel);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("readContactTwoTensionActuel")]
        public async Task<IActionResult> ReadContactTwoTensionActuel()
        {
            var dataResult = await _plcMachineOverviewService.ReadContactTwoTensionActuel();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeContactTwoTensionActuel")]
        public async Task<IActionResult> WriteContactTwoTensionActuel(decimal contactTwoTensionActuel)
        {
            var result = await _plcMachineOverviewService.WriteContactTwoTensionActuel(contactTwoTensionActuel);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderTwoTensionCalculateCharScaled")]
        public async Task<IActionResult> ReadRewinderTwoTensionCalculateCharScaled()
        {
            var dataResult = await _plcMachineOverviewService.ReadRewinderTwoTensionCalculateCharScaled();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderTwoTensionCalculateCharScaled")]
        public async Task<IActionResult> WriteRewinderTwoTensionCalculateCharScaled(decimal rewinderTwoTensionCalculateCharScaled)
        {
            var result = await _plcMachineOverviewService.WriteRewinderTwoTensionCalculateCharScaled(rewinderTwoTensionCalculateCharScaled);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpGet("readRewinderTwoLengthActuel")]
        public async Task<IActionResult> ReadRewinderTwoLengthActuel()
        {
            var dataResult = await _plcMachineOverviewService.ReadRewinderTwoLengthActuel();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderTwoLengthActuel")]
        public async Task<IActionResult> WriteRewinderTwoLengthActuel(long rewinderTwoLengthActuel)
        {
            var result = await _plcMachineOverviewService.WriteRewinderTwoLengthActuel(rewinderTwoLengthActuel);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderTwoDiameterActuel")]
        public async Task<IActionResult> ReadRewinderTwoDiameterActuel()
        {
            var dataResult = await _plcMachineOverviewService.ReadRewinderTwoDiameterActuel();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderTwoDiameterActuel")]
        public async Task<IActionResult> WriteRewinderTwoDiameterActuel(long rewinderTwoDiameterActuel)
        {
            var result = await _plcMachineOverviewService.WriteRewinderTwoDiameterActuel(rewinderTwoDiameterActuel);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderTwoTensionSupportSetScaled")]
        public async Task<IActionResult> ReadRewinderTwoTensionSupportSetScaled()
        {
            var dataResult = await _plcMachineOverviewService.ReadRewinderTwoTensionSupportSetScaled();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderTwoTensionSupportSetScaled")]
        public async Task<IActionResult> WriteRewinderTwoTensionSupportSetScaled(decimal rewinderTwoTensionSupportSetScaled)
        {
            var result = await _plcMachineOverviewService.WriteRewinderTwoTensionSupportSetScaled(rewinderTwoTensionSupportSetScaled);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderOnePressureLayCalculateCharScaled")]
        public async Task<IActionResult> ReadRewinderOnePressureLayCalculateCharScaled()
        {
            var dataResult = await _plcMachineOverviewService.ReadRewinderOnePressureLayCalculateCharScaled();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderOnePressureLayCalculateCharScaled")]
        public async Task<IActionResult> WriteRewinderOnePressureLayCalculateCharScaled(decimal rewinderOnePressureLayCalculateCharScaled)
        {
            var result = await _plcMachineOverviewService.WriteRewinderOnePressureLayCalculateCharScaled(rewinderOnePressureLayCalculateCharScaled);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderOnePressureContactCalculateCharScaled")]
        public async Task<IActionResult> ReadRewinderOnePressureContactCalculateCharScaled()
        {
            var dataResult = await _plcMachineOverviewService.ReadRewinderOnePressureContactCalculateCharScaled();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderOnePressureContactCalculateCharScaled")]
        public async Task<IActionResult> WriteRewinderOnePressureContactCalculateCharScaled(decimal rewinderOnePressureContactCalculateCharScaled)
        {
            var result = await _plcMachineOverviewService.WriteRewinderOnePressureContactCalculateCharScaled(rewinderOnePressureContactCalculateCharScaled);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpGet("readRewinderTwoPressureContactCalculateCharScaled")]
        public async Task<IActionResult> ReadRewinderTwoPressureContactCalculateCharScaled()
        {
            var dataResult = await _plcMachineOverviewService.ReadRewinderTwoPressureContactCalculateCharScaled();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderTwoPressureContactCalculateCharScaled")]
        public async Task<IActionResult> WriteRewinderTwoPressureContactCalculateCharScaled(decimal rewinderTwoPressureContactCalculateCharScaled)
        {
            var result = await _plcMachineOverviewService.WriteRewinderTwoPressureContactCalculateCharScaled(rewinderTwoPressureContactCalculateCharScaled);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpGet("readRewinderTwoPressureSupportCalculateCharScaled")]
        public async Task<IActionResult> ReadRewinderTwoPressureSupportCalculateCharScaled()
        {
            var dataResult = await _plcMachineOverviewService.ReadRewinderTwoPressureSupportCalculateCharScaled();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderTwoPressureSupportCalculateCharScaled")]
        public async Task<IActionResult> WriteRewinderTwoPressureSupportCalculateCharScaled(decimal rewinderTwoPressureSupportCalculateCharScaled)
        {
            var result = await _plcMachineOverviewService.WriteRewinderTwoPressureSupportCalculateCharScaled(rewinderTwoPressureSupportCalculateCharScaled);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}

