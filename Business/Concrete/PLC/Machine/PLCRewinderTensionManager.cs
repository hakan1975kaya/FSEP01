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
    public class PLCRewinderTensionManager : IPLCRewinderTensionService
    {
        private IPLCDal _plcDal;
        public PLCRewinderTensionManager(IPLCDal plcDal)
        {
            _plcDal = plcDal;
        }
        public async Task<IDataResult<decimal>> ReadRewinderOneTensionSetScaled()//Name:Rew1TensionSetScaled,Addres:DB 91 DBW 312,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 91, 312, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderOneTensionSetScaled(decimal rewinderOneTensionSetScaled)//Name:Rew1TensionSetScaled,Addres:DB 91 DBW 312,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 312, rewinderOneTensionSetScaled);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderOneTensionCalculateCharScaled()//Name:Rew1TensionCalcCharScaled,Addres:DB 90 DBW 316,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 316, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderOneTensionCalculateCharScaled(decimal rewinderOneTensionCalculateCharScaled)//Name:Rew1TensionCalcCharScaled,Addres:DB 90 DBW 316,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 316, rewinderOneTensionCalculateCharScaled);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderOneTensionActuelMeasureScaled()//Name:Rew1TensionActMeasScaled,Addres:DB 90 DBW 312,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 312, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderOneTensionActuelMeasureScaled(decimal rewinderOneTensionActuelMeasureScaled)//Name:Rew1TensionActMeasScaled,Addres:DB 90 DBW 312,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 312, rewinderOneTensionActuelMeasureScaled);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderOneTensionCalculateCharNewton()//Name:Rew1TensionCalcCharNewton,Addres:DB 90 DBW 318,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 318, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderOneTensionCalculateCharNewton(decimal rewinderOneTensionCalculateCharNewton)//Name:Rew1TensionCalcCharNewton,Addres:DB 90 DBW 318,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 318, rewinderOneTensionCalculateCharNewton);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderOneTensionActuelMeasureNewton()//Name:Rew1TensionActMeasNewton,Addres:DB 90 DBW 314,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 314, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderOneTensionActuelMeasureNewton(decimal rewinderOneTensionActuelMeasureNewton)//Name:Rew1TensionActMeasNewton,Addres:DB 90 DBW 314,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 314, rewinderOneTensionActuelMeasureNewton);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderOneTensionContactSetScaled()//Name:Rew1TensionContSetScaled,Addres:DB 91 DBW 342,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 91, 342, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderOneTensionContactSetScaled(decimal rewinderOneTensionContactSetScaled)//Name:Rew1TensionContSetScaled,Addres:DB 91 DBW 342,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 342, rewinderOneTensionContactSetScaled);
            return new SuccessResult();
        }

        public async Task<IDataResult<int>> ReadRewinderOneMaterialWidth()//Name:Rew1MaterialWidth,Addres:DB 91 DBW 310,Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 91, 310, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderOneMaterialWidth(int rewinderOneMaterialWidth)//Name:Rew1MaterialWidth,Addres:DB 91 DBW 310,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 310, rewinderOneMaterialWidth);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderOneShaft()//Name:Rew1Shaft,Addres:DB 91 DBW 382,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 91, 382, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderOneShaft(decimal rewinderOneShaft)//Name:Rew1Shaft,Addres:DB 91 DBW 382,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 382, rewinderOneShaft);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderTwoTensionContactSetScaled()//Name:Rew2TensionContSetScaled,Addres:DB 91 DBW 442,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 91, 442, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderTwoTensionContactSetScaled(decimal rewinderTwoTensionContactSetScaled)//Name:Rew2TensionContSetScaled,Addres:DB 91 DBW 442,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 442, rewinderTwoTensionContactSetScaled);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderTwoTensionSetScaled()//Name:Rew2TensionSetScaled,Addres:DB 91 DBW 412,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 91, 412, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderTwoTensionSetScaled(decimal rewinderTwoTensionSetScaled)//Name:Rew2TensionSetScaled,Addres:DB 91 DBW 412,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 412, rewinderTwoTensionSetScaled);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderTwoTensionCalculeteCharScaled()//Name:Rew2TensionCalcCharScaled,Addres:DB 90 DBW 416,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 416, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderTwoTensionCalculeteCharScaled(decimal rewinderTwoTensionCalculeteCharScaled)//Name:Rew2TensionCalcCharScaled,Addres:DB 90 DBW 416,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 416, rewinderTwoTensionCalculeteCharScaled);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderTwoTensionActuelMeasureScaled()//Name:Rew2TensionActMeasScaled,Addres:DB 90 DBW 412,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 412, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderTwoTensionActuelMeasureScaled(decimal rewinderTwoTensionActuelMeasureScaled)//Name:Rew2TensionActMeasScaled,Addres:DB 90 DBW 412,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 412, rewinderTwoTensionActuelMeasureScaled);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderTwoTensionCalculateCharNewton()//Name:Rew2TensionCalcCharNewton,Addres:DB 90 DBW 418,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 418, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderTwoTensionCalculateCharNewton(decimal rewinderTwoTensionCalculateCharNewton)//Name:Rew2TensionCalcCharNewton,Addres:DB 90 DBW 418,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 418, rewinderTwoTensionCalculateCharNewton);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderTwoTensionActuelMeasureNewton()//Name:Rew2TensionActMeasNewton,Addres:DB 90 DBW 414,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 414, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderTwoTensionActuelMeasureNewton(decimal rewinderTwoTensionActuelMeasureNewton)//Name:Rew2TensionActMeasNewton,Addres:DB 90 DBW 414,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 414, rewinderTwoTensionActuelMeasureNewton);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderTwoMaterialWidth()//Name:Rew2MaterialWidth,Addres:DB 91 DBW 410,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 410, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderTwoMaterialWidth(decimal rewinderTwoMaterialWidth)//Name:Rew2MaterialWidth,Addres:DB 91 DBW 410,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 410, rewinderTwoMaterialWidth);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderTwoShaft()//Name:Rew2Shaft,Addres:DB 91 DBW 482,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 91, 482, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderTwoShaft(decimal rewinderTwoShaft)//Name:Rew2Shaft,Addres:DB 91 DBW 482,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 482, rewinderTwoShaft);
            return new SuccessResult();
        }


    }
}
