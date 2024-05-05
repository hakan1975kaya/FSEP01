using Business.Abstract.PLC.Machine;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.PLC.Machine
{
    [Route("api/[controller]")]
    [ApiController]
    public class PLCDensitysController : ControllerBase
    {
        private IPLCDensityService _plcDensityService;
        public PLCDensitysController(IPLCDensityService plcDensityService)
        {
            _plcDensityService = plcDensityService;
        }

        [HttpGet("readRewinderOneDensityGraph")]
        public async Task<IActionResult> ReadRewinderOneDensityGraph()
        {
            var dataResult = await _plcDensityService.ReadRewinderOneDensityGraph();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderOneDensityGraph")]
        public async Task<IActionResult> WriteRewinderOneDensityGraph(int rewinderOneDensityGraph)
        {
            var result = await _plcDensityService.WriteRewinderOneDensityGraph(rewinderOneDensityGraph);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderTwoDensityGraph")]
        public async Task<IActionResult> ReadRewinderTwoDensityGraph()
        {
            var dataResult = await _plcDensityService.ReadRewinderTwoDensityGraph();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderTwoDensityGraph")]
        public async Task<IActionResult> WriteRewinderTwoDensityGraph(int rewinderTwoDensityGraph)
        {
            var result = await _plcDensityService.WriteRewinderTwoDensityGraph(rewinderTwoDensityGraph);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readMachineSpeedActuelArchive")]
        public async Task<IActionResult> ReadMachineSpeedActuelArchive()
        {
            var dataResult = await _plcDensityService.ReadMachineSpeedActuelArchive();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeMachineSpeedActuelArchive")]
        public async Task<IActionResult> WriteMachineSpeedActuelArchive(int machineSpeedActuelArchive)
        {
            var result = await _plcDensityService.WriteMachineSpeedActuelArchive(machineSpeedActuelArchive);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpGet("readMaterialThickness")]
        public async Task<IActionResult> ReadMaterialThickness()
        {
            var dataResult = await _plcDensityService.ReadMaterialThickness();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeMaterialThickness")]
        public async Task<IActionResult> WriteMaterialThickness(decimal materialThickness)
        {
            var result = await _plcDensityService.WriteMaterialThickness(materialThickness);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderOneDiameterActuel")]
        public async Task<IActionResult> ReadRewinderOneDiameterActuel()
        {
            var dataResult = await _plcDensityService.ReadRewinderOneDiameterActuel();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderOneDiameterActuel")]
        public async Task<IActionResult> WriteRewinderOneDiameterActuel(long rewinderOneDiameterActuel)
        {
            var result = await _plcDensityService.WriteRewinderOneDiameterActuel(rewinderOneDiameterActuel);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpGet("readRewinderOneLengthActuel")]
        public async Task<IActionResult> ReadRewinderOneLengthActuel()
        {
            var dataResult = await _plcDensityService.ReadRewinderOneLengthActuel();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderOneLengthActuel")]
        public async Task<IActionResult> WriteRewinderOneLengthActuel(long rewinderOneLengthActuel)
        {
            var result = await _plcDensityService.WriteRewinderOneLengthActuel(rewinderOneLengthActuel);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderTwoDiameterActuel")]
        public async Task<IActionResult> ReadRewinderTwoDiameterActuel()
        {
            var dataResult = await _plcDensityService.ReadRewinderTwoDiameterActuel();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderTwoDiameterActuel")]
        public async Task<IActionResult> WriteRewinderTwoDiameterActuel(long rewinderTwoDiameterActuel)
        {
            var result = await _plcDensityService.WriteRewinderTwoDiameterActuel(rewinderTwoDiameterActuel);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderTwoLengthActuel")]
        public async Task<IActionResult> ReadRewinderTwoLengthActuel()
        {
            var dataResult = await _plcDensityService.ReadRewinderTwoLengthActuel();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderTwoLengthActuel")]
        public async Task<IActionResult> WriteRewinderTwoLengthActuel(long rewinderTwoDiameterActuel)
        {
            var result = await _plcDensityService.WriteRewinderTwoLengthActuel(rewinderTwoDiameterActuel);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
