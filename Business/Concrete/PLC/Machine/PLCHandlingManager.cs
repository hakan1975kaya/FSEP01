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
    public class PLCHandlingManager : IPLCHandlingService
    {
        private IPLCDal _plcDal;
        public PLCHandlingManager(IPLCDal plcDal)
        {
            _plcDal = plcDal;
        }

        public async Task<IDataResult<decimal>> ReadPositionHandling()//Name:Pos_Handling,Adress:DB 233 DBD 44,Data Type:DInt
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 233, 44, VarType.DInt, 1));
        }
        public async Task<IResult> WritePositionHandling(decimal positionHandling)//Name:Pos_Handling,Adress:DB 233 DBD 44,Data Type:DInt
        {
            _plcDal.Write(DataType.DataBlock, 233, 44, positionHandling);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadPositionHandlingLiftOne()//Name:Pos_Handling_Lift_1,Adress:DB 230 DBD 44,Data Type:DInt
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 230, 44, VarType.DInt, 1));
        }
        public async Task<IResult> WritePositionHandlingLiftOne(decimal positionHandlingOne)//Name:Pos_Handling_Lift_1,Adress:DB 230 DBD 44,Data Type:DInt
        {
            _plcDal.Write(DataType.DataBlock, 230, 44, positionHandlingOne);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadPositionHandlingLiftTwo()//Name:Pos_Handling_Lift_2,Adress:DB 231 DBD 44,Data Type:IDnt
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 231, 44, VarType.DInt, 1));
        }
        public async Task<IResult> WritePositionHandlingLiftTwo(decimal positionHandlingLiftTwo)//Name:Pos_Handling_Lift_2,Adress:DB 231 DBD 44,Data Type:DInt
        {
            _plcDal.Write(DataType.DataBlock, 231, 44, positionHandlingLiftTwo);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadHandlingPositionOne()//Name:Handling_Set_Pos1,Adress:DB 233 DBD 68,Data Type:Real
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 233, 68, VarType.Real, 1));
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
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 256, VarType.Bit, 1, 0));
        }
        public async Task<IResult> WriteLiftOnePositionOne(bool liftOnePositionOne)//Name:Lift1_Pos1,Adress:M 256.0,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 256, liftOnePositionOne, 0);
            return new SuccessResult();
        }

        public async Task<IDataResult<bool>> ReadLiftOnePositionTwo()//Name:Lift1_Pos2,Adress:M 256.1,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 256, VarType.Bit, 1, 1));
        }
        public async Task<IResult> WriteLiftOnePositionTwo(bool liftOnePositionTwo)//Name:Lift1_Pos2,Adress:M 256.1,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 256, liftOnePositionTwo, 1);
            return new SuccessResult();
        }

        public async Task<IDataResult<bool>> ReadLiftOnePositionThree()//Name:Lift1_Pos3,Adress:M 256.2,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 256, VarType.Bit, 1, 2));
        }
        public async Task<IResult> WriteLiftOnePositionThree(bool liftOnePositionThree)//Name:Lift1_Pos3,Adress:M 256.2,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 256, liftOnePositionThree, 2);
            return new SuccessResult();
        }

        public async Task<IDataResult<bool>> ReadLiftOnePositionFour()//Name:Lift1_Pos4,Adress:M 256.3,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 256, VarType.Bit, 1, 3));
        }
        public async Task<IResult> WriteLiftOnePositionFour(bool liftOnePositionFour)//Name:Lift1_Pos4,Adress:M 256.3,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 256, liftOnePositionFour, 3);
            return new SuccessResult();
        }

        public async Task<IDataResult<bool>> ReadLiftOnePositionFive()//Name:Lift1_Pos5,Adress:M 256.4,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 256, VarType.Bit, 1, 4));
        }
        public async Task<IResult> WriteLiftOnePositionFive(bool liftOnePositionFive)//Name:Lift1_Pos5,Adress:M 256.4,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 256, liftOnePositionFive, 4);
            return new SuccessResult();
        }

        public async Task<IDataResult<bool>> ReadLiftOnePositionSix()//Name:Lift1_Pos6,Adress:M 256.5,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 256, VarType.Bit, 1, 5));
        }
        public async Task<IResult> WriteLiftOnePositionSix(bool liftOnePositionSix)//Name:Lift1_Pos6,Adress:M 256.5,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 256, liftOnePositionSix, 5);
            return new SuccessResult();
        }

        public async Task<IDataResult<bool>> ReadLiftOnePositionSeven()//Name:Lift1_Pos7,Adress:M 256.6,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 256, VarType.Bit, 1, 6));
        }
        public async Task<IResult> WriteLiftOnePositionSeven(bool liftOnePositionSeven)//Name:Lift1_Pos7,Adress:M 256.6,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 256, liftOnePositionSeven, 6);
            return new SuccessResult();
        }

        public async Task<IDataResult<bool>> ReadLiftOnePositionEight()//Name:Lift1_Pos8,Adress:M 256.7,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 256, VarType.Bit, 1, 7));
        }
        public async Task<IResult> WriteLiftOnePositionEight(bool liftOnePositionEight)//Name:Lift1_Pos8,Adress:M 256.7,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 256, liftOnePositionEight, 7);
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

        public async Task<IDataResult<decimal>> ReadLiftTwoSetPositionOne()//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 68,Data Type:Real
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 231, 68, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftTwoSetPositionOne(decimal LiftTwoSetPositionOne)//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 68,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 231, 68, LiftTwoSetPositionOne);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadLiftTwoSetPositionTwo()//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 72,Data Type:Real
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 231, 72, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftTwoSetPositionTwo(decimal LiftTwoSetPositionTwo)//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 72,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 231, 72, LiftTwoSetPositionTwo);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadLiftTwoSetPositionThree()//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 76,Data Type:Real
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 231, 76, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftTwoSetPositionThree(decimal LiftTwoSetPositionThree)//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 76,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 231, 76, LiftTwoSetPositionThree);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadLiftTwoSetPositionFour()//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 80,Data Type:Real
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 231, 80, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftTwoSetPositionFour(decimal LiftTwoSetPositionFour)//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 80,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 231, 80, LiftTwoSetPositionFour);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadLiftTwoSetPositionFive()//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 84,Data Type:Real
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 231, 84, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftTwoSetPositionFive(decimal LiftTwoSetPositionFive)//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 84,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 231, 84, LiftTwoSetPositionFive);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadLiftTwoSetPositionSix()//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 88,Data Type:Real
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 231, 88, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftTwoSetPositionSix(decimal LiftTwoSetPositionSix)//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 88,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 231, 88, LiftTwoSetPositionSix);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadLiftTwoSetPositionSeven()//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 92,Data Type:Real
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 231, 92, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftTwoSetPositionSeven(decimal LiftTwoSetPositionSeven)//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 92,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 231, 92, LiftTwoSetPositionSeven);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadLiftTwoSetPositionEight()//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 96,Data Type:Real
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 231, 96, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftTwoSetPositionEight(decimal LiftTwoSetPositionEight)//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 96,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 231, 96, LiftTwoSetPositionEight);
            return new SuccessResult();
        }



    }
}
