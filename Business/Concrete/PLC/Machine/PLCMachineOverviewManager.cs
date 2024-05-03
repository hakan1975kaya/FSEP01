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
    public class PLCMachineOverviewManager:IPLCMachineOverviewService
    {
        private IPLCDal _plcDal;
        public PLCMachineOverviewManager(IPLCDal plcDal)
        {
            _plcDal = plcDal;
        }

        //Read Only
        public async Task<IDataResult<long>> ReadUnwinderOneDiameterActuel()//Name:Unw1DiaAct,Adress:DB 90 DBW 100,Data Type:Int
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 90, 100, VarType.Int, 1));
        }
        public async Task<IResult> WriteUnwinderOneDiameterActuel(long unwinderOneDiameterActuel)//Name:Unw1DiaAct,Adress:DB 90 DBW 100,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 100, unwinderOneDiameterActuel);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadTransportOneTensionSet()//Name:Transport1TensionSet,Adress:DB 91 DBW 550,Data Type:Int
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 91, 550, VarType.Int, 1));
        }
        public async Task<IResult> WriteTransportOneTensionSet(long transportOneTensionSet)//Name:Transport1TensionSet,Adress:DB 91 DBW 550,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 550, transportOneTensionSet);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadTransportTwoTensionSet()//Name:Transport2TensionSet,Adress:DB 91 DBW 560,Data Type:Int
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 91, 560, VarType.Int, 1));
        }
        public async Task<IResult> WriteTransportTwoTensionSet(long transportTwoTensionSet)///Name:Transport2TensionSet,Adress:DB 91 DBW 560,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 560, transportTwoTensionSet);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<decimal>> ReadRewinderOneTensionLaySetScaled()//Name:Rew1TensionLaySetScaled,Addres:DB 91 DBW 372,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 91, 372, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderOneTensionLaySetScaled(decimal rewinderOneTensionLaySetScaled)//Name:Rew1TensionLaySetScaled,Addres:DB 91 DBW 372,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 372, rewinderOneTensionLaySetScaled);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<decimal>> ReadRewinderOneTensionCalculateCharScaled()//Name:Rew1TensionCalcCharScaled,Addres:DB 90 DBW 316,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 316, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderOneTensionCalculateCharScaled(decimal rewinderOneTensionCalculateCharScaled)//Name:Rew1TensionCalcCharScaled,Addres:DB 90 DBW 316,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 316, rewinderOneTensionCalculateCharScaled);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadRewinderOneLengthActuel()//Name:Rew1LengthAct,Adress:DB 90 DBD 306,Data Type:Int
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 90, 306, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderOneLengthActuel(long rewinderOneLengthActuel)//Name:Rew1LengthAct,Adress:DB 90 DBD 306,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 306, rewinderOneLengthActuel);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadRewinderOneDiameterActuel()//Name:Rew1DiaAct,Adress:DB 90 DBW 300,Data Type:Int
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 90, 300, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderOneDiameterActuel(long rewinderOneDiameterActuel)//Name:Rew1DiaAct,Adress:DB 90 DBW 300,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 300, rewinderOneDiameterActuel);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<decimal>> ReadContactOneTensionActuel()//Name:Cont1TensionAct,Addres:DB 90 DBW 580,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 580, VarType.Int, 1));
        }
        public async Task<IResult> WriteContactOneTensionActuel(decimal contactOneTensionActuel)//Name:Cont1TensionAct,Addres:DB 90 DBW 580,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 580, contactOneTensionActuel);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<decimal>> ReadContactTwoTensionActuel()//Name:Cont2TensionAct,Addres:DB 90 DBW 590,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 590, VarType.Int, 1));
        }
        public async Task<IResult> WriteContactTwoTensionActuel(decimal contactTwoTensionActuel)//Name:Cont2TensionAct,Addres:DB 90 DBW 590,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 590, contactTwoTensionActuel);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<decimal>> ReadRewinderTwoTensionCalculateCharScaled()//Name:Rew2TensionCalcCharScaled,Adress:DB 90 DBW 416,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 416, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderTwoTensionCalculateCharScaled(decimal rewinderTwoTensionCalculateCharScaled)//Name:Rew2TensionCalcCharScaled,Adress:DB 90 DBW 416,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 416, rewinderTwoTensionCalculateCharScaled);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadRewinderTwoLengthActuel()//Name:Rew2LengthAct,Adress:DB 90 DBD 406,Data Type:Int
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 90, 406, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderTwoLengthActuel(long rewinderTwoLengthActuel)//Name:Rew2LengthAct,Adress:DB 90 DBD 406,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 406, rewinderTwoLengthActuel);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadRewinderTwoDiameterActuel()//Name:Rew2DiaAct,Adress:DB 90 DBW 400,Data Type:Int
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 90, 400, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderTwoDiameterActuel(long rewinderTwoDiameterActuel)//Name:Rew2DiaAct,Adress:DB 90 DBW 400,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 400, rewinderTwoDiameterActuel);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<decimal>> ReadRewinderTwoTensionSupportSetScaled()//Name:Rew2TensionSupSetScaled,Addres:DB 91 DBW 472,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 91, 472, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderTwoTensionSupportSetScaled(decimal rewinderTwoTensionSupportSetScaled)//Name:Rew2TensionSupSetScaled,Addres:DB 91 DBW 472,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 472, rewinderTwoTensionSupportSetScaled);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<decimal>> ReadRewinderOnePressureLayCalculateCharScaled()//Name:Rew1PresLayCalcCharScaled,Adress:DB 90 DBW 356,Data Type:I
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 356, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderOnePressureLayCalculateCharScaled(decimal rewinderOnePressureLayCalculateCharScaled)//Name:Rew1PresLayCalcCharScaled,Adress:DB 90 DBW 356,Data Type:I
        {
            _plcDal.Write(DataType.DataBlock, 90, 356, rewinderOnePressureLayCalculateCharScaled);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<decimal>> ReadRewinderOnePressureContactCalculateCharScaled()//Name:Rew1PresContCalcCharScaled,Adress:DB 90 DBW 326,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 326, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderOnePressureContactCalculateCharScaled(decimal rewinderOnePressureContactCalculateCharScaled)//Name:Rew1PresContCalcCharScaled,Adress:DB 90 DBW 326,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 326, rewinderOnePressureContactCalculateCharScaled);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<decimal>> ReadRewinderTwoPressureContactCalculateCharScaled()//Name:Rew2PresContCalcCharScaled,Adress:DB 90 DBW 426,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 426, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderTwoPressureContactCalculateCharScaled(decimal rewinderTwoPressureContactCalculateCharScaled)//Name:Rew2PresContCalcCharScaled,Adress:DB 90 DBW 426,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 426, rewinderTwoPressureContactCalculateCharScaled);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<decimal>> ReadRewinderTwoPressureSupportCalculateCharScaled()//Name:Rew2PresSupCalcCharScaled,Adress:DB 90 DBW 456,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 456, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderTwoPressureSupportCalculateCharScaled(decimal rewinderTwoPressureSupportCalculateCharScaled)//Name:Rew2PresSupCalcCharScaled,Adress:DB 90 DBW 456,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 456, rewinderTwoPressureSupportCalculateCharScaled);
            return new SuccessResult();
        }


    }
}





