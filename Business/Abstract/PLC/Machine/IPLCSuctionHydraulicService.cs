using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Business.Abstract.PLC.Machine
{
    public  interface IPLCSuctionHydraulicService
    {
        public Task<IDataResult<bool>> ReadStartCycleCentralLubrication();
        public Task<IResult> WriteStartCycleCentralLubrication(bool startCycleCentralLubrication);

        public Task<IDataResult<bool>> ReadStartCycleCentralLubricationIsRunning();
        public Task<IResult> WriteStartCycleCentralLubricationIsRunning(bool startCycleCentralLubricationIsRunning);

        public Task<IDataResult<short>> ReadHydraulicTemperature();
        public Task<IResult> WriteHydraulicTemperature(short hydraulicTemperature);

        public Task<IDataResult<short>> ReadHydraulicLevel();
        public Task<IResult> WriteHydraulicLevel(short hydraulicLevel);

        public Task<IDataResult<short>> ReadHydraulicPressure();
        public Task<IResult> WriteHydraulicPressure(short hydraulicPressure);

        public Task<IDataResult<short>> ReadSuctionRPMSet();
        public Task<IResult> WriteSuctionRPMSet(short suctionRPMSet);

        public Task<IDataResult<short>> ReadSuctionRPMActuel();
        public Task<IResult> WriteSuctionRPMActuel(short suctionRPMActuel);

        public Task<IDataResult<short>> ReadSuctionSpeedForMaximumRPM();
        public Task<IResult> WriteSuctionSpeedForMaximumRPM(short suctionSpeedForMaximumRPM);

        public Task<IDataResult<short>> ReadMachineSpeedActuel();
        public Task<IResult> WriteMachineSpeedActuel(short machineSpeedActuel);

        public Task<IDataResult<bool>> ReadBoosterIsRaedy();
        public Task<IResult> WriteBoosterIsRaedy(bool boosterIsRaedy);

        public Task<IDataResult<bool>> ReadBoosterIsRunning();
        public Task<IResult> WriteBoosterIsRunning(bool boosterIsRunning);

        public Task<IDataResult<bool>> ReadSuctionExternFunctionSetOne();
        public Task<IResult> WriteSuctionExternFunctionSetOne(bool suctionExternFunctionSetOne);

        public Task<IDataResult<bool>> ReadSuctionExternFunctionSetTwo();
        public Task<IResult> WriteSuctionExternFunctionSetTwo(bool suctionExternFunctionSetTwo);

        public Task<IDataResult<bool>> ReadSuctionExternFunctionSetThree();
        public Task<IResult> WriteSuctionExternFunctionSetThree(bool suctionExternFunctionSetThree);

        public Task<IDataResult<bool>> ReadSuctionExternFunctionReady();
        public Task<IResult> WriteSuctionExternFunctionReady(bool suctionExternFunctionReady);

        public Task<IDataResult<bool>> ReadSuctionExternFunctionIsRunning();
        public Task<IResult> WriteSuctionExternFunctionIsRunning(bool suctionExternFunctionIsRunning);

        public Task<IDataResult<bool>> ReadSuctionExternFunctionIsFault();
        public Task<IResult> WriteSuctionExternFunctionIsFault(bool suctionExternFunctionIsFault);

        public Task<IDataResult<short>> ReadSuctionLeakAirFlapOneSet();
        public Task<IResult> WriteSuctionLeakAirFlapOneSet(short suctionLeakAirFlapOneSet);

        public Task<IDataResult<short>> ReadSuctionLeakAirFlapOneActuel();
        public Task<IResult> WriteSuctionLeakAirFlapOneActuel(short suctionLeakAirFlapOneActuel);

        public Task<IDataResult<short>> ReadSuctionLeakAirFlapTwoSet();
        public Task<IResult> WriteSuctionLeakAirFlapTwoSet(short suctionLeakAirFlapTwoActuel);

        public Task<IDataResult<short>> ReadSuctionLeakAirFlapTwoActuel();
        public Task<IResult> WriteSuctionLeakAirFlapTwoActuel(short suctionLeakAirFlapTwoActuel);

    }
}