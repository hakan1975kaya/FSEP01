using Business.Abstract.PLC.Machine;
using Entities.Concrete.Entities.PLC.Machine;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.PLC.Machine
{
    [Route("api/[controller]")]
    [ApiController]
    public class PLCBasicDatasController : ControllerBase
    {
        private IPLCBasicDataService _plcBasicDataService;
        public PLCBasicDatasController(IPLCBasicDataService plcBasicDataService)
        {
            _plcBasicDataService = plcBasicDataService;
        }

        [HttpGet("readRewinderOneDiameterLayRoll")]
        public async Task<IActionResult> ReadRewinderOneDiameterLayRoll()
        {
            var dataResult = await _plcBasicDataService.ReadRewinderOneDiameterLayRoll();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderOneDiameterLayRoll")]
        public async Task<IActionResult> WriteRewinderOneDiameterLayRoll(decimal rewinderOneDiameterLayRoll)
        {
            var result = await _plcBasicDataService.WriteRewinderOneDiameterLayRoll(rewinderOneDiameterLayRoll);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderOneDiameterContactRoll")]
        public async Task<IActionResult> ReadRewinderOneDiameterContactRoll()
        {
            var dataResult = await _plcBasicDataService.ReadRewinderOneDiameterContactRoll();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderOneDiameterContactRoll")]
        public async Task<IActionResult> WriteRewinderOneDiameterContactRoll(decimal rewinderOneDiameterContactRoll)
        {
            var result = await _plcBasicDataService.WriteRewinderOneDiameterContactRoll(rewinderOneDiameterContactRoll);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderTwoDiameterContactRoll")]
        public async Task<IActionResult> ReadRewinderTwoDiameterContactRoll()
        {
            var dataResult = await _plcBasicDataService.ReadRewinderTwoDiameterContactRoll();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderTwoDiameterContactRoll")]
        public async Task<IActionResult> WriteRewinderTwoDiameterContactRoll(decimal rewinderTwoDiameterContactRoll)
        {
            var result = await _plcBasicDataService.WriteRewinderTwoDiameterContactRoll(rewinderTwoDiameterContactRoll);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readRewinderTwoDiameterSupportRoll")]
        public async Task<IActionResult> ReadRewinderTwoDiameterSupportRoll()
        {
            var dataResult = await _plcBasicDataService.ReadRewinderTwoDiameterSupportRoll();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeRewinderTwoDiameterSupportRoll")]
        public async Task<IActionResult> WriteRewinderTwoDiameterSupportRoll(decimal rewinderTwoDiameterSupportRoll)
        {
            var result = await _plcBasicDataService.WriteRewinderTwoDiameterSupportRoll(rewinderTwoDiameterSupportRoll);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readMaterialSpecGravity")]
        public async Task<IActionResult> ReadMaterialSpecGravity()
        {
            var dataResult = await _plcBasicDataService.ReadMaterialSpecGravity();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeMaterialSpecGravity")]
        public async Task<IActionResult> WriteMaterialSpecGravity(decimal materialSpecGravity)
        {
            var result = await _plcBasicDataService.WriteMaterialSpecGravity(materialSpecGravity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readUnwinderOneMaterialWidth")]
        public async Task<IActionResult> ReadUnwinderOneMaterialWidth()
        {
            var dataResult = await _plcBasicDataService.ReadUnwinderOneMaterialWidth();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeUnwinderOneMaterialWidth")]
        public async Task<IActionResult> WriteUnwinderOneMaterialWidth(int unwinderOneMaterialWidth)
        {
            var result = await _plcBasicDataService.WriteUnwinderOneMaterialWidth(unwinderOneMaterialWidth);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readMaterialThickness")]
        public async Task<IActionResult> ReadMaterialThickness()
        {
            var dataResult = await _plcBasicDataService.ReadMaterialThickness();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeMaterialThickness")]
        public async Task<IActionResult> WriteMaterialThickness(decimal materialThickness)
        {
            var result = await _plcBasicDataService.WriteMaterialThickness(materialThickness);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readMaterialThicknessCalculatedValueActuel")]
        public async Task<IActionResult> ReadMaterialThicknessCalculatedValueActuel()
        {
            var dataResult = await _plcBasicDataService.ReadMaterialThicknessCalculatedValueActuel();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeMaterialThicknessCalculatedValueActuel")]
        public async Task<IActionResult> WriteMaterialThicknessCalculatedValueActuel(decimal materialThicknessCalculatedValueActuel)
        {
            var result = await _plcBasicDataService.WriteMaterialThicknessCalculatedValueActuel(materialThicknessCalculatedValueActuel);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readMaterialThicknessCalculatedValueMinimum")]
        public async Task<IActionResult> ReadMaterialThicknessCalculatedValueMinimum()
        {
            var dataResult = await _plcBasicDataService.ReadMaterialThicknessCalculatedValueMinimum();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writenMaterialThicknessCalculatedValueMinimum")]
        public async Task<IActionResult> WritenMaterialThicknessCalculatedValueMinimum(decimal materialThicknessCalculatedValueMinimum)
        {
            var result = await _plcBasicDataService.WritenMaterialThicknessCalculatedValueMinimum(materialThicknessCalculatedValueMinimum);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readMaterialThicknessCalculatedValueMaximum")]
        public async Task<IActionResult> ReadMaterialThicknessCalculatedValueMaximum()
        {
            var dataResult = await _plcBasicDataService.ReadMaterialThicknessCalculatedValueMaximum();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeMaterialThicknessCalculatedValueMaximum")]
        public async Task<IActionResult> WriteMaterialThicknessCalculatedValueMaximum(decimal materialThicknessCalculatedValueMaximum)
        {
            var result = await _plcBasicDataService.WriteMaterialThicknessCalculatedValueMaximum(materialThicknessCalculatedValueMaximum);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readMachineWeldingSpeedSet")]
        public async Task<IActionResult> ReadMachineWeldingSpeedSet()
        {
            var dataResult = await _plcBasicDataService.ReadMachineWeldingSpeedSet();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeMachineWeldingSpeedSet")]
        public async Task<IActionResult> WriteMachineWeldingSpeedSet(short machineWeldingSpeedSet)
        {
            var result = await _plcBasicDataService.WriteMachineWeldingSpeedSet(machineWeldingSpeedSet);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readMachineWeldingAmplitudeSet")]
        public async Task<IActionResult> ReadMachineWeldingAmplitudeSet()
        {
            var dataResult = await _plcBasicDataService.ReadMachineWeldingAmplitudeSet();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeMachineWeldingAmplitudeSet")]
        public async Task<IActionResult> WriteMachineWeldingAmplitudeSet(short machineWeldingAmplitudeSet)
        {
            var result = await _plcBasicDataService.WriteMachineWeldingAmplitudeSet(machineWeldingAmplitudeSet);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readMachineWeldingPowerActuel")]
        public async Task<IActionResult> ReadMachineWeldingPowerActuel()
        {
            var dataResult = await _plcBasicDataService.ReadMachineWeldingPowerActuel();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeMachineWeldingPowerActuel")]
        public async Task<IActionResult> WriteMachineWeldingPowerActuel(decimal machineWeldingPowerActuel)
        {
            var result = await _plcBasicDataService.WriteMachineWeldingPowerActuel(machineWeldingPowerActuel);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readMachineTimeAcceleration")]
        public async Task<IActionResult> ReadMachineTimeAcceleration()
        {
            var dataResult = await _plcBasicDataService.ReadMachineTimeAcceleration();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeMachineTimeAcceleration")]
        public async Task<IActionResult> WriteMachineTimeAcceleration(short machineTimeAcceleration)
        {
            var result = await _plcBasicDataService.WriteMachineTimeAcceleration(machineTimeAcceleration);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readMachineTimeDecelaration")]
        public async Task<IActionResult> ReadMachineTimeDecelaration()
        {
            var dataResult = await _plcBasicDataService.ReadMachineTimeDecelaration();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeMachineTimeDecelaration")]
        public async Task<IActionResult> WriteMachineTimeDecelaration(short machineTimeAcceleration)
        {
            var result = await _plcBasicDataService.WriteMachineTimeDecelaration(machineTimeAcceleration);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readMachineTimeFastStop")]
        public async Task<IActionResult> ReadMachineTimeFastStop()
        {
            var dataResult = await _plcBasicDataService.ReadMachineTimeFastStop();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeMachineTimeFastStop")]
        public async Task<IActionResult> WriteMachineTimeFastStop(short machineTimeFastStop)
        {
            var result = await _plcBasicDataService.WriteMachineTimeFastStop(machineTimeFastStop);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readMachineSpeedJog")]
        public async Task<IActionResult> ReadMachineSpeedJog()
        {
            var dataResult = await _plcBasicDataService.ReadMachineSpeedJog();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeMachineSpeedJog")]
        public async Task<IActionResult> WriteMachineSpeedJog(short machineSpeedJog)
        {
            var result = await _plcBasicDataService.WriteMachineSpeedJog(machineSpeedJog);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpGet("readPLCBasicData")]
        public async Task<IActionResult> ReadPLCBasicData()
        {
            var dataResult = await _plcBasicDataService.ReadPLCBasicData();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writePLCBasicData")]
        public async Task<IActionResult> WritePLCBasicData(PLCBasicData plcBasicData)
        {
            var result = await _plcBasicDataService.WritePLCBasicData(plcBasicData);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
