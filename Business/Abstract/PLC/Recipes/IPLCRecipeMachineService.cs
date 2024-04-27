using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.PLC.Recipes
{
    public interface IPLCRecipeMachineService
    {
        public Task<IDataResult<int>> ReadMachineSpeedSet();
        public Task<IResult> WriteMachineSpeedSet(int machineSpeedSet);

    }
}
