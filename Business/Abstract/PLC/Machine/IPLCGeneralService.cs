using Core.Utilities.Results.Abstract;
using Entities.Concrete.Enums.PLC.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.PLC.Machine
{
    public interface IPLCGeneralService
    {
        public Task<IDataResult<string>> ReadRecipeNameLast();
        public Task<IResult> WriteRecipeNameLast(string recipeNameLast);

        public Task<IDataResult<ServiceEnum>> ReadMachineMode();
        public Task<IResult> WriteMachineMode(ServiceEnum machineMode);

        public Task<IDataResult<MachineEnum>> ReadMachineState();
        public Task<IResult> WriteMachineState(MachineEnum machineState);
        
        public Task<IDataResult<short>> ReadMachineSpeedSet();
        public Task<IResult> WriteMachineSpeedSet(short machineSpeedSet);

        public Task<IDataResult<short>> ReadMachineSpeedActuel();
        public Task<IResult> WriteMachineSpeedActuel(short machineSpeedActuel);

        public Task<IDataResult<short>> ReadMachineSpeedMaximum();
        public Task<IResult> WriteMachineSpeedMaximum(short machineSpeedMaximum);


    }
}
