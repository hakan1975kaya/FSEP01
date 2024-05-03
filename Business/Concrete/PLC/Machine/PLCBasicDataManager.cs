using Business.Abstract.PLC.Machine;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using PLC.Abstract;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.PLC.Machine
{
    public class PLCBasicDataManager : IPLCBasicDataService
    {
        private IPLCDal _plcDal;
        public PLCBasicDataManager(IPLCDal plcDal)
        {
            _plcDal = plcDal;
        }

        public async Task<IDataResult<decimal>> ReadRewinderOneDiameterLayRoll()//Name:Rew1DiaLayRoll,Adress:DB 91 DBD 368,Data Type:DInt
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 91, 368, VarType.DInt, 1));
        }
        public async Task<IResult> WriteRewinderOneDiameterLayRoll(decimal rewinderOneDiameterLayRoll)//Name:Rew1DiaLayRoll,Adress:DB 91 DBD 368,Data Type:DInt
        {
            _plcDal.Write(DataType.DataBlock, 91, 368, rewinderOneDiameterLayRoll);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderOneDiameterContactRoll()//Name:Rew1DiaContRoll,Adress:DB 91 DBD 338,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 91, 368, VarType.DInt, 1));
        }
        public async Task<IResult> WriteRewinderOneDiameterContactRoll(decimal rewinderOneDiameterContactRoll)//Name:Rew1DiaContRoll,Adress:DB 91 DBD 338,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 338, rewinderOneDiameterContactRoll);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderTwoDiameterContactRoll()//Name:Rew2DiaContRoll,Adress:DB 91 DBD 438,Data Type:DInt
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 91, 438, VarType.DInt, 1));
        }
        public async Task<IResult> WriteRewinderTwoDiameterContactRoll(decimal rewinderTwoDiameterContactRoll)//Name:Rew2DiaContRoll,Adress:DB 91 DBD 438,Data Type:DInt
        {
            _plcDal.Write(DataType.DataBlock, 91, 438, rewinderTwoDiameterContactRoll);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderTwoDiameterSupportRoll()//Name:Rew2DiaSupRoll,Adress:DB 91 DBD 468,Data Type:DInt
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 91, 468, VarType.DInt, 1));
        }
        public async Task<IResult> WriteRewinderTwoDiameterSupportRoll(decimal rewinderTwoDiameterSupportRoll)//Name:Rew2DiaSupRoll,Adress:DB 91 DBD 468,Data Type:DInt
        {
            _plcDal.Write(DataType.DataBlock, 91, 468, rewinderTwoDiameterSupportRoll);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadMaterialSpecGravity()//Name:MaterialSpecGravity,Adress:DB 91 DBW 38,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 91, 38, VarType.Int, 1));
        }
        public async Task<IResult> WriteMaterialSpecGravity(decimal materialSpecGravity)//Name:MaterialSpecGravity,Adress:DB 91 DBW 38,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 38, materialSpecGravity);
            return new SuccessResult();
        }

        public async Task<IDataResult<int>> ReadUnwinderOneMaterialWidth()//Name:Unw1MaterialWidth,Adress:DB 91 DBW 110,Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 91, 110, VarType.Int, 1));
        }
        public async Task<IResult> WriteUnwinderOneMaterialWidth(int unwinderOneMaterialWidth)//Name:Unw1MaterialWidth,Adress:DB 91 DBW 110,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 110, unwinderOneMaterialWidth);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadMaterialThickness()//Name:MaterialThickness,Adress:DB 91 DBW 36,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 91, 36, VarType.Int, 1));
        }
        public async Task<IResult> WriteMaterialThickness(decimal materialThickness)//Name:MaterialThickness,Adress:DB 91 DBW 36,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 36, materialThickness);
            return new SuccessResult();
        }

        //Calculated
        public async Task<IDataResult<decimal>> ReadMaterialThicknessCalculatedValueActuel()//HMI:Only Read,Name:MaterialThicknessCalc,Adress:DB 90 DBW 36,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 36, VarType.Int, 1));
        }
        public async Task<IResult> WriteMaterialThicknessCalculatedValueActuel(decimal materialThicknessCalculatedValueActuel)//Name:MaterialThicknessCalc,Adress:DB 90 DBW 36,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 36, materialThicknessCalculatedValueActuel);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadMaterialThicknessCalculatedValueMinimum()//Name:MaterialThicknessMin,Adress:DB 90 DBW 124,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 124, VarType.Int, 1));
        }
        public async Task<IResult> WritenMaterialThicknessCalculatedValueMinimuml(decimal materialThicknessCalculatedValueMinimuml)//Name:MaterialThicknessMin,Adress:DB 90 DBW 124,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 124, materialThicknessCalculatedValueMinimuml);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadMaterialThicknessCalculatedValueMaximum()//Name:MaterialThicknessMax,Adress:DB 90 DBW 126,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 126, VarType.Int, 1));
        }
        public async Task<IResult> WriteMaterialThicknessCalculatedValueMaximum(decimal materialThicknessCalculatedValueMaximum)
        {
            _plcDal.Write(DataType.DataBlock, 90, 126, materialThicknessCalculatedValueMaximum);
            return new SuccessResult();
        }

        public async Task<IDataResult<short>> ReadMachineWeldingSpeedSet()//Name:MachineWeldingSpeedSet_0,Adress:DB 91 DBW 80,Data Type:Int
        {
            return new SuccessDataResult<short>((short)_plcDal.Read(DataType.DataBlock, 91, 80, VarType.Int, 1));
        }
        public async Task<IResult> WriteMachineWeldingSpeedSet(short machineWeldingSpeedSet)//Name:MachineWeldingSpeedSet_0,Adress:DB 91 DBW 80,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 80, machineWeldingSpeedSet);
            return new SuccessResult();
        }

        public async Task<IDataResult<short>> ReadMachineWeldingAmplitudeSet()//Name:MachineWeldingAmplitudeSet,Adress:DB 91 DBW 82,Data Type:Int
        {
            return new SuccessDataResult<short>((short)_plcDal.Read(DataType.DataBlock, 91, 82, VarType.Int, 1));
        }
        public async Task<IResult> WriteMachineWeldingAmplitudeSet(short machineWeldingAmplitudeSet)//Name:MachineWeldingAmplitudeSet,Adress:DB 91 DBW 82,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 82, machineWeldingAmplitudeSet);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<decimal>> ReadMachineWeldingPowerActuel()//HMI:Read Only, Name:MachineWeldingPowerAct,Adress:DB 90 DBW 82,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 82, VarType.Int, 1));
        }
        public async Task<IResult> WriteMachineWeldingPowerActuel(decimal machineWeldingPowerActuel)//HMI:Read Only, Name:MachineWeldingPowerAct,Adress:DB 90 DBW 82,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 82, machineWeldingPowerActuel);
            return new SuccessResult();
        }

        public async Task<IDataResult<short>> ReadMachineTimeAcceleration()//Name:MachineTimeAccel,Addres:DB 91 DBW 8
        {

            return new SuccessDataResult<short>((short)_plcDal.Read(DataType.DataBlock, 91, 8, VarType.Int, 1));
        }
        public async Task<IResult> WriteMachineTimeAcceleration(short machineTimeAcceleration)//Name:MachineTimeAccel,Addres:DB 91 DBW 8
        {
            _plcDal.Write(DataType.DataBlock, 91, 8, machineTimeAcceleration);
            return new SuccessResult();
        }

        public async Task<IDataResult<short>> ReadMachineTimeDecelaration()//Name:MachineTimeDecel,Addres:DB 91 DBW 10
        {
            return new SuccessDataResult<short>((short)_plcDal.Read(DataType.DataBlock, 91, 10, VarType.Int, 1));
        }
        public async Task<IResult> WriteMachineTimeDecelaration(short machineTimeDecelaration)//Name:MachineTimeDecel,Addres:DB 91 DBW 10
        {
            _plcDal.Write(DataType.DataBlock, 91, 10, machineTimeDecelaration);
            return new SuccessResult();
        }

        public async Task<IDataResult<short>> ReadMachineTimeFastStop()//Name:MachineTimeFastStop,Addres:DB 91 DBW 12
        {
            return new SuccessDataResult<short>((short)_plcDal.Read(DataType.DataBlock, 91, 12, VarType.Int, 1));
        }
        public async Task<IResult> WriteMachineTimeFastStop(short machineTimeFastStop)//Name:MachineTimeFastStop,Addres:DB 91 DBW 12
        {
            _plcDal.Write(DataType.DataBlock, 91, 12, machineTimeFastStop);
            return new SuccessResult();
        }

        public async Task<IDataResult<short>> ReadMachineSpeedJog()//Name:MachineSpeedJog,Addres:DB 91 DBW 4
        {
            return new SuccessDataResult<short>((short)_plcDal.Read(DataType.DataBlock, 91, 4, VarType.Int, 1));
        }
        public async Task<IResult> WriteMachineSpeedJog(short machineSpeedJog)//Name:MachineSpeedJog,Addres:DB 91 DBW 4
        {
            _plcDal.Write(DataType.DataBlock, 91, 4, machineSpeedJog);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadMachineLengthTotal()//Name:MachineLengthTotal,Adress:DB 90 DBD 16,Data Type:DInt
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 90, 16, VarType.DInt, 1));
        }
        public async Task<IResult> WriteMachineLengthTotal(long machineLengthTotal)//Name:MachineLengthTotal,Adress:DB 90 DBD 16,Data Type:DInt
        {
            _plcDal.Write(DataType.DataBlock, 90, 16, machineLengthTotal);
            return new SuccessResult();
        }

    }
}
