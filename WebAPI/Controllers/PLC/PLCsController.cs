using Business.Abstract.PLC;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.PLC
{
    [Route("api/[controller]")]
    [ApiController]
    public class PLCsController : ControllerBase
    {
        private IPLCService _plcService;
        public PLCsController(IPLCService plcService)
        {

            _plcService = plcService;

        }

        [HttpPost("motorStart")]
        public async Task<IActionResult> MotorStart()
        {
            var result = await _plcService.MotorStart();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("motorStop")]
        public async Task<IActionResult> MotorStop()
        {
            var result = await _plcService.MotorStop();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
