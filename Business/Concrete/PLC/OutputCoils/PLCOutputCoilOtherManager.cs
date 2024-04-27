using Business.Abstract.PLC.OutputCoils;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using PLC.Abstract;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.PLC.OutputCoils
{
    public class PLCOutputCoilOtherManager : IPLCOutputCoilOtherService
    {
        private IPLCDal _plcDal;
        public PLCOutputCoilOtherManager(IPLCDal plcDal)
        {
            _plcDal = plcDal;
        }
        public async Task<IDataResult<decimal>> ReadRollWidthOneFour()//Name:Rew1DiaLayRoll,Adress:DB 91 DBD 368,Data Type:DInt
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 91, 368, VarType.DInt, 1));
        }
        public async Task<IResult> WriteRollWidthOneFour(decimal rollWidthOneFour)//Name:Rew1DiaLayRoll,Adress:DB 91 DBD 368,Data Type:DInt
        {
            _plcDal.Write(DataType.DataBlock, 91, 368, rollWidthOneFour);
            return new SuccessResult();
        }
        public async Task<IDataResult<decimal>> ReadRollWidthOneTwo()//Name:Rew1DiaContRoll,Adress:DB 91 DBD 338,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 91, 368, VarType.DInt, 1));
        }
        public async Task<IResult> WriteRollWidthOneTwo(decimal rollWidthOneTwo)//Name:Rew1DiaContRoll,Adress:DB 91 DBD 338,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 338, rollWidthOneTwo);
            return new SuccessResult();
        }
        public async Task<IDataResult<decimal>> ReadRollWidthOneThree()//Name:Rew2DiaContRoll,Adress:DB 91 DBD 438,Data Type:DInt
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 91, 438, VarType.DInt, 1));
        }

        public async Task<IResult> WriteRollWidthOneThree(decimal rollWidthOneThree)//Name:Rew2DiaContRoll,Adress:DB 91 DBD 438,Data Type:DInt
        {
            _plcDal.Write(DataType.DataBlock, 91, 438, rollWidthOneThree);
            return new SuccessResult();
        }
        public async Task<IDataResult<decimal>> ReadRollWidthOneFive()//Name:Rew2DiaSupRoll,Adress:DB 91 DBD 468,Data Type:DInt
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 91, 468, VarType.DInt, 1));
        }

        public async Task<IResult> WriteRollWidthOneFive(decimal rollWidthOneFive)//Name:Rew2DiaSupRoll,Adress:DB 91 DBD 468,Data Type:DInt
        {
            _plcDal.Write(DataType.DataBlock, 91, 468, rollWidthOneFive);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadMaterialSpecGravity()//Name:MaterialSpecGravity,Adress:DB 91 DBW 38,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 91, 38, VarType.Int ,1));
        }

        public async Task<IResult> WriteMaterialSpecGravity(decimal materialSpecGravit)//Name:MaterialSpecGravity,Adress:DB 91 DBW 38,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 38, materialSpecGravit);
            return new SuccessResult();
        }
        public async Task<IDataResult<int>> ReadUnwinderLength()//Name:Unw1MaterialWidth,Adress:DB 91 DBW 110,Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 91, 110, VarType.Int, 1));
        }

        public async Task<IResult> WriteUnwinderLength(int unwinderLength)//Name:Unw1MaterialWidth,Adress:DB 91 DBW 110,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 110, unwinderLength);
            return new SuccessResult();
        }
        public async Task<IDataResult<decimal>> ReadUnwinderThickness()//Name:MaterialThickness,Adress:DB 91 DBW 36,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 91, 36, VarType.Int, 1));
        }

        public async Task<IResult> WriteUnwinderThickness(decimal unwinderThickness)//Name:MaterialThickness,Adress:DB 91 DBW 36,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 36, unwinderThickness);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadUnwinderThicknessCalculatedValueActuel()//Name:MaterialThicknessCalc,Adress:DB 90 DBW 36,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 36, VarType.Int, 1));
        }
        public async  Task<IResult> WriteUnwinderThicknessCalculatedValueActuel(decimal unwinderThicknessCalculatedValueActuel)//Name:MaterialThicknessCalc,Adress:DB 90 DBW 36,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 36, unwinderThicknessCalculatedValueActuel);
            return new SuccessResult();
        }
        public async Task<IDataResult<decimal>> ReadUnwinderThicknessCalculatedValueMinimuml()//Name:MaterialThicknessMin,Adress:DB 90 DBW 124,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 124, VarType.Int, 1));
        }
        public async Task<IResult> WritenUnwinderThicknessCalculatedValueMinimuml(decimal unwinderThicknessCalculatedValueMinimuml)//Name:MaterialThicknessMin,Adress:DB 90 DBW 124,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 124, unwinderThicknessCalculatedValueMinimuml);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadUnwinderThicknessCalculatedValueMaximum()//Name:MaterialThicknessMax,Adress:DB 90 DBW 126,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 126, VarType.Int, 1));
        }
        public async Task<IResult> WriteUnwinderThicknessCalculatedValueMaximum(decimal unwinderThicknessCalculatedValueMaximum)
        {
            _plcDal.Write(DataType.DataBlock, 90, 126, unwinderThicknessCalculatedValueMaximum);
            return new SuccessResult();
        }
        public async Task<IDataResult<int>> ReadMachineWeldingSpeedSet()//Name:MachineWeldingSpeedSet_0,Adress:DB 91 DBW 80,Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 91, 80, VarType.Int, 1));
        }
        public async Task<IResult> WriteMachineWeldingSpeedSet(int machineWeldingSpeedSet)//Name:MachineWeldingSpeedSet_0,Adress:DB 91 DBW 80,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 80, machineWeldingSpeedSet);
            return new SuccessResult();
        }
        public async Task<IDataResult<int>> ReadMachineWeldingAmplitudeSet()//Name:MachineWeldingAmplitudeSet,Adress:DB 91 DBW 82,Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 91, 82, VarType.Int, 1));
        }
        public async Task<IResult> WriteMachineWeldingAmplitudeSet(int machineWeldingAmplitudeSet)//Name:MachineWeldingAmplitudeSet,Adress:DB 91 DBW 82,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 82, machineWeldingAmplitudeSet);
            return new SuccessResult();
        }
        public async Task<IDataResult<int>> ReadMachineWeldingPowerAct()//Name:MachineWeldingPowerAct,Adress:DB 90 DBW 82,Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 90, 82, VarType.Int, 1));
        }

        public async Task<IResult> WriteMachineWeldingPowerAct(int machineWeldingPowerAct)//Name:MachineWeldingPowerAct,Adress:DB 90 DBW 82,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 82, machineWeldingPowerAct);
            return new SuccessResult();
        }
        public async Task<IDataResult<long>> ReadMachineLengthTotal()//Name:MachineLengthTotal,Adress:DB 90 DBD 16,Data Type:DInt
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 90, 16, VarType.DInt, 1));
        }

        public async Task<IResult> WriteMachineLengthTotal(long machineLengthTotal)//Name:MachineLengthTotal,Adress:DB 90 DBD 16,Data Type:DInt
        {
            _plcDal.Write(DataType.DataBlock, 90, 16, machineLengthTotal);
            return new SuccessResult();
        }
        public async Task<IDataResult<int>> ReadMaterialThickness()//Name:MaterialThickness,Adress:DB 91 DBW 36,Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 91,36, VarType.Int, 1));
        }
        public async Task<IResult> WriteMaterialThickness(int materialThickness)//Name:MaterialThickness,Adress:DB 91 DBW 36,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 36, materialThickness);
            return new SuccessResult();
        }
        public async Task<IDataResult<int>> ReadRewinderOneDiameterActuel()//Name:Rew1DiaAct,Adress:DB 90 DBW 300,Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 90, 300, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderOneDiameterActuel(int rewinderOneDiameterActuel)//Name:Rew1DiaAct,Adress:DB 90 DBW 300,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 300, rewinderOneDiameterActuel);
            return new SuccessResult();
        }
        public async Task<IDataResult<long>> ReadRewinderOneLengthActuel()//Name:Rew1LengthAct,Adress:DB 90 DBD 306,Data Type:Int
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 90, 306, VarType.DInt, 1));
        }
        public async Task<IResult> WriteRewinderOneLengthActuel(long rewinderOneLengthActuel)//Name:Rew1LengthAct,Adress:DB 90 DBD 306,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 306, rewinderOneLengthActuel);
            return new SuccessResult();
        }
        public async Task<IDataResult<int>> ReadRewinderTwoDiameterActuel()//Name:Rew2DiaAct,Adress:DB 90 DBW 400,Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 90, 400, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderTwoDiameterActuel(int rewinderTwoDiameterActuel)//Name:Rew2DiaAct,Adress:DB 90 DBW 400,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 400, rewinderTwoDiameterActuel);
            return new SuccessResult();
        }
        public async Task<IDataResult<long>> ReadRewinderTwoLengthActuel()//Name:Rew2LengthAct,Adress:DB 90 DBD 406,Data Type:DInt
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 90, 406, VarType.DInt, 1));
        }
        public async Task<IResult> WriteRewinderTwoLengthActuel(long rewinderTwoLengthActuel)//Name:Rew2LengthAct,Adress:DB 90 DBD 406,Data Type:DInt
        {
            _plcDal.Write(DataType.DataBlock, 90, 406, rewinderTwoLengthActuel);
            return new SuccessResult();
        }
        public async Task<IDataResult<int>> ReadRewinderOneDensityGraph()//Name:Rew1DensityGraph,Adress:DB 43 DBW 48,Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 43, 48, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderOneDensityGraph(int rewinderOneDensityGraph)//Name:Rew1DensityGraph,Adress:DB 43 DBW 48,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 43, 48, rewinderOneDensityGraph);
            return new SuccessResult();
        }
        public async Task<IDataResult<int>> ReadMachineSpeedActArchive()//Name:MachineSpeedActArchive,Adress:DB 304 DBW 20,Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 304, 20, VarType.Int, 1));
        }
        public async Task<IResult> WriteMachineSpeedActArchive(int rewinderOneDensityGraph)//Name:MachineSpeedActArchive,Adress:DB 304 DBW 20,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 304, 20, rewinderOneDensityGraph);
            return new SuccessResult();
        }
        public async Task<IDataResult<int>> ReadRewinderTwoDensityGraph()//Name:Rew2DensityGraph,Adress:DB 53 DBW 48,Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 53, 48, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderTwoDensityGraph(int rewinderTwoDensityGraph)//Name:Rew2DensityGraph,Adress:DB 53 DBW 48,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 53, 48, rewinderTwoDensityGraph);
            return new SuccessResult();
        }
        public async Task<IDataResult<long>> ReadPositionHandling()//Name:Pos_Handling,Adress:DB 233 DBD 44,Data Type:DInt
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 233, 44, VarType.DInt, 1));
        }
        public async Task<IResult> WritePositionHandling(long positionHandling)//Name:Pos_Handling,Adress:DB 233 DBD 44,Data Type:DInt
        {
            _plcDal.Write(DataType.DataBlock, 233, 44, positionHandling);
            return new SuccessResult();
        }
        public async Task<IDataResult<long>> ReadPositionHandlingLiftOne()//Name:Pos_Handling_Lift_1,Adress:DB 230 DBD 44,Data Type:DInt
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 230, 44, VarType.DInt, 1));
        }
        public async Task<IResult> WritePositionHandlingLiftOne(long positionHandlingOne)//Name:Pos_Handling_Lift_1,Adress:DB 230 DBD 44,Data Type:DInt
        {
            _plcDal.Write(DataType.DataBlock, 230, 44, positionHandlingOne);
            return new SuccessResult();
        }
        public async Task<IDataResult<long>> ReadPositionHandlingLiftTwo()//Name:Pos_Handling_Lift_2,Adress:DB 231 DBD 44,Data Type:IDnt
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 231, 44, VarType.DInt, 1));
        }
        public async Task<IResult> WritePositionHandlingLiftTwo(long positionHandlingLiftTwo)//Name:Pos_Handling_Lift_2,Adress:DB 231 DBD 44,Data Type:DInt
        {
            _plcDal.Write(DataType.DataBlock, 231, 44, positionHandlingLiftTwo);
            return new SuccessResult();
        }
        public async Task<IDataResult<decimal>> ReadHandlingPositionOne()//Name:Handling_Set_Pos1,Adress:DB 233 DBD 68,Data Type:Real
        {
            return new SuccessDataResult<decimal>((decimal) _plcDal.Read(DataType.DataBlock, 233, 68, VarType.Real, 1));
        }
        public async Task<IResult> WriteHandlingPositionOne(decimal handlingPositionOne)//Name:Handling_Set_Pos1,Adress:DB 233 DBD 68,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 233, 68, handlingPositionOne);
            return new SuccessResult();
        }
        public async Task<IDataResult<decimal>> ReadHandlingPositionTwo()//Name:Handling_Set_Pos2,Adress:DB 233 DBD 72,Data Type:Real
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 233, 72, VarType.Real, 1));
        }
        public async Task<IResult> WriteHandlingPositionTwo(decimal handlingPositionTwo)//Name:Handling_Set_Pos2,Adress:DB 233 DBD 72,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 233, 72, handlingPositionTwo);
            return new SuccessResult();
        }
        public async Task<IDataResult<decimal>> ReadHandlingPositionThree()//Name:Handling_Set_Pos4,Adress:DB 233 DBD 76,Data Type:Real
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 233, 76, VarType.Real, 1));
        }
        public async Task<IResult> WriteHandlingPositionThree(decimal handlingPositionThree)//Name:Handling_Set_Pos4,Adress:DB 233 DBD 76,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 233, 76, handlingPositionThree);
            return new SuccessResult();
        }
        public async Task<IDataResult<decimal>> ReadHandlingPositionFour()//Name:Handling_Set_Pos4,Adress:DB 233 DBD 80,Data Type:Real
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 233, 80, VarType.Real, 1));
        }
        public async Task<IResult> WriteHandlingPositionFour(decimal handlingPositionFour)//Name:Handling_Set_Pos4,Adress:DB 233 DBD 80,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 233, 80, handlingPositionFour);
            return new SuccessResult();
        }
        public async Task<IDataResult<decimal>> ReadHandlingPositionFive()//Name:Handling_Set_Pos5,Adress:DB 233 DBD 84,Data Type:Real
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 233, 84, VarType.Real, 1));
        }
        public async Task<IResult> WriteHandlingPositionFive(decimal handlingPositionFive)//Name:Handling_Set_Pos5,Adress:DB 233 DBD 84,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 233, 84, handlingPositionFive);
            return new SuccessResult();
        }
        public async Task<IDataResult<bool>> ReadLiftOnePositionOne()//Name:Lift1_Pos1,Adress:M 256.0,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0,256, VarType.Bit, 1,0));
        }
        public async Task<IResult> WriteLiftOnePositionOne(bool liftOnePositionOne)//Name:Lift1_Pos1,Adress:M 256.0,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory,0, 256, liftOnePositionOne,0);
            return new SuccessResult();
        }

        public async Task<IDataResult<bool>> ReadLiftOnePositionTwo()//Name:Lift1_Pos2,Adress:M 256.1,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 256, VarType.Bit, 1,1));
        }
        public async Task<IResult> WriteLiftOnePositionTwo(bool liftOnePositionTwo)//Name:Lift1_Pos2,Adress:M 256.1,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 256, liftOnePositionTwo,1);
            return new SuccessResult();
        }

        public async Task<IDataResult<bool>> ReadLiftOnePositionThree()//Name:Lift1_Pos3,Adress:M 256.2,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 256, VarType.Bit, 1,2));
        }
        public async Task<IResult> WriteLiftOnePositionThree(bool liftOnePositionThree)//Name:Lift1_Pos3,Adress:M 256.2,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 256, liftOnePositionThree,2);
            return new SuccessResult();
        }

        public async Task<IDataResult<bool>> ReadLiftOnePositionFour()//Name:Lift1_Pos4,Adress:M 256.3,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 256, VarType.Bit, 1,3));
        }
        public async Task<IResult> WriteLiftOnePositionFour(bool liftOnePositionFour)//Name:Lift1_Pos4,Adress:M 256.3,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 256, liftOnePositionFour,3);
            return new SuccessResult();
        }

        public async Task<IDataResult<bool>> ReadLiftOnePositionFive()//Name:Lift1_Pos5,Adress:M 256.4,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 256, VarType.Bit, 1,4));
        }
        public async Task<IResult> WriteLiftOnePositionFive(bool liftOnePositionFive)//Name:Lift1_Pos5,Adress:M 256.4,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 256, liftOnePositionFive,4);
            return new SuccessResult();
        }

        public async Task<IDataResult<bool>> ReadLiftOnePositionSix()//Name:Lift1_Pos6,Adress:M 256.5,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 256, VarType.Bit, 1,5));
        }
        public async Task<IResult> WriteLiftOnePositionSix(bool liftOnePositionSix)//Name:Lift1_Pos6,Adress:M 256.5,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 256, liftOnePositionSix,5);
            return new SuccessResult();
        }

        public async Task<IDataResult<bool>> ReadLiftOnePositionSeven()//Name:Lift1_Pos7,Adress:M 256.6,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 256, VarType.Bit, 1,6));
        }
        public async Task<IResult> WriteLiftOnePositionSeven(bool liftOnePositionSeven)//Name:Lift1_Pos7,Adress:M 256.6,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 256, liftOnePositionSeven,6);
            return new SuccessResult();
        }

        public async Task<IDataResult<bool>> ReadLiftOnePositionEight()//Name:Lift1_Pos8,Adress:M 256.7,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 256, VarType.Bit, 1,7));
        }
        public async Task<IResult> WriteLiftOnePositionEight(bool liftOnePositionEight)//Name:Lift1_Pos8,Adress:M 256.7,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 256, liftOnePositionEight,7);
            return new SuccessResult();
        }


        public async Task<IDataResult<bool>> ReadLiftTwoPositionOne()//Name:Lift1_Pos1,Adress:M 266.0,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 266, VarType.Bit, 1, 0));
        }
        public async Task<IResult> WriteLiftTwoPositionOne(bool LiftTwoPositionOne)//Name:Lift1_Pos1,Adress:M 266.0,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 266, LiftTwoPositionOne, 0);
            return new SuccessResult();
        }

        public async Task<IDataResult<bool>> ReadLiftTwoPositionTwo()//Name:Lift1_Pos2,Adress:M 266.1,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 266, VarType.Bit, 1, 1));
        }
        public async Task<IResult> WriteLiftTwoPositionTwo(bool LiftTwoPositionTwo)//Name:Lift1_Pos2,Adress:M 266.1,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 266, LiftTwoPositionTwo, 1);
            return new SuccessResult();
        }

        public async Task<IDataResult<bool>> ReadLiftTwoPositionThree()//Name:Lift1_Pos3,Adress:M 266.2,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 266, VarType.Bit, 1, 2));
        }
        public async Task<IResult> WriteLiftTwoPositionThree(bool LiftTwoPositionThree)//Name:Lift1_Pos3,Adress:M 266.2,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 266, LiftTwoPositionThree, 2);
            return new SuccessResult();
        }

        public async Task<IDataResult<bool>> ReadLiftTwoPositionFour()//Name:Lift1_Pos4,Adress:M 266.3,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 266, VarType.Bit, 1, 3));
        }
        public async Task<IResult> WriteLiftTwoPositionFour(bool LiftTwoPositionFour)//Name:Lift1_Pos4,Adress:M 266.3,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 266, LiftTwoPositionFour, 3);
            return new SuccessResult();
        }

        public async Task<IDataResult<bool>> ReadLiftTwoPositionFive()//Name:Lift1_Pos5,Adress:M 266.4,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 266, VarType.Bit, 1, 4));
        }
        public async Task<IResult> WriteLiftTwoPositionFive(bool LiftTwoPositionFive)//Name:Lift1_Pos5,Adress:M 266.4,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 266, LiftTwoPositionFive, 4);
            return new SuccessResult();
        }

        public async Task<IDataResult<bool>> ReadLiftTwoPositionSix()//Name:Lift1_Pos6,Adress:M 266.5,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 266, VarType.Bit, 1, 5));
        }
        public async Task<IResult> WriteLiftTwoPositionSix(bool LiftTwoPositionSix)//Name:Lift1_Pos6,Adress:M 266.5,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 266, LiftTwoPositionSix, 5);
            return new SuccessResult();
        }

        public async Task<IDataResult<bool>> ReadLiftTwoPositionSeven()//Name:Lift1_Pos7,Adress:M 266.6,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 266, VarType.Bit, 1, 6));
        }
        public async Task<IResult> WriteLiftTwoPositionSeven(bool LiftTwoPositionSeven)//Name:Lift1_Pos7,Adress:M 266.6,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 266, LiftTwoPositionSeven, 6);
            return new SuccessResult();
        }

        public async Task<IDataResult<bool>> ReadLiftTwoPositionEight()//Name:Lift1_Pos8,Adress:M 266.7,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 266, VarType.Bit, 1, 7));
        }
        public async Task<IResult> WriteLiftTwoPositionEight(bool LiftTwoPositionEight)//Name:Lift1_Pos8,Adress:M 266.7,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 266, LiftTwoPositionEight, 7);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadLiftOneSetPositionOne()//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 68,Data Type:Real
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 230, 68, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftOneSetPositionOne(decimal liftoneSetPositionOne)//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 68,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 230, 68, liftoneSetPositionOne);
            return new SuccessResult();
        }
        public async Task<IDataResult<decimal>> ReadLiftOneSetPositionTwo()//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 72,Data Type:Real
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 230, 72, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftOneSetPositionTwo(decimal liftoneSetPositionTwo)//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 72,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 230, 72, liftoneSetPositionTwo);
            return new SuccessResult();
        }
        public async Task<IDataResult<decimal>> ReadLiftOneSetPositionThree()//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 76,Data Type:Real
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 230, 76, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftOneSetPositionThree(decimal liftoneSetPositionThree)//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 76,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 230, 76, liftoneSetPositionThree);
            return new SuccessResult();
        }
        public async Task<IDataResult<decimal>> ReadLiftOneSetPositionFour()//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 80,Data Type:Real
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 230, 80, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftOneSetPositionFour(decimal liftoneSetPositionFour)//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 80,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 230, 80, liftoneSetPositionFour);
            return new SuccessResult();
        }
        public async Task<IDataResult<decimal>> ReadLiftOneSetPositionFive()//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 84,Data Type:Real
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 230, 84, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftOneSetPositionFive(decimal liftoneSetPositionFive)//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 84,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 230, 84, liftoneSetPositionFive);
            return new SuccessResult();
        }
        public async Task<IDataResult<decimal>> ReadLiftOneSetPositionSix()//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 88,Data Type:Real
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 230, 88, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftOneSetPositionSix(decimal liftoneSetPositionSix)//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 88,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 230, 88, liftoneSetPositionSix);
            return new SuccessResult();
        }
        public async Task<IDataResult<decimal>> ReadLiftOneSetPositionSeven()//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 92,Data Type:Real
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 230, 92, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftOneSetPositionSeven(decimal liftoneSetPositionSeven)//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 92,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 230, 92, liftoneSetPositionSeven);
            return new SuccessResult();
        }
        public async Task<IDataResult<decimal>> ReadLiftOneSetPositionEight()//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 96,Data Type:Real
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 230, 96, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftOneSetPositionEight(decimal liftoneSetPositionEight)//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 96,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 230, 96, liftoneSetPositionEight);
            return new SuccessResult();
        }


    }
}
