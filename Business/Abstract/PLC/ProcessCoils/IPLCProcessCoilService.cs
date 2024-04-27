using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.PLC.ProcessCoils
{
    public interface IPLCProcessCoilService
    {
        public Task<IDataResult<int>> ReadMachineSpeedActuel();
        public Task<IResult> WriteMachineSpeedActuel(int machineSpeedActuel);
    }
}
