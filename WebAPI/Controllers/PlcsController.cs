using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlcsController : ControllerBase
    {
        private IPlcService _plcService;
        public PlcsController(IPlcService plcService)
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
