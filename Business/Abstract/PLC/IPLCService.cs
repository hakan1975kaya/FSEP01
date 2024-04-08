using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.PLC
{
    public interface IPLCService
    {
        public Task<IResult> MotorStart();
        public Task<IResult> MotorStop();

    }
}
