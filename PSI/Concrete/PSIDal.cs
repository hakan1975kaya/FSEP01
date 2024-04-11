using Core.Utilities.Results.Abstract;
using PSI.Abstract;
using PSI.Dtos.Telegrams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Concrete
{
    public class PSIDal : IPSIDal
    {
        public Task<IResult> SetProcessDataPES2L2(ProcessDataPES2L2 processDataPES2L2)
        {
            throw new NotImplementedException();
        }
    }
}
