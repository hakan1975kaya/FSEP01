using Core.Utilities.Results.Abstract;
using PSI.Dtos.Telegrams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Abstract
{
    public interface IPSIDal
    {
        public Task<IResult> SetProcessDataPES2L2(ProcessDataPES2L2 processDataPES2L2);
    }
}
