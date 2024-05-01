using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.PLC.Machine
{
    public interface IPLCGeneralService
    {
        public Task<IDataResult<string>> ReadRecipeNumber();
        public Task<IResult> WriteRecipeNumber(string recipeNumber);

        public Task<IDataResult<int>> ReadMachineSpeedActuel();
        public Task<IResult> WriteMachineSpeedActuel(int machineSpeedActuel);

        public Task<IDataResult<int>> ReadMachineSpeedMaximum();
        public Task<IResult> WriteMachineSpeedMaximum(int machineSpeedMaximum);
    }
}
