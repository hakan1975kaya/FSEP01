using Business.Abstract.PLC.Machine;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Entities.Concrete.Enums.PLC.Machine;
using PLC.Abstract;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.PLC.Machine
{
    public class PLCGeneralManager : IPLCGeneralService
    {
        private IPLCDal _plcDal;
        public PLCGeneralManager(IPLCDal plcDal)
        {
            _plcDal = plcDal;
        }


        public async Task<IDataResult<string>> ReadRecipeNameLast()//Name:RecipeNameLast,Adress:DB 90 DBB 40,Data Type:String
        {
            return new SuccessDataResult<string>((string)_plcDal.Read(DataType.DataBlock, 90, 40, VarType.String, 1));
        }
        public async Task<IResult> WriteRecipeNameLast(string readRecipeNameLast)//Name:RecipeNameLast,Adress:DB 90 DBB 40,Data Type:String
        {
            _plcDal.Write(DataType.DataBlock, 90, 40, readRecipeNameLast);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<ServiceEnum>> ReadMachineMode()//Name:MachineMode,Adress:DB 90 DBW 24,Data Type:Int
        {
            return new SuccessDataResult<ServiceEnum>((ServiceEnum)_plcDal.Read(DataType.DataBlock, 90, 24, VarType.Int, 1));
        }
        public async Task<IResult> WriteMachineMode(ServiceEnum machineMode)//Name:MachineMode,Adress:DB 90 DBW 24,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 24, machineMode);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<MachineEnum>> ReadMachineState()//Name:MachineState,Adress:DB 90 DBW 26,Data Type:Int
        {
            return new SuccessDataResult<MachineEnum>((MachineEnum)_plcDal.Read(DataType.DataBlock, 90, 26, VarType.Int, 1));
        }
        public async Task<IResult> WriteMachineState(MachineEnum machineState)//Name:MachineState,Adress:DB 90 DBW 26,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 26, machineState);
            return new SuccessResult();
        }

        public async Task<IDataResult<short>> ReadMachineSpeedSet()//Name:MachineSpeedSet,Adress:DB 91 DBW 2 ,Data Type:Int
        {
            return new SuccessDataResult<short>((short)_plcDal.Read(DataType.DataBlock, 91, 2, VarType.Int, 1));
        }
        public async Task<IResult> WriteMachineSpeedSet(short machineSpeedSet)//Name:MachineSpeedSet,Adress:DB 91 DBW 2,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 2, machineSpeedSet);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<short>> ReadMachineSpeedActuel()//Name:MachineSpeedAct,Adress:DB 90 DBW 2
        {
            return new SuccessDataResult<short>((short)_plcDal.Read(DataType.DataBlock, 90, 2, VarType.Int, 1));
        }
        public async Task<IResult> WriteMachineSpeedActuel(short machineSpeedActuel)//Name:MachineSpeedAct,Adress:DB 90 DBW 2
        {
            _plcDal.Write(DataType.DataBlock, 90, 2, machineSpeedActuel);
            return new SuccessResult();
        }

        public async Task<IDataResult<short>> ReadMachineSpeedMaximum()//Name:MachineSpeedMax,Addres:DB 90 DBW 0,Data Type:Int
        {
            return new SuccessDataResult<short>((short)_plcDal.Read(DataType.DataBlock, 90, 0, VarType.Int, 1));
        }
        public async Task<IResult> WriteMachineSpeedMaximum(short machineSpeedMaximum)//Name:MachineSpeedMax,Addres:DB 90 DBW 0,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 0, machineSpeedMaximum);
            return new SuccessResult();
        }

       
    }
}

