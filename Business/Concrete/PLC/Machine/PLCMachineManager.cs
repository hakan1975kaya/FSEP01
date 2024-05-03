using Business.Abstract.PLC.Machine;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using PLC.Abstract;
using S7.Net;

namespace Business.Concrete.PLC.Machine
{
    [LogAspect(typeof(DatabaseLogger), Priority = 1)]
    public class PLCMachineManager : IPLCMachineService
    {
        private IPLCDal _plcDal;
        public PLCMachineManager(IPLCDal plcDal)
        {
            _plcDal = plcDal;
        }
        public async Task<IDataResult<long>> ReadMachineSpeedSet()//Name:MachineSpeedSet,Addres:DB 91 DBW 2,Data Type:long
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 91, 2, VarType.Int, 1));
        }
        public async Task<IResult> WriteMachineSpeedSet(long machineSpeedSet)//Name:MachineSpeedSet,Addres:DB 91 DBW 2,Data Type:long
        {
            _plcDal.Write(DataType.DataBlock, 91, 2, machineSpeedSet);
            return new SuccessResult();
        }

        public async Task<IDataResult<long>> ReadTransportOneTensionSet()//Name:Transport1TensionSet,Addres:DB 91 DBW 550,Data Type:long
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 91, 550, VarType.Int, 1));
        }
        public async Task<IResult> WriteTransportOneTensionSet(long transportOneTensionSet)//Name:Transport1TensionSet,Addres:DB 91 DBW 550,Data Type:long
        {
            _plcDal.Write(DataType.DataBlock, 91, 550, transportOneTensionSet);
            return new SuccessResult();
        }

        public async Task<IDataResult<long>> ReadTransportTwoTensionSet()//Name:Transport2TensionSet,Addres:DB 91 DBW 560,Data Type:long
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 91, 560, VarType.Int, 1));
        }
        public async Task<IResult> WriteTransportTwoTensionSet(long transportOneTensionSet)//Name:Transport2TensionSet,Addres:DB 91 DBW 560,Data Type:long
        {
            _plcDal.Write(DataType.DataBlock, 91, 560, transportOneTensionSet);
            return new SuccessResult();
        }

        public async Task<IDataResult<long>> ReadWeightRewinderOne()//Name:Weight_Rew_1,Addres:DB 1 DBD 2384,Data Type:long
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 1, 2384, VarType.Real, 1));
        }
        public async Task<IResult> WriteWeightRewinderOne(long weightRewinderOne)//Name:Weight_Rew_1,Addres:DB 1 DBD 2384,Data Type:long
        {
            _plcDal.Write(DataType.DataBlock, 1, 2384, weightRewinderOne);
            return new SuccessResult();
        }

        public async Task<IDataResult<long>> ReadWeightRewinderTwo()//Name:Weight_Rew_2,Addres:DB 1 DBD 2380,Data Type:long
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 1, 2380, VarType.Real, 1));
        }
        public async Task<IResult> WriteWeightRewinderTwo(long weightRewinderTwo)//Name:Weight_Rew_2,Addres:DB 1 DBD 2380,Data Type:long
        {
            _plcDal.Write(DataType.DataBlock, 1, 2380, weightRewinderTwo);
            return new SuccessResult();
        }

        public async Task<IDataResult<long>> ReadRewinderOneDiameterSet()//Name:Rew1DiaSet,Addres:DB 91 DBW 300,Data Type:long
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 91, 300, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderOneDiameterSet(long rewinderOneDiameterSet)//Name:Rew1DiaSet,Addres:DB 91 DBW 300,Data Type:long
        {
            _plcDal.Write(DataType.DataBlock, 91, 300, rewinderOneDiameterSet);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadRewinderOneDiameterActuel()//Name:Rew1DiaAct,Adress:DB 90 DBW 300,Data Type:long
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 90, 300, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderOneDiameterActuel(long rewinderOneDiameterActuel)//Name:Rew1DiaAct,Adress:DB 90 DBW 300,Data Type:long
        {
            _plcDal.Write(DataType.DataBlock, 90, 300, rewinderOneDiameterActuel);
            return new SuccessResult();
        }

        public async Task<IDataResult<long>> ReadRewinderOneLengthSet()//Name:Rew1LengthSet,Addres:DB 91 DBD 306,Data Type:Dlong
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 91, 306, VarType.Dlong, 1));
        }
        public async Task<IResult> WriteRewinderOneLengthSet(long rewinderOneLengthSet)//Name:Rew1LengthSet,Addres:DB 91 DBD 306,Data Type:Dlong
        {
            _plcDal.Write(DataType.DataBlock, 91, 306, rewinderOneLengthSet);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadRewinderOneLengthActuel()//Name:Rew1LengthAct,Addres:DB 90 DBD 306,Data Type:Dlong
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 90, 306, VarType.Dlong, 1));
        }
        public async Task<IResult> WriteRewinderOneLengthActuel(long rewinderOneLengthActuel)//Name:Rew1LengthAct,Addres:DB 90 DBD 306,Data Type:Dlong
        {
            _plcDal.Write(DataType.DataBlock, 90, 306, rewinderOneLengthActuel);
            return new SuccessResult();
        }

        public async Task<IDataResult<long>> ReadRewinderTwoDiameterSet()//Name:Rew1DiaSet,Addres:DB 91 DBW 400,Data Type:long
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 91, 400, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderTwoDiameterSet(long rewinderTwoDiameterSet)//Name:Rew1DiaSet,Addres:DB 91 DBW 400,Data Type:long
        {
            _plcDal.Write(DataType.DataBlock, 91, 400, rewinderTwoDiameterSet);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadRewinderTwoDiameterActuel()//Name:Rew1DiaAct,Addres:DB 90 DBW 400,Data Type:long
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 90, 400, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderTwoDiameterActuel(long rewinderTwoDiameterActuel)//Name:Rew1DiaAct,Addres:DB 90 DBW 400,Data Type:long
        {
            _plcDal.Write(DataType.DataBlock, 90, 400, rewinderTwoDiameterActuel);
            return new SuccessResult();
        }

        public async Task<IDataResult<long>> ReadRewinderTwoLengthSet()//Name:Rew1LengthSet,Addres:DB 91 DBD 406,Data Type:Dlong
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 91, 406, VarType.Dlong, 1));
        }
        public async Task<IResult> WriteRewinderTwoLengthSet(long rewinderTwoLengthSet)//Name:Rew1LengthSet,Addres:DB 91 DBD 406,Data Type:Dlong
        {
            _plcDal.Write(DataType.DataBlock, 91, 406, rewinderTwoLengthSet);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadRewinderTwoLengthActuel()//Name:Rew2LengthAct,Addres:DB 90 DBD 406,Data Type:Dlong
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 90, 406, VarType.Dlong, 1));
        }
        public async Task<IResult> WriteRewinderTwoLengthActuel(long rewinderTwoLengthActuel)//Name:Rew2LengthAct,Addres:DB 90 DBD 406,Data Type:Dlong
        {
            _plcDal.Write(DataType.DataBlock, 90, 406, rewinderTwoLengthActuel);
            return new SuccessResult();
        }

        public async Task<IDataResult<long>> ReadUnwinderOneDiameterSet()//Name:Unw1DiaSet,Addres:DB 91 DBW 100,Data Type:long
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 91, 100, VarType.Int, 1));
        }
        public async Task<IResult> WriteUnwinderOneDiameterSet(long unwinderOneDiameterSet)//Name:Unw1DiaSet,Addres:DB 91 DBW 100,Data Type:long
        {
            _plcDal.Write(DataType.DataBlock, 91, 100, unwinderOneDiameterSet);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadUnwinderOneDiameterActuel()//Name:Unw1DiaAct,Addres:DB 90 DBW 100,Data Type:long
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 90, 100, VarType.Int, 1));
        }
        public async Task<IResult> WriteUnwinderOneDiameterActuel(long unwinderOneDiameterActuel)//Name:Unw1DiaAct,Addres:DB 90 DBW 100,Data Type:long
        {
            _plcDal.Write(DataType.DataBlock, 90, 100, unwinderOneDiameterActuel);
            return new SuccessResult();
        }

        public async Task<IDataResult<bool>> ReadRewinderOneResetLength()//Name:MachineFunctFlag1,Adress:DB 91 DBW 28,Data Type:Int,ResetLength:91.28.2
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.DataBlock, 91, 28, VarType.Bit, 1,2));
        }
        public async Task<IResult> WriteRewinderOneResetLength(bool rewinderOneResetLength)//Name:MachineFunctFlag1,Adress:DB 91 DBW 28,Data Type:Int,ResetLength:91.28.2
        {
            _plcDal.Write(DataType.DataBlock, 91, 28, rewinderOneResetLength,2);
            return new SuccessResult();
        }

        public async Task<IDataResult<bool>> ReadRewinderTwoResetLength()//Name:MachineFunctFlag1,Adress:DB 91 DBW 28,Data Type:Int,ResetLength:91.28.3
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.DataBlock, 91, 28, VarType.Bit, 1, 3));
        }
        public async Task<IResult> WriteRewinderTwoResetLength(bool rewinderTwoResetLength)//Name:MachineFunctFlag1,Adress:DB 91 DBW 28,Data Type:Int,ResetLength:91.28.3
        {
            _plcDal.Write(DataType.DataBlock, 91, 28, rewinderTwoResetLength,3);
            return new SuccessResult();
        }


    }
}
