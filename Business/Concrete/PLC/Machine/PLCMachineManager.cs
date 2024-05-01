using Business.Abstract.PLC.Machine;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using PLC.Abstract;
using S7.Net;
using System.Text;

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
        public async Task<IDataResult<int>> ReadMachineSpeedSet()//Name:MachineSpeedSet,Addres:DB 91 DBW 2,Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 91, 2, VarType.Int, 1));
        }
        public async Task<IResult> WriteMachineSpeedSet(int machineSpeedSet)//Name:MachineSpeedSet,Addres:DB 91 DBW 2,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 2, machineSpeedSet);
            return new SuccessResult();
        }

        public async Task<IDataResult<int>> ReadTransportOneTensionSet()//Name:Transport1TensionSet,Addres:DB 91 DBW 550,Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 91, 550, VarType.Int, 1));
        }
        public async Task<IResult> WriteTransportOneTensionSet(int transportOneTensionSet)//Name:Transport1TensionSet,Addres:DB 91 DBW 550,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 550, transportOneTensionSet);
            return new SuccessResult();
        }

        public async Task<IDataResult<int>> ReadTransportTwoTensionSet()//Name:Transport2TensionSet,Addres:DB 91 DBW 560,Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 91, 560, VarType.Int, 1));
        }
        public async Task<IResult> WriteTransportTwoTensionSet(int transportOneTensionSet)//Name:Transport2TensionSet,Addres:DB 91 DBW 560,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 560, transportOneTensionSet);
            return new SuccessResult();
        }

        public async Task<IDataResult<long>> ReadWeightRewinderOne()//Name:Weight_Rew_1,Addres:DB 1 DBD 2384,Data Type:Int
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 1, 2384, VarType.Real, 1));
        }
        public async Task<IResult> WriteWeightRewinderOne(long weightRewinderOne)//Name:Weight_Rew_1,Addres:DB 1 DBD 2384,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 1, 2384, weightRewinderOne);
            return new SuccessResult();
        }

        public async Task<IDataResult<long>> ReadWeightRewinderTwo()//Name:Weight_Rew_2,Addres:DB 1 DBD 2380,Data Type:Int
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 1, 2380, VarType.Real, 1));
        }
        public async Task<IResult> WriteWeightRewinderTwo(long weightRewinderTwo)//Name:Weight_Rew_2,Addres:DB 1 DBD 2380,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 1, 2380, weightRewinderTwo);
            return new SuccessResult();
        }

        public async Task<IDataResult<int>> ReadRewinderOneDiameterSet()//Name:Rew1DiaSet,Addres:DB 91 DBW 300,Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 91, 300, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderOneDiameterSet(int rewinderOneDiameterSet)//Name:Rew1DiaSet,Addres:DB 91 DBW 300,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 300, rewinderOneDiameterSet);
            return new SuccessResult();
        }


        public async Task<IDataResult<long>> ReadRewinderOneLengthSet()//Name:Rew1LengthSet,Addres:DB 91 DBD 306,Data Type:DInt
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 91, 306, VarType.DInt, 1));
        }
        public async Task<IResult> WriteRewinderOneLengthSet(long rewinderOneLengthSet)//Name:Rew1LengthSet,Addres:DB 91 DBD 306,Data Type:DInt
        {
            _plcDal.Write(DataType.DataBlock, 91, 306, rewinderOneLengthSet);
            return new SuccessResult();
        }

        public async Task<IDataResult<long>> ReadRewinderOneLengthActuel()//Name:Rew1LengthAct,Addres:DB 90 DBD 306,Data Type:DInt
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 90, 306, VarType.DInt, 1));
        }
        public async Task<IResult> WriteRewinderOneLengthActuel(long rewinderOneLengthActuel)//Name:Rew1LengthAct,Addres:DB 90 DBD 306,Data Type:DInt
        {
            _plcDal.Write(DataType.DataBlock, 90, 306, rewinderOneLengthActuel);
            return new SuccessResult();
        }

        public async Task<IDataResult<int>> ReadRewinderTwoDiameterSet()//Name:Rew1DiaSet,Addres:DB 91 DBW 400,Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 91, 400, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderTwoDiameterSet(int rewinderTwoDiameterSet)//Name:Rew1DiaSet,Addres:DB 91 DBW 400,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 400, rewinderTwoDiameterSet);
            return new SuccessResult();
        }

        public async Task<IDataResult<int>> ReadRewinderTwoDiameterActuel()//Name:Rew1DiaAct,Addres:DB 90 DBW 400,Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 90, 400, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderTwoDiameterActuel(int rewinderTwoDiameterActuel)//Name:Rew1DiaAct,Addres:DB 90 DBW 400,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 400, rewinderTwoDiameterActuel);
            return new SuccessResult();
        }

        public async Task<IDataResult<long>> ReadRewinderTwoLengthSet()//Name:Rew1LengthSet,Addres:DB 91 DBD 406,Data Type:DInt
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 91, 406, VarType.DInt, 1));
        }
        public async Task<IResult> WriteRewinderTwoLengthSet(long rewinderTwoLengthSet)//Name:Rew1LengthSet,Addres:DB 91 DBD 406,Data Type:DInt
        {
            _plcDal.Write(DataType.DataBlock, 91, 406, rewinderTwoLengthSet);
            return new SuccessResult();
        }

        public async Task<IDataResult<long>> ReadRewinderTwoLengthActuel()//Name:Rew2LengthAct,Addres:DB 90 DBD 406,Data Type:DInt
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 90, 406, VarType.DInt, 1));
        }
        public async Task<IResult> WriteRewinderTwoLengthActuel(long rewinderTwoLengthActuel)//Name:Rew2LengthAct,Addres:DB 90 DBD 406,Data Type:DInt
        {
            _plcDal.Write(DataType.DataBlock, 90, 406, rewinderTwoLengthActuel);
            return new SuccessResult();
        }

        public async Task<IDataResult<int>> ReadUnwinderOneDiameterSet()//Name:Unw1DiaSet,Addres:DB 91 DBW 100,Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 91, 100, VarType.Int, 1));
        }
        public async Task<IResult> WriteUnwinderOneDiameterSet(int unwinderOneDiameterSet)//Name:Unw1DiaSet,Addres:DB 91 DBW 100,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 100, unwinderOneDiameterSet);
            return new SuccessResult();
        }

        public async Task<IDataResult<int>> ReadUnwinderOneDiameterActuel()//Name:Unw1DiaAct,Addres:DB 90 DBW 100,Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 90, 100, VarType.Int, 1));
        }
        public async Task<IResult> WriteUnwinderOneDiameterActuel(int unwinderOneDiameterActuel)//Name:Unw1DiaAct,Addres:DB 90 DBW 100,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 100, unwinderOneDiameterActuel);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderOneTensionLaySetScaled()//Name:Rew1TensionLaySetScaled,Addres:DB 91 DBW 372,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 91, 372, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderOneTensionLaySetScaled(decimal rewinderOneTensionLaySetScaled)//Name:Rew1TensionLaySetScaled,Addres:DB 91 DBW 372,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 372, rewinderOneTensionLaySetScaled);
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

        public async Task<IDataResult<decimal>> ReadContactOneTensionActuel()//Name:Cont1TensionAct,Addres:DB 90 DBW 580,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 580, VarType.Int, 1));
        }
        public async Task<IResult> WriteContactOneTensionActuel(decimal contactOneTensionActuel)//Name:Cont1TensionAct,Addres:DB 90 DBW 580,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 580, contactOneTensionActuel);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadContactTwoTensionActuel()//Name:Cont2TensionAct,Addres:DB 90 DBW 590,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 90, 590, VarType.Int, 1));
        }
        public async Task<IResult> WriteContactTwoTensionActuel(decimal contactTwoTensionActuel)//Name:Cont2TensionAct,Addres:DB 90 DBW 590,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 590, contactTwoTensionActuel);
            return new SuccessResult();
        }

        public async Task<IDataResult<decimal>> ReadRewinderTwoTensionSupportSetScaled()//Name:Rew2TensionSupSetScaled,Addres:DB 91 DBW 472,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 91, 472, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderTwoTensionSupportSetScaled(decimal rewinderTwoTensionSupportSetScaled)//Name:Rew2TensionSupSetScaled,Addres:DB 91 DBW 472,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 472, rewinderTwoTensionSupportSetScaled);
            return new SuccessResult();
        }

        public async Task<IDataResult<int>> ReadRecipeRecordNumber()//Name:RecipeRecordNumber,Addres:DB 96 DBW 42,Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 96, 42, VarType.Int, 1));
        }
        public async Task<IResult> WriteRecipeRecordNumber(int recipeRecordNumber)//Name:RecipeRecordNumber,Addres:DB 96 DBW 42,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 96, 42, recipeRecordNumber);
            return new SuccessResult();
        }

        public async Task<IDataResult<int>> ReadRecipeNumber()//Name:RecipeNumber,Addres:DB 96 DBW 40,Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 96, 40, VarType.Int, 1));
        }
        public async Task<IResult> WriteRecipeNumber(int recipeNumber)//Name:RecipeNumber,Addres:DB 96 DBW 40,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 96, 40, recipeNumber);
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
    }
}
