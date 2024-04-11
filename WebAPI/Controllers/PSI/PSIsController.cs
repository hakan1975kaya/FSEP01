using Business.Abstract.General.General;
using Business.Abstract.PSI;
using Core.Entities.Concrete;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.PSI.Telegrams;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> SetProcessDataPES2L2(PSIProcessDataPES2L2 processDataPES2L2)
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
