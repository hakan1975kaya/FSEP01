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
    public class PLCRewinderPressureManager : IPLCRewinderPressureService
    {
        private IPLCDal _plcDal;
        public PLCRewinderPressureManager(IPLCDal plcDal)
        {
            _plcDal = plcDal;
        }
        public async Task<IDataResult<decimal>> ReadRewinderOnePressureLaySetScaled()//Name:Rew1PresLaySetScaled,Addres:DB 91 DBW 352,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 91, 352, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderOnePressureLaySetScaled(decimal rewinderOnePressureLaySetScaled)//Name:Rew1PresLaySetScaled,Addres:DB 91 DBW 352,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 352, rewinderOnePressureLaySetScaled);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderOnePressureLayCalculateCharScaled()//Name:Rew1PresLayCalcCharScaled,Addres:DB 90 DBW 356,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 356, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderOnePressureLayCalculateCharScaled(decimal rewinderOnePressureLayCalculateCharScaled)//Name:Rew1PresLayCalcCharScaled,Addres:DB 90 DBW 356,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 356, rewinderOnePressureLayCalculateCharScaled);
            return new SuccessResult();
        }

        public async Task<IDataResult<int>> ReadRewinderOnePresureLayBalance()//Name:Rew1PresLayBalance,Addres:DB 91 DBW 366, Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 91, 366, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderOnePresureLayBalance(int rewinderOnePresureLayBalance)//Name:Rew1PresLayBalance,Addres:DB 91 DBW 366,DataType:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 366, rewinderOnePresureLayBalance);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderOnePressureLayCalculateRight()//Name:Rew1PresLayCalcRight,Addres:DB 90 DBW 364,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 364, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderOnePressureLayCalculateRight(decimal rewinderOnePressureLayCalculateRight)//Name:Rew1PresLayCalcRight,Addres:DB 90 DBW 364,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 364, rewinderOnePressureLayCalculateRight);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderOnePressureLayCalculateLeft()//Name:Rew1PresLayCalcLeft,Addres:DB 90 DBW 362,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 362, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderOnePressureLayCalculateLeft(decimal rewinderOnePressureLayCalculateLeft)//Name:Rew1PresLayCalcLeft,Addres:DB 90 DBW 362,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 362, rewinderOnePressureLayCalculateLeft);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderOnePressureContactSetScaled()//Name:Rew1PresContSetScaled,Addres:DB 91 DBW 322,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 91, 322, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderOnePressureContactSetScaled(decimal rewinderOnePressureContactSetScaled)//Name:Rew1PresContSetScaled,Addres:DB 91 DBW 322,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 322, rewinderOnePressureContactSetScaled);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderOnePressureContactCalculateCharScaled()//Name:Rew1PresContCalcCharScaled,Addres:DB 90 DBW 326,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 326, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderOnePressureContactCalculateCharScaled(decimal rewinderOnePressureContactCalculateCharScaled)//Name:Rew1PresContCalcCharScaled,Addres:DB 90 DBW 326,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 326, rewinderOnePressureContactCalculateCharScaled);
            return new SuccessResult();
        }

        public async Task<IDataResult<int>> ReadRewinderOnePressureContactBalance()//Name:Rew1PresContBalance,Addres:DB 91 DBW 336, Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 91, 336, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderOnePressureContactBalance(int rewinderOnePressureContactBalance)//Name:Rew1PresContBalance,Addres:DB 91 DBW 336,DataType:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 336, rewinderOnePressureContactBalance);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderOnePressureContactCalculateRight()//Name:Rew1PresContCalcRight,Addres:DB 90 DBW 334,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 334, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderOnePressureContactCalculateRight(decimal rewinderOnePressureContactCalculateRight)//Name:Rew1PresContCalcRight,Addres:DB 90 DBW 334,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 334, rewinderOnePressureContactCalculateRight);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderOnePressureContactCalculateLeft()//Name:Rew1PresContCalcLeft,Addres:DB 90 DBW 332,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 332, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderOnePressureContactCalculateLeft(decimal rewinderOnePressureContactCalculateLeft)//Name:Rew1PresContCalcLeft,Addres:DB 90 DBW 332,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 332, rewinderOnePressureContactCalculateLeft);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderTwoPressureContanctSetScaled()//Name:Rew2PresContSetScaled,Addres:DB 91 DBW 422,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 91, 422, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderTwoPressureContanctSetScaled(decimal rewinderTwoPressureContanctSetScaled)//Name:Rew2PresContSetScaled,Addres:DB 91 DBW 422,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 422, rewinderTwoPressureContanctSetScaled);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderTwoPressureContactCalculateCharScaled()//Name:Rew2PresContCalcCharScaled,Addres:DB 90 DBW 426,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 426, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderTwoPressureContactCalculateCharScaled(decimal rewinderTwoPressureContactCalculateCharScaled)//Name:Rew2PresContCalcCharScaled,Addres:DB 90 DBW 426,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 426, rewinderTwoPressureContactCalculateCharScaled);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderTwoPressureContanctBalance()//Name:Rew2PresContBalance,Addres:DB 91 DBW 436,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 91, 436, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderTwoPressureContanctBalance(decimal rewinderTwoPressureContanctBalance)//Name:Rew2PresContBalance,Addres:DB 91 DBW 436,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 436, rewinderTwoPressureContanctBalance);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderTwoPressureContactCalculateRight()//Name:Rew2PresContCalcRight,Addres:DB 90 DBW 434,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 434, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderTwoPressureContactCalculateRight(decimal rewinderTwoPressureContactCalculateRight)//Name:Rew2PresContCalcRight,Addres:DB 90 DBW 434,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 434, rewinderTwoPressureContactCalculateRight);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderTwoPressureContactCalculateLeft()//Name:Rew2PresContCalcLeft,Addres:DB 90 DBW 432,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 432, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderTwoPressureContactCalculateLeft(decimal rewinderTwoPressureContactCalculateLeft)//Name:Rew2PresContCalcLeft,Addres:DB 90 DBW 432,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 432, rewinderTwoPressureContactCalculateLeft);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderTwoPressureSupportSetScaled()//Name:Rew2PresSupSetScaled,Addres:DB 91 DBW 452,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 91, 452, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderTwoPressureSupportSetScaled(decimal rewinderTwoPressureSupportSetScaled)//Name:Rew2PresSupSetScaled,Addres:DB 91 DBW 452,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 452, rewinderTwoPressureSupportSetScaled);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderTwoPressureSupportCalculateCharScaled()//Name:Rew2PresSupCalcCharScaled,Addres:DB 90 DBW 456,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 456, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderTwoPressureSupportCalculateCharScaled(decimal rewinderTwoPressureSupportCalculateCharScaled)//Name:Rew2PresSupCalcCharScaled,Addres:DB 90 DBW 456,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 456, rewinderTwoPressureSupportCalculateCharScaled);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderTwoPressureSupportBalance()//Name:Rew2PresSupCalcCharScaled,Addres:DB 91 DBW 466,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 91, 466, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderTwoPressureSupportBalance(decimal rewinderTwoPressureSupportBalance)//Name:Rew2PresSupCalcCharScaled,Addres:DB 91 DBW 466,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 466, rewinderTwoPressureSupportBalance);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderTwoPressureSupportCalcuteRight()//Name:Rew2PresSupCalcRight,Addres:DB 90 DBW 464,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 464, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderTwoPressureSupportCalcuteRight(decimal rewinderTwoPressureSupportCalcuteRight)//Name:Rew2PresSupCalcRight,Addres:DB 90 DBW 464,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 464, rewinderTwoPressureSupportCalcuteRight);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderTwoPressureSupportCalcuteLeft()//Name:Rew2PresSupCalcLeft,Addres:DB 90 DBW 462,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 462, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderTwoPressureSupportCalcuteLeft(decimal rewinderTwoPressureSupportCalcuteLeft)//Name:Rew2PresSupCalcLeft,Addres:DB 90 DBW 462,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 462, rewinderTwoPressureSupportCalcuteLeft);
            return new SuccessResult();
        }

    }
}
