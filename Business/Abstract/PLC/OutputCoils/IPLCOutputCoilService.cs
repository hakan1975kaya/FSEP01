using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.PLC.OutputCoils
{
    public interface IPLCOutputCoilService
    {
        public Task<IDataResult<int>> ReadMachineSpeedMaximum();
        public Task<IResult> WriteMachineSpeedMaximum(int machineSpeedMaximum);
    }
}
