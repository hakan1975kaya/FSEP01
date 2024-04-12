using Business.Abstract.PSI;
using Microsoft.AspNetCore.Mvc;
using PSI.Dtos.Telegrams;

namespace WebAPI.Controllers.General.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class PSIsController : ControllerBase
    {
        private IPSIService _psiService;
        public PSIsController(IPSIService psiService)
        {
            _psiService = psiService;
        }

        [HttpPost("setProcessDataPES2L2")]
        public async Task<IActionResult> SetProcessDataPES2L2(ProcessDataPES2L2 processDataPES2L2)
        {
            var result = await _psiService.SetProcessDataPES2L2(processDataPES2L2);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

     

    }
}
