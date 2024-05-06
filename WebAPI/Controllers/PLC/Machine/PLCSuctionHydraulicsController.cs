using Business.Abstract.PLC.Machine;
using Core.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace WebAPI.Controllers.PLC.Machine
{
    [Route("api/[controller]")]
    [ApiController]
    public class PLCSuctionHydraulicsController : ControllerBase
    {
        private IPLCSuctionHydraulicService _plcSuctionHydraulicService;
        public PLCSuctionHydraulicsController(IPLCSuctionHydraulicService plcSuctionHydraulicService)
        {
            _plcSuctionHydraulicService = plcSuctionHydraulicService;  
        }

        [HttpGet("readStartCycleCentralLubrication")]
        public async Task<IActionResult> ReadStartCycleCentralLubrication()
        {
            var dataResult = await _plcSuctionHydraulicService.ReadStartCycleCentralLubrication();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeStartCycleCentralLubrication")]
        public async Task<IActionResult> WriteStartCycleCentralLubrication(bool startCycleCentralLubrication)
        {
            var result = await _plcSuctionHydraulicService.WriteStartCycleCentralLubrication(startCycleCentralLubrication);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readStartCycleCentralLubricationIsRunning")]
        public async Task<IActionResult> ReadStartCycleCentralLubricationIsRunning()
        {
            var dataResult = await _plcSuctionHydraulicService.ReadStartCycleCentralLubricationIsRunning();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeStartCycleCentralLubricationIsRunning")]
        public async Task<IActionResult> WriteStartCycleCentralLubricationIsRunning(bool startCycleCentralLubricationIsRunning)
        {
            var result = await _plcSuctionHydraulicService.WriteStartCycleCentralLubricationIsRunning(startCycleCentralLubricationIsRunning);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readHydraulicTemperature")]
        public async Task<IActionResult> ReadHydraulicTemperature()
        {
            var dataResult = await _plcSuctionHydraulicService.ReadHydraulicTemperature();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeHydraulicTemperature")]
        public async Task<IActionResult> WriteHydraulicTemperature(short hydraulicTemperature)
        {
            var result = await _plcSuctionHydraulicService.WriteHydraulicTemperature(hydraulicTemperature);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readHydraulicLevel")]
        public async Task<IActionResult> ReadHydraulicLevel()
        {
            var dataResult = await _plcSuctionHydraulicService.ReadHydraulicLevel();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeHydraulicLevel")]
        public async Task<IActionResult> WriteHydraulicLevel(short hydraulicLevel)
        {
            var result = await _plcSuctionHydraulicService.WriteHydraulicLevel(hydraulicLevel);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readHydraulicPressure")]
        public async Task<IActionResult> ReadHydraulicPressure()
        {
            var dataResult = await _plcSuctionHydraulicService.ReadHydraulicPressure();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeHydraulicPressure")]
        public async Task<IActionResult> WriteHydraulicPressure(short hydraulicPressure)
        {
            var result = await _plcSuctionHydraulicService.WriteHydraulicPressure(hydraulicPressure);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readSuctionRPMSet")]
        public async Task<IActionResult> ReadSuctionRPMSet()
        {
            var dataResult = await _plcSuctionHydraulicService.ReadSuctionRPMSet();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeSuctionRPMSet")]
        public async Task<IActionResult> WriteSuctionRPMSet(short suctionRPMSet)
        {
            var result = await _plcSuctionHydraulicService.WriteSuctionRPMSet(suctionRPMSet);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readSuctionRPMActuel")]
        public async Task<IActionResult> ReadSuctionRPMActuel()
        {
            var dataResult = await _plcSuctionHydraulicService.ReadSuctionRPMActuel();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeSuctionRPMActuel")]
        public async Task<IActionResult> WriteSuctionRPMActuel(short suctionRPMActuel)
        {
            var result = await _plcSuctionHydraulicService.WriteSuctionRPMActuel(suctionRPMActuel);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readSuctionSpeedForMaximumRPM")]
        public async Task<IActionResult> ReadSuctionSpeedForMaximumRPM()
        {
            var dataResult = await _plcSuctionHydraulicService.ReadSuctionSpeedForMaximumRPM();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeSuctionSpeedForMaximumRPM")]
        public async Task<IActionResult> WriteSuctionSpeedForMaximumRPM(short suctionSpeedForMaximumRPM)
        {
            var result = await _plcSuctionHydraulicService.WriteSuctionSpeedForMaximumRPM(suctionSpeedForMaximumRPM);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readMachineSpeedActuel")]
        public async Task<IActionResult> ReadMachineSpeedActuel()
        {
            var dataResult = await _plcSuctionHydraulicService.ReadMachineSpeedActuel();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeMachineSpeedActuel")]
        public async Task<IActionResult> WriteMachineSpeedActuel(short machineSpeedActuel)
        {
            var result = await _plcSuctionHydraulicService.WriteMachineSpeedActuel(machineSpeedActuel);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readBoosterIsRaedy")]
        public async Task<IActionResult> ReadBoosterIsRaedy()
        {
            var dataResult = await _plcSuctionHydraulicService.ReadBoosterIsRaedy();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeBoosterIsRaedy")]
        public async Task<IActionResult> WriteBoosterIsRaedy(bool boosterIsRaedy)
        {
            var result = await _plcSuctionHydraulicService.WriteBoosterIsRaedy(boosterIsRaedy);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readBoosterIsRunning")]
        public async Task<IActionResult> ReadBoosterIsRunning()
        {
            var dataResult = await _plcSuctionHydraulicService.ReadBoosterIsRunning();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeBoosterIsRunning")]
        public async Task<IActionResult> WriteBoosterIsRunning(bool boosterIsRunning)
        {
            var result = await _plcSuctionHydraulicService.WriteBoosterIsRunning(boosterIsRunning);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readSuctionExternFunctionSetOne")]
        public async Task<IActionResult> ReadSuctionExternFunctionSetOne()
        {
            var dataResult = await _plcSuctionHydraulicService.ReadSuctionExternFunctionSetOne();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeSuctionExternFunctionSetOne")]
        public async Task<IActionResult> WriteSuctionExternFunctionSetOne(bool suctionExternFunctionSetOne)
        {
            var result = await _plcSuctionHydraulicService.WriteBoosterIsRunning(suctionExternFunctionSetOne);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readSuctionExternFunctionSetTwo")]
        public async Task<IActionResult> ReadSuctionExternFunctionSetTwo()
        {
            var dataResult = await _plcSuctionHydraulicService.ReadSuctionExternFunctionSetTwo();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeSuctionExternFunctionSetTwo")]
        public async Task<IActionResult> WriteSuctionExternFunctionSetTwo(bool suctionExternFunctionSetTwo)
        {
            var result = await _plcSuctionHydraulicService.WriteSuctionExternFunctionSetTwo(suctionExternFunctionSetTwo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readSuctionExternFunctionSetThree")]
        public async Task<IActionResult> ReadSuctionExternFunctionSetThree()
        {
            var dataResult = await _plcSuctionHydraulicService.ReadSuctionExternFunctionSetThree();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeSuctionExternFunctionSetThree")]
        public async Task<IActionResult> WriteSuctionExternFunctionSetThree(bool suctionExternFunctionSetThree)
        {
            var result = await _plcSuctionHydraulicService.WriteSuctionExternFunctionSetThree(suctionExternFunctionSetThree);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readSuctionExternFunctionReady")]
        public async Task<IActionResult> ReadSuctionExternFunctionReady()
        {
            var dataResult = await _plcSuctionHydraulicService.ReadSuctionExternFunctionReady();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeSuctionExternFunctionReady")]
        public async Task<IActionResult> WriteSuctionExternFunctionReady(bool suctionExternFunctionReady)
        {
            var result = await _plcSuctionHydraulicService.WriteSuctionExternFunctionReady(suctionExternFunctionReady);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readSuctionExternFunctionIsRunning")]
        public async Task<IActionResult> ReadSuctionExternFunctionIsRunning()
        {
            var dataResult = await _plcSuctionHydraulicService.ReadSuctionExternFunctionIsRunning();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeSuctionExternFunctionIsRunning")]
        public async Task<IActionResult> WriteSuctionExternFunctionIsRunning(bool suctionExternFunctionIsRunning)
        {
            var result = await _plcSuctionHydraulicService.WriteSuctionExternFunctionIsRunning(suctionExternFunctionIsRunning);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readSuctionExternFunctionIsFault")]
        public async Task<IActionResult> ReadSuctionExternFunctionIsFault()
        {
            var dataResult = await _plcSuctionHydraulicService.ReadSuctionExternFunctionIsFault();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeSuctionExternFunctionIsFault")]
        public async Task<IActionResult> WriteSuctionExternFunctionIsFault(bool suctionExternFunctionIsFault)
        {
            var result = await _plcSuctionHydraulicService.WriteSuctionExternFunctionIsFault(suctionExternFunctionIsFault);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readSuctionLeakAirFlapOneSet")]
        public async Task<IActionResult> ReadSuctionLeakAirFlapOneSet()
        {
            var dataResult = await _plcSuctionHydraulicService.ReadSuctionLeakAirFlapOneSet();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeSuctionLeakAirFlapOneSet")]
        public async Task<IActionResult> WriteSuctionLeakAirFlapOneSet(short suctionLeakAirFlapOneSet)
        {
            var result = await _plcSuctionHydraulicService.WriteSuctionLeakAirFlapOneSet(suctionLeakAirFlapOneSet);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readSuctionLeakAirFlapOneActuel")]
        public async Task<IActionResult> ReadSuctionLeakAirFlapOneActuel()
        {
            var dataResult = await _plcSuctionHydraulicService.ReadSuctionLeakAirFlapOneActuel();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeSuctionLeakAirFlapOneActuel")]
        public async Task<IActionResult> WriteSuctionLeakAirFlapOneActuel(short suctionLeakAirFlapOneActuel)
        {
            var result = await _plcSuctionHydraulicService.WriteSuctionLeakAirFlapOneActuel(suctionLeakAirFlapOneActuel);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readSuctionLeakAirFlapTwoSet")]
        public async Task<IActionResult> ReadSuctionLeakAirFlapTwoSet()
        {
            var dataResult = await _plcSuctionHydraulicService.ReadSuctionLeakAirFlapTwoSet();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeSuctionLeakAirFlapTwoSet")]
        public async Task<IActionResult> WriteSuctionLeakAirFlapTwoSet(short suctionLeakAirFlapTwoSet)
        {
            var result = await _plcSuctionHydraulicService.WriteSuctionLeakAirFlapTwoSet(suctionLeakAirFlapTwoSet);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readSuctionLeakAirFlapTwoActuel")]
        public async Task<IActionResult> ReadSuctionLeakAirFlapTwoActuel()
        {
            var dataResult = await _plcSuctionHydraulicService.ReadSuctionLeakAirFlapTwoActuel();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeSuctionLeakAirFlapTwoActuel")]
        public async Task<IActionResult> WriteSuctionLeakAirFlapTwoActuel(short suctionLeakAirFlapTwoActuel)
        {
            var result = await _plcSuctionHydraulicService.WriteSuctionLeakAirFlapTwoActuel(suctionLeakAirFlapTwoActuel);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

