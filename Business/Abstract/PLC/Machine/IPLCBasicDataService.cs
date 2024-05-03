using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.PLC.Machine
{
    public interface IPLCBasicDataService
    {
        public Task<IDataResult<decimal>> ReadRewinderOneDiameterLayRoll();
        public Task<IResult> WriteRewinderOneDiameterLayRoll(decimal rewinderOneDiameterLayRoll);

        public Task<IDataResult<decimal>> ReadRewinderOneDiameterContactRoll();
        public Task<IResult> WriteRewinderOneDiameterContactRoll(decimal rewinderOneDiameterContactRoll);

        public Task<IDataResult<decimal>> ReadRewinderTwoDiameterContactRoll();
        public Task<IResult> WriteRewinderTwoDiameterContactRoll(decimal rewinderTwoDiameterContactRoll);

        public Task<IDataResult<decimal>> ReadRewinderTwoDiameterSupportRoll();
        public Task<IResult> WriteRewinderTwoDiameterSupportRoll(decimal rewinderTwoDiameterSupportRoll);

        public Task<IDataResult<decimal>> ReadMaterialSpecGravity();
        public Task<IResult> WriteMaterialSpecGravity(decimal materialSpecGravity);

        public Task<IDataResult<int>> ReadUnwinderOneMaterialWidth();
        public Task<IResult> WriteUnwinderOneMaterialWidth(int unwinderOneMaterialWidth);

        public Task<IDataResult<decimal>> ReadMaterialThickness();
        public Task<IResult> WriteMaterialThickness(decimal materialThickness);

        public Task<IDataResult<decimal>> ReadMaterialThicknessCalculatedValueActuel();
        public Task<IResult> WriteMaterialThicknessCalculatedValueActuel(decimal materialThicknessCalculatedValueActuel);

        public Task<IDataResult<decimal>> ReadMaterialThicknessCalculatedValueMinimum();
        public Task<IResult> WritenMaterialThicknessCalculatedValueMinimuml(decimal materialThicknessCalculatedValueMinimuml);

        public Task<IDataResult<decimal>> ReadMaterialThicknessCalculatedValueMaximum();
        public Task<IResult> WriteMaterialThicknessCalculatedValueMaximum(decimal materialThicknessCalculatedValueMaximum);

        public Task<IDataResult<short>> ReadMachineWeldingSpeedSet();
        public Task<IResult> WriteMachineWeldingSpeedSet(short machineWeldingSpeedSet);

        public Task<IDataResult<short>> ReadMachineWeldingAmplitudeSet();
        public Task<IResult> WriteMachineWeldingAmplitudeSet(short machineWeldingAmplitudeSet);

        public Task<IDataResult<decimal>> ReadMachineWeldingPowerActuel();
        public Task<IResult> WriteMachineWeldingPowerActuel(decimal machineWeldingPowerActuel);

        public Task<IDataResult<short>> ReadMachineTimeAcceleration();
        public Task<IResult> WriteMachineTimeAcceleration(short machineTimeAcceleration);

        public Task<IDataResult<short>> ReadMachineTimeDecelaration();
        public Task<IResult> WriteMachineTimeDecelaration(short machineTimeDecelaration);

        public Task<IDataResult<short>> ReadMachineTimeFastStop();
        public Task<IResult> WriteMachineTimeFastStop(short machineTimeFastStop);

        public Task<IDataResult<short>> ReadMachineSpeedJog();
        public Task<IResult> WriteMachineSpeedJog(short machineSpeedJog);

        public Task<IDataResult<long>> ReadMachineLengthTotal();
        public Task<IResult> WriteMachineLengthTotal(long machineLengthTotal);

    }
}
