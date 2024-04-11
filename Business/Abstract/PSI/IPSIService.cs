using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.PSI.Telegrams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.PSI
{
    public interface IPSIService
    {
        public Task<IResult> SetProcessDataPES2L2(ProcessDataPES2L2 processDataPES2L2);
    }
}
