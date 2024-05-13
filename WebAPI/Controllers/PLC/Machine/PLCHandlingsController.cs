using Business.Abstract.PLC.Machine;
using Core.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.PLC.Machine
{
    [Route("api/[controller]")]
    [ApiController]
    public class PLCHandlingsController : ControllerBase
    {
        private IPLCHandlingService _plcHandlingService;
        public PLCHandlingsController(IPLCHandlingService plcHandlingService)
        {
            _plcHandlingService = plcHandlingService;
        }

        [HttpGet("readPositionHandling")]
        public async Task<IActionResult> ReadPositionHandling()
        {
            var dataResult = await _plcHandlingService.ReadPositionHandling();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writePositionHandling")]
        public async Task<IActionResult> WritePositionHandling(decimal positionHandling)
        {
            var result = await _plcHandlingService.WritePositionHandling(positionHandling);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readPositionHandlingLiftOne")]
        public async Task<IActionResult> ReadPositionHandlingLiftOne()
        {
            var dataResult = await _plcHandlingService.ReadPositionHandlingLiftOne();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("WritePositionHandlingLiftOne")]
        public async Task<IActionResult> WritePositionHandlingLiftOne(decimal positionHandlingLiftOne)
        {
            var result = await _plcHandlingService.WritePositionHandlingLiftOne(positionHandlingLiftOne);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readPositionHandlingLiftTwo")]
        public async Task<IActionResult> ReadPositionHandlingLiftTwo()
        {
            var dataResult = await _plcHandlingService.ReadPositionHandlingLiftTwo();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writePositionHandlingLiftTwo")]
        public async Task<IActionResult> WritePositionHandlingLiftTwo(decimal positionHandlingLiftTwo)
        {
            var result = await _plcHandlingService.WritePositionHandlingLiftTwo(positionHandlingLiftTwo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readHandlingPositionOne")]
        public async Task<IActionResult> ReadHandlingPositionOne()
        {
            var dataResult = await _plcHandlingService.ReadHandlingPositionOne();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeHandlingPositionOne")]
        public async Task<IActionResult> WriteHandlingPositionOne(long handlingPositionOne)
        {
            var result = await _plcHandlingService.WriteHandlingPositionOne(handlingPositionOne);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readHandlingPositionTwo")]
        public async Task<IActionResult> ReadHandlingPositionTwo()
        {
            var dataResult = await _plcHandlingService.ReadHandlingPositionTwo();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeHandlingPositionTwo")]
        public async Task<IActionResult> WriteHandlingPositionTwo(long handlingPositionTwo)
        {
            var result = await _plcHandlingService.WriteHandlingPositionTwo(handlingPositionTwo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readHandlingPositionThree")]
        public async Task<IActionResult> ReadHandlingPositionThree()
        {
            var dataResult = await _plcHandlingService.ReadHandlingPositionThree();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeHandlingPositionThree")]
        public async Task<IActionResult> WriteHandlingPositionThree(long handlingPositionThree)
        {
            var result = await _plcHandlingService.WriteHandlingPositionThree(handlingPositionThree);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readHandlingPositionFour")]
        public async Task<IActionResult> ReadHandlingPositionFour()
        {
            var dataResult = await _plcHandlingService.ReadHandlingPositionFour();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeHandlingPositionFour")]
        public async Task<IActionResult> WriteHandlingPositionFour(long handlingPositionFour)
        {
            var result = await _plcHandlingService.WriteHandlingPositionFour(handlingPositionFour);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readHandlingPositionFive")]
        public async Task<IActionResult> ReadHandlingPositionFive()
        {
            var dataResult = await _plcHandlingService.ReadHandlingPositionFive();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeHandlingPositionFive")]
        public async Task<IActionResult> WriteHandlingPositionFive(long handlingPositionFive)
        {
            var result = await _plcHandlingService.WriteHandlingPositionFive(handlingPositionFive);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readLiftOnePositionOne")]
        public async Task<IActionResult> ReadLiftOnePositionOne()
        {
            var dataResult = await _plcHandlingService.ReadLiftOnePositionOne();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeLiftOnePositionOne")]
        public async Task<IActionResult> WriteLiftOnePositionOne(bool liftOnePositionOne)
        {
            var result = await _plcHandlingService.WriteLiftOnePositionOne(liftOnePositionOne);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readLiftOnePositionTwo")]
        public async Task<IActionResult> ReadLiftOnePositionTwo()
        {
            var dataResult = await _plcHandlingService.ReadLiftOnePositionTwo();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeLiftOnePositionTwo")]
        public async Task<IActionResult> WriteLiftOnePositionTwo(bool liftOnePositionTwo)
        {
            var result = await _plcHandlingService.WriteLiftOnePositionTwo(liftOnePositionTwo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readLiftOnePositionThree")]
        public async Task<IActionResult> ReadLiftOnePositionThree()
        {
            var dataResult = await _plcHandlingService.ReadLiftOnePositionThree();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeLiftOnePositionThree")]
        public async Task<IActionResult> WriteLiftOnePositionThree(bool liftOnePositionThree)
        {
            var result = await _plcHandlingService.WriteLiftOnePositionThree(liftOnePositionThree);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readLiftOnePositionFour")]
        public async Task<IActionResult> ReadLiftOnePositionFour()
        {
            var dataResult = await _plcHandlingService.ReadLiftOnePositionFour();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeLiftOnePositionFour")]
        public async Task<IActionResult> WriteLiftOnePositionFour(bool liftOnePositionFour)
        {
            var result = await _plcHandlingService.WriteLiftOnePositionFour(liftOnePositionFour);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readLiftOnePositionFive")]
        public async Task<IActionResult> ReadLiftOnePositionFive()
        {
            var dataResult = await _plcHandlingService.ReadLiftOnePositionFive();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeLiftOnePositionFive")]
        public async Task<IActionResult> WriteLiftOnePositionFive(bool liftOnePositionFive)
        {
            var result = await _plcHandlingService.WriteLiftOnePositionFive(liftOnePositionFive);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpGet("readLiftOnePositionSix")]
        public async Task<IActionResult> ReadLiftOnePositionSix()
        {
            var dataResult = await _plcHandlingService.ReadLiftOnePositionSix();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeLiftOnePositionSix")]
        public async Task<IActionResult> WriteLiftOnePositionSix(bool liftOnePositionSix)
        {
            var result = await _plcHandlingService.WriteLiftOnePositionSix(liftOnePositionSix);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readLiftOnePositionSeven")]
        public async Task<IActionResult> ReadLiftOnePositionSeven()
        {
            var dataResult = await _plcHandlingService.ReadLiftOnePositionSeven();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeLiftOnePositionSeven")]
        public async Task<IActionResult> WriteLiftOnePositionSeven(bool liftOnePositionSeven)
        {
            var result = await _plcHandlingService.WriteLiftOnePositionSeven(liftOnePositionSeven);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readLiftOnePositionEight")]
        public async Task<IActionResult> ReadLiftOnePositionEight()
        {
            var dataResult = await _plcHandlingService.ReadLiftOnePositionEight();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeLiftOnePositionEight")]
        public async Task<IActionResult> WriteLiftOnePositionEight(bool liftOnePositionEight)
        {
            var result = await _plcHandlingService.WriteLiftOnePositionEight(liftOnePositionEight);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readLiftTwoPositionOne")]
        public async Task<IActionResult> ReadLiftTwoPositionOne()
        {
            var dataResult = await _plcHandlingService.ReadLiftTwoPositionOne();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeLiftTwoPositionOne")]
        public async Task<IActionResult> WriteLiftTwoPositionOne(bool liftTwoPositionOne)
        {
            var result = await _plcHandlingService.WriteLiftTwoPositionOne(liftTwoPositionOne);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readLiftTwoPositionTwo")]
        public async Task<IActionResult> ReadLiftTwoPositionTwo()
        {
            var dataResult = await _plcHandlingService.ReadLiftTwoPositionTwo();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeLiftTwoPositionTwo")]
        public async Task<IActionResult> WriteLiftTwoPositionTwo(bool liftTwoPositionTwo)
        {
            var result = await _plcHandlingService.WriteLiftTwoPositionTwo(liftTwoPositionTwo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readLiftTwoPositionThree")]
        public async Task<IActionResult> ReadLiftTwoPositionThree()
        {
            var dataResult = await _plcHandlingService.ReadLiftTwoPositionThree();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeLiftTwoPositionThree")]
        public async Task<IActionResult> WriteLiftTwoPositionThree(bool liftTwoPositionThree)
        {
            var result = await _plcHandlingService.WriteLiftTwoPositionThree(liftTwoPositionThree);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readLiftTwoPositionFour")]
        public async Task<IActionResult> ReadLiftTwoPositionFour()
        {
            var dataResult = await _plcHandlingService.ReadLiftTwoPositionFour();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeLiftTwoPositionFour")]
        public async Task<IActionResult> WriteLiftTwoPositionFour(bool liftTwoPositionFour)
        {
            var result = await _plcHandlingService.WriteLiftTwoPositionFour(liftTwoPositionFour);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readLiftTwoPositionFive")]
        public async Task<IActionResult> ReadLiftTwoPositionFive()
        {
            var dataResult = await _plcHandlingService.ReadLiftTwoPositionFive();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeLiftTwoPositionFive")]
        public async Task<IActionResult> WriteLiftTwoPositionFive(bool liftTwoPositionFive)
        {
            var result = await _plcHandlingService.WriteLiftTwoPositionFive(liftTwoPositionFive);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpGet("readLiftTwoPositionSix")]
        public async Task<IActionResult> ReadLiftTwoPositionSix()
        {
            var dataResult = await _plcHandlingService.ReadLiftTwoPositionSix();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeLiftTwoPositionSix")]
        public async Task<IActionResult> WriteLiftTwoPositionSix(bool liftTwoPositionSix)
        {
            var result = await _plcHandlingService.WriteLiftTwoPositionSix(liftTwoPositionSix);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readLiftTwoPositionSeven")]
        public async Task<IActionResult> ReadLiftTwoPositionSeven()
        {
            var dataResult = await _plcHandlingService.ReadLiftTwoPositionSeven();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeLiftTwoPositionSeven")]
        public async Task<IActionResult> WriteLiftTwoPositionSeven(bool liftTwoPositionSeven)
        {
            var result = await _plcHandlingService.WriteLiftTwoPositionSeven(liftTwoPositionSeven);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readLiftTwoPositionEight")]
        public async Task<IActionResult> ReadLiftTwoPositionEight()
        {
            var dataResult = await _plcHandlingService.ReadLiftTwoPositionEight();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeLiftTwoPositionEight")]
        public async Task<IActionResult> WriteLiftTwoPositionEight(bool liftTwoPositionEight)
        {
            var result = await _plcHandlingService.WriteLiftTwoPositionEight(liftTwoPositionEight);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readLiftOneSetPositionOne")]
        public async Task<IActionResult> ReadLiftOneSetPositionOne()
        {
            var dataResult = await _plcHandlingService.ReadLiftOneSetPositionOne();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeLiftOneSetPositionOne")]
        public async Task<IActionResult> WriteLiftOneSetPositionOne(long liftOneSetPositionOne)
        {
            var result = await _plcHandlingService.WriteLiftOneSetPositionOne(liftOneSetPositionOne);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readLiftOneSetPositionTwo")]
        public async Task<IActionResult> ReadLiftOneSetPositionTwo()
        {
            var dataResult = await _plcHandlingService.ReadLiftOneSetPositionTwo();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeLiftOneSetPositionTwo")]
        public async Task<IActionResult> WriteLiftOneSetPositionTwo(long liftOneSetPositionTwo)
        {
            var result = await _plcHandlingService.WriteLiftOneSetPositionTwo(liftOneSetPositionTwo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readLiftOneSetPositionThree")]
        public async Task<IActionResult> ReadLiftOneSetPositionThree()
        {
            var dataResult = await _plcHandlingService.ReadLiftOneSetPositionThree();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeLiftOneSetPositionThree")]
        public async Task<IActionResult> WriteLiftOneSetPositionThree(long liftOneSetPositionThree)
        {
            var result = await _plcHandlingService.WriteLiftOneSetPositionThree(liftOneSetPositionThree);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readLiftOneSetPositionFour")]
        public async Task<IActionResult> ReadLiftOneSetPositionFour()
        {
            var dataResult = await _plcHandlingService.ReadLiftOneSetPositionFour();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeLiftOneSetPositionFour")]
        public async Task<IActionResult> WriteLiftOneSetPositionFour(long liftOneSetPositionFour)
        {
            var result = await _plcHandlingService.WriteLiftOneSetPositionFour(liftOneSetPositionFour);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readLiftOneSetPositionFive")]
        public async Task<IActionResult> ReadLiftOneSetPositionFive()
        {
            var dataResult = await _plcHandlingService.ReadLiftOneSetPositionFive();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeLiftOneSetPositionFive")]
        public async Task<IActionResult> WriteLiftOneSetPositionFive(long liftOneSetPositionFive)
        {
            var result = await _plcHandlingService.WriteLiftOneSetPositionFive(liftOneSetPositionFive);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readLiftOneSetPositionSix")]
        public async Task<IActionResult> ReadLiftOneSetPositionSix()
        {
            var dataResult = await _plcHandlingService.ReadLiftOneSetPositionSix();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeLiftOneSetPositionSix")]
        public async Task<IActionResult> WriteLiftOneSetPositionSix(long liftOneSetPositionSix)
        {
            var result = await _plcHandlingService.WriteLiftOneSetPositionSix(liftOneSetPositionSix);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readLiftOneSetPositionSeven")]
        public async Task<IActionResult> ReadLiftOneSetPositionSeven()
        {
            var dataResult = await _plcHandlingService.ReadLiftOneSetPositionSeven();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeLiftOneSetPositionSeven")]
        public async Task<IActionResult> WriteLiftOneSetPositionSeven(long liftOneSetPositionSeven)
        {
            var result = await _plcHandlingService.WriteLiftOneSetPositionSeven(liftOneSetPositionSeven);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readLiftOneSetPositionEight")]
        public async Task<IActionResult> ReadLiftOneSetPositionEight()
        {
            var dataResult = await _plcHandlingService.ReadLiftOneSetPositionEight();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeLiftOneSetPositionEight")]
        public async Task<IActionResult> WriteLiftOneSetPositionEight(long liftOneSetPositionEight)
        {
            var result = await _plcHandlingService.WriteLiftOneSetPositionEight(liftOneSetPositionEight);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readLiftTwoSetPositionOne")]
        public async Task<IActionResult> ReadLiftTwoSetPositionOne()
        {
            var dataResult = await _plcHandlingService.ReadLiftTwoSetPositionOne();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeLiftTwoSetPositionOne")]
        public async Task<IActionResult> WriteLiftTwoSetPositionOne(long liftTwoSetPositionOne)
        {
            var result = await _plcHandlingService.WriteLiftTwoSetPositionOne(liftTwoSetPositionOne);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readLiftTwoSetPositionTwo")]
        public async Task<IActionResult> ReadLiftTwoSetPositionTwo()
        {
            var dataResult = await _plcHandlingService.ReadLiftTwoSetPositionTwo();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeLiftTwoSetPositionTwo")]
        public async Task<IActionResult> WriteLiftTwoSetPositionTwo(long liftTwoSetPositionTwo)
        {
            var result = await _plcHandlingService.WriteLiftTwoSetPositionTwo(liftTwoSetPositionTwo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readLiftTwoSetPositionThree")]
        public async Task<IActionResult> ReadLiftTwoSetPositionThree()
        {
            var dataResult = await _plcHandlingService.ReadLiftTwoSetPositionThree();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeLiftTwoSetPositionThree")]
        public async Task<IActionResult> WriteLiftTwoSetPositionThree(long liftTwoSetPositionThree)
        {
            var result = await _plcHandlingService.WriteLiftTwoSetPositionThree(liftTwoSetPositionThree);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readLiftTwoSetPositionFour")]
        public async Task<IActionResult> ReadLiftTwoSetPositionFour()
        {
            var dataResult = await _plcHandlingService.ReadLiftTwoSetPositionFour();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeLiftTwoSetPositionFour")]
        public async Task<IActionResult> WriteLiftTwoSetPositionFour(long liftTwoSetPositionFour)
        {
            var result = await _plcHandlingService.WriteLiftTwoSetPositionFour(liftTwoSetPositionFour);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readLiftTwoSetPositionFive")]
        public async Task<IActionResult> ReadLiftTwoSetPositionFive()
        {
            var dataResult = await _plcHandlingService.ReadLiftTwoSetPositionFive();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeLiftTwoSetPositionFive")]
        public async Task<IActionResult> WriteLiftTwoSetPositionFive(long liftTwoSetPositionFive)
        {
            var result = await _plcHandlingService.WriteLiftTwoSetPositionFive(liftTwoSetPositionFive);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readLiftTwoSetPositionSix")]
        public async Task<IActionResult> ReadLiftTwoSetPositionSix()
        {
            var dataResult = await _plcHandlingService.ReadLiftTwoSetPositionSix();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeLiftTwoSetPositionSix")]
        public async Task<IActionResult> WriteLiftTwoSetPositionSix(long liftTwoSetPositionSix)
        {
            var result = await _plcHandlingService.WriteLiftTwoSetPositionSix(liftTwoSetPositionSix);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readLiftTwoSetPositionSeven")]
        public async Task<IActionResult> ReadLiftTwoSetPositionSeven()
        {
            var dataResult = await _plcHandlingService.ReadLiftTwoSetPositionSeven();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeLiftTwoSetPositionSeven")]
        public async Task<IActionResult> WriteLiftTwoSetPositionSeven(long liftTwoSetPositionSeven)
        {
            var result = await _plcHandlingService.WriteLiftTwoSetPositionSeven(liftTwoSetPositionSeven);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("readLiftTwoSetPositionEight")]
        public async Task<IActionResult> ReadLiftTwoSetPositionEight()
        {
            var dataResult = await _plcHandlingService.ReadLiftTwoSetPositionEight();
            if (dataResult.Success)
            {
                return Ok(dataResult);
            }
            return BadRequest(dataResult);
        }

        [HttpPost("writeLiftTwoSetPositionEight")]
        public async Task<IActionResult> WriteLiftTwoSetPositionEight(long liftTwoSetPositionEight)
        {
            var result = await _plcHandlingService.WriteLiftTwoSetPositionEight(liftTwoSetPositionEight);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

