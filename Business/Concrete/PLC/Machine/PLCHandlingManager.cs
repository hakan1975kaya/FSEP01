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

        //Read Only
        public async Task<IDataResult<decimal>> ReadPositionHandling()//Name:Pos_Handling,Adress:DB 233 DBD 44,Data Type:DInt
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 233, 44, VarType.DInt, 1));
        }
        public async Task<IResult> WritePositionHandling(decimal positionHandling)//Name:Pos_Handling,Adress:DB 233 DBD 44,Data Type:DInt
        {
            _plcDal.Write(DataType.DataBlock, 233, 44, positionHandling);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<decimal>> ReadPositionHandlingLiftOne()//Name:Pos_Handling_Lift_1,Adress:DB 230 DBD 44,Data Type:DInt
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 230, 44, VarType.DInt, 1));
        }
        public async Task<IResult> WritePositionHandlingLiftOne(decimal positionHandlingOne)//Name:Pos_Handling_Lift_1,Adress:DB 230 DBD 44,Data Type:DInt
        {
            _plcDal.Write(DataType.DataBlock, 230, 44, positionHandlingOne);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<decimal>> ReadPositionHandlingLiftTwo()//Name:Pos_Handling_Lift_2,Adress:DB 231 DBD 44,Data Type:IDnt
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 231, 44, VarType.DInt, 1));
        }
        public async Task<IResult> WritePositionHandlingLiftTwo(decimal positionHandlingLiftTwo)//Name:Pos_Handling_Lift_2,Adress:DB 231 DBD 44,Data Type:DInt
        {
            _plcDal.Write(DataType.DataBlock, 231, 44, positionHandlingLiftTwo);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadHandlingPositionOne()//Name:Handling_Set_Pos1,Adress:DB 233 DBD 68,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 233, 68, VarType.Real, 1));
        }
        public async Task<IResult> WriteHandlingPositionOne(long handlingPositionOne)//Name:Handling_Set_Pos1,Adress:DB 233 DBD 68,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 233, 68, handlingPositionOne);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadHandlingPositionTwo()//Name:Handling_Set_Pos2,Adress:DB 233 DBD 72,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 233, 72, VarType.Real, 1));
        }
        public async Task<IResult> WriteHandlingPositionTwo(long handlingPositionTwo)//Name:Handling_Set_Pos2,Adress:DB 233 DBD 72,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 233, 72, handlingPositionTwo);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadHandlingPositionThree()//Name:Handling_Set_Pos4,Adress:DB 233 DBD 76,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 233, 76, VarType.Real, 1));
        }
        public async Task<IResult> WriteHandlingPositionThree(long handlingPositionThree)//Name:Handling_Set_Pos4,Adress:DB 233 DBD 76,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 233, 76, handlingPositionThree);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadHandlingPositionFour()//Name:Handling_Set_Pos4,Adress:DB 233 DBD 80,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 233, 80, VarType.Real, 1));
        }
        public async Task<IResult> WriteHandlingPositionFour(long handlingPositionFour)//Name:Handling_Set_Pos4,Adress:DB 233 DBD 80,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 233, 80, handlingPositionFour);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadHandlingPositionFive()//Name:Handling_Set_Pos5,Adress:DB 233 DBD 84,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 233, 84, VarType.Real, 1));
        }
        public async Task<IResult> WriteHandlingPositionFive(long handlingPositionFive)//Name:Handling_Set_Pos5,Adress:DB 233 DBD 84,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 233, 84, handlingPositionFive);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<bool>> ReadLiftOnePositionOne()//Name:Lift1_Pos1,Adress:M 256.0,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 256, VarType.Bit, 1, 0));
        }
        public async Task<IResult> WriteLiftOnePositionOne(bool liftOnePositionOne)//Name:Lift1_Pos1,Adress:M 256.0,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 256, liftOnePositionOne, 0);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<bool>> ReadLiftOnePositionTwo()//Name:Lift1_Pos2,Adress:M 256.1,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 256, VarType.Bit, 1, 1));
        }
        public async Task<IResult> WriteLiftOnePositionTwo(bool liftOnePositionTwo)//Name:Lift1_Pos2,Adress:M 256.1,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 256, liftOnePositionTwo, 1);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<bool>> ReadLiftOnePositionThree()//Name:Lift1_Pos3,Adress:M 256.2,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 256, VarType.Bit, 1, 2));
        }
        public async Task<IResult> WriteLiftOnePositionThree(bool liftOnePositionThree)//Name:Lift1_Pos3,Adress:M 256.2,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 256, liftOnePositionThree, 2);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<bool>> ReadLiftOnePositionFour()//Name:Lift1_Pos4,Adress:M 256.3,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 256, VarType.Bit, 1, 3));
        }
        public async Task<IResult> WriteLiftOnePositionFour(bool liftOnePositionFour)//Name:Lift1_Pos4,Adress:M 256.3,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 256, liftOnePositionFour, 3);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<bool>> ReadLiftOnePositionFive()//Name:Lift1_Pos5,Adress:M 256.4,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 256, VarType.Bit, 1, 4));
        }
        public async Task<IResult> WriteLiftOnePositionFive(bool liftOnePositionFive)//Name:Lift1_Pos5,Adress:M 256.4,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 256, liftOnePositionFive, 4);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<bool>> ReadLiftOnePositionSix()//Name:Lift1_Pos6,Adress:M 256.5,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 256, VarType.Bit, 1, 5));
        }
        public async Task<IResult> WriteLiftOnePositionSix(bool liftOnePositionSix)//Name:Lift1_Pos6,Adress:M 256.5,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 256, liftOnePositionSix, 5);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<bool>> ReadLiftOnePositionSeven()//Name:Lift1_Pos7,Adress:M 256.6,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 256, VarType.Bit, 1, 6));
        }
        public async Task<IResult> WriteLiftOnePositionSeven(bool liftOnePositionSeven)//Name:Lift1_Pos7,Adress:M 256.6,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 256, liftOnePositionSeven, 6);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<bool>> ReadLiftOnePositionEight()//Name:Lift1_Pos8,Adress:M 256.7,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 256, VarType.Bit, 1, 7));
        }
        public async Task<IResult> WriteLiftOnePositionEight(bool liftOnePositionEight)//Name:Lift1_Pos8,Adress:M 256.7,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 256, liftOnePositionEight, 7);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<bool>> ReadLiftTwoPositionOne()//Name:Lift1_Pos1,Adress:M 266.0,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 266, VarType.Bit, 1, 0));
        }
        public async Task<IResult> WriteLiftTwoPositionOne(bool LiftTwoPositionOne)//Name:Lift1_Pos1,Adress:M 266.0,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 266, LiftTwoPositionOne, 0);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<bool>> ReadLiftTwoPositionTwo()//Name:Lift1_Pos2,Adress:M 266.1,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 266, VarType.Bit, 1, 1));
        }
        public async Task<IResult> WriteLiftTwoPositionTwo(bool LiftTwoPositionTwo)//Name:Lift1_Pos2,Adress:M 266.1,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 266, LiftTwoPositionTwo, 1);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<bool>> ReadLiftTwoPositionThree()//Name:Lift1_Pos3,Adress:M 266.2,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 266, VarType.Bit, 1, 2));
        }
        public async Task<IResult> WriteLiftTwoPositionThree(bool LiftTwoPositionThree)//Name:Lift1_Pos3,Adress:M 266.2,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 266, LiftTwoPositionThree, 2);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<bool>> ReadLiftTwoPositionFour()//Name:Lift1_Pos4,Adress:M 266.3,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 266, VarType.Bit, 1, 3));
        }
        public async Task<IResult> WriteLiftTwoPositionFour(bool LiftTwoPositionFour)//Name:Lift1_Pos4,Adress:M 266.3,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 266, LiftTwoPositionFour, 3);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<bool>> ReadLiftTwoPositionFive()//Name:Lift1_Pos5,Adress:M 266.4,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 266, VarType.Bit, 1, 4));
        }
        public async Task<IResult> WriteLiftTwoPositionFive(bool LiftTwoPositionFive)//Name:Lift1_Pos5,Adress:M 266.4,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 266, LiftTwoPositionFive, 4);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<bool>> ReadLiftTwoPositionSix()//Name:Lift1_Pos6,Adress:M 266.5,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 266, VarType.Bit, 1, 5));
        }
        public async Task<IResult> WriteLiftTwoPositionSix(bool LiftTwoPositionSix)//Name:Lift1_Pos6,Adress:M 266.5,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 266, LiftTwoPositionSix, 5);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<bool>> ReadLiftTwoPositionSeven()//Name:Lift1_Pos7,Adress:M 266.6,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 266, VarType.Bit, 1, 6));
        }
        public async Task<IResult> WriteLiftTwoPositionSeven(bool LiftTwoPositionSeven)//Name:Lift1_Pos7,Adress:M 266.6,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 266, LiftTwoPositionSeven, 6);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<bool>> ReadLiftTwoPositionEight()//Name:Lift1_Pos8,Adress:M 266.7,Data Type:Bool
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.Memory, 0, 266, VarType.Bit, 1, 7));
        }
        public async Task<IResult> WriteLiftTwoPositionEight(bool LiftTwoPositionEight)//Name:Lift1_Pos8,Adress:M 266.7,Data Type:Bool
        {
            _plcDal.Write(DataType.Memory, 0, 266, LiftTwoPositionEight, 7);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadLiftOneSetPositionOne()//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 68,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 230, 68, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftOneSetPositionOne(long liftoneSetPositionOne)//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 68,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 230, 68, liftoneSetPositionOne);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadLiftOneSetPositionTwo()//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 72,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 230, 72, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftOneSetPositionTwo(long liftoneSetPositionTwo)//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 72,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 230, 72, liftoneSetPositionTwo);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadLiftOneSetPositionThree()//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 76,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 230, 76, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftOneSetPositionThree(long liftoneSetPositionThree)//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 76,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 230, 76, liftoneSetPositionThree);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadLiftOneSetPositionFour()//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 80,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 230, 80, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftOneSetPositionFour(long liftoneSetPositionFour)//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 80,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 230, 80, liftoneSetPositionFour);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadLiftOneSetPositionFive()//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 84,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 230, 84, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftOneSetPositionFive(long liftoneSetPositionFive)//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 84,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 230, 84, liftoneSetPositionFive);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadLiftOneSetPositionSix()//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 88,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 230, 88, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftOneSetPositionSix(long liftoneSetPositionSix)//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 88,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 230, 88, liftoneSetPositionSix);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadLiftOneSetPositionSeven()//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 92,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 230, 92, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftOneSetPositionSeven(long liftoneSetPositionSeven)//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 92,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 230, 92, liftoneSetPositionSeven);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadLiftOneSetPositionEight()//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 96,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 230, 96, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftOneSetPositionEight(long liftoneSetPositionEight)//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 96,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 230, 96, liftoneSetPositionEight);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadLiftTwoSetPositionOne()//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 68,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 231, 68, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftTwoSetPositionOne(long LiftTwoSetPositionOne)//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 68,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 231, 68, LiftTwoSetPositionOne);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadLiftTwoSetPositionTwo()//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 72,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 231, 72, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftTwoSetPositionTwo(long LiftTwoSetPositionTwo)//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 72,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 231, 72, LiftTwoSetPositionTwo);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadLiftTwoSetPositionThree()//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 76,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 231, 76, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftTwoSetPositionThree(long LiftTwoSetPositionThree)//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 76,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 231, 76, LiftTwoSetPositionThree);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadLiftTwoSetPositionFour()//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 80,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 231, 80, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftTwoSetPositionFour(long LiftTwoSetPositionFour)//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 80,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 231, 80, LiftTwoSetPositionFour);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadLiftTwoSetPositionFive()//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 84,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 231, 84, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftTwoSetPositionFive(long LiftTwoSetPositionFive)//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 84,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 231, 84, LiftTwoSetPositionFive);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadLiftTwoSetPositionSix()//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 88,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 231, 88, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftTwoSetPositionSix(long LiftTwoSetPositionSix)//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 88,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 231, 88, LiftTwoSetPositionSix);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadLiftTwoSetPositionSeven()//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 92,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 231, 92, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftTwoSetPositionSeven(long LiftTwoSetPositionSeven)//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 92,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 231, 92, LiftTwoSetPositionSeven);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadLiftTwoSetPositionEight()//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 96,Data Type:Real
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 231, 96, VarType.Real, 1));
        }
        public async Task<IResult> WriteLiftTwoSetPositionEight(long LiftTwoSetPositionEight)//Name:Lift1_2Set_Pos1,Adress:DB 231 DBD 96,Data Type:Real
        {
            _plcDal.Write(DataType.DataBlock, 231, 96, LiftTwoSetPositionEight);
            return new SuccessResult();
        }



    }
}
