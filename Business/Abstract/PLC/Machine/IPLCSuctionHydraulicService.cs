using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Business.Abstract.PLC.Machine
{
    public interface IPLCSuctionHydraulicService
    {
        public Task<IDataResult<int>> ReadMachineConditionFlagOne();
        public Task<IResult> WriteMachineConditionFlagOne(int machineConditionFlagOne);

        public Task<IDataResult<int>> ReadHydraulicTemperature();
        public Task<IResult> WriteHydraulicTemperature(int hydraulicTemperature);

        public Task<IDataResult<int>> ReadHydraulicLevel();
        public Task<IResult> WriteHydraulicLevel(int hydraulicLevel);

        public Task<IDataResult<int>> ReadHydraulicPressure();
        public Task<IResult> WriteHydraulicPressure(int hydraulicPressure);

        public Task<IDataResult<int>> ReadSuctionRPMSet();
        public Task<IResult> WriteSuctionRPMSet(int suctionRPMSet);

        public Task<IDataResult<int>> ReadSuctionRPMActuel();
        public Task<IResult> WriteSuctionRPMActuel(int suctionRPMActuel);

        public Task<IDataResult<int>> ReadSuctionSpeedForMaximumRPM();
        public Task<IResult> WriteSuctionSpeedForMaximumRPM(int suctionSpeedForMaximumRPM);

        public Task<IDataResult<int>> ReadMachineSpeedActuel();
        public Task<IResult> WriteMachineSpeedActuel(int machineSpeedAct);

        public Task<IDataResult<int>> ReadSuctionExternFunctionFlag();
        public Task<IResult> WriteSuctionExternFunctionFlag(int suctionExternFunctionFlag);

        public Task<IDataResult<int>> ReadSuctionLeakAirFlapOneSet();
        public Task<IResult> WriteSuctionLeakAirFlapOneSet(int suctionLeakAirFlapOneSet);

        public Task<IDataResult<int>> ReadSuctionLeakAirFlapOneActuel();
        public Task<IResult> WriteSuctionLeakAirFlapOneActuel(int suctionLeakAirFlapOneActuel);

        public Task<IDataResult<int>> ReadSuctionLeakAirFlapTwoSet();
        public Task<IResult> WriteSuctionLeakAirFlapTwoSet(int suctionLeakAirFlapOneActuel);

        public Task<IDataResult<int>> ReadSuctionLeakAirFlapTwoActuel();
        public Task<IResult> WriteSuctionLeakAirFlapTwoActuel(int suctionLeakAirFlapOneActuel);

    }
}
