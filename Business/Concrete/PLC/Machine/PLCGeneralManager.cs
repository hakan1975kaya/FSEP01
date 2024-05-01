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
    public class PLCGeneralManager : IPLCGeneralService
    {
        private IPLCDal _plcDal;
        public PLCGeneralManager(IPLCDal plcDal)
        {
            _plcDal = plcDal;
        }
        public async Task<IDataResult<string>> ReadRecipeNumber()//Name:RecipeNameLast,Adress:DB 90 DBB 40,Data Type:String
        {
            return new SuccessDataResult<string>((string)_plcDal.Read(DataType.DataBlock, 90, 40, VarType.String, 1));
        }
        public async Task<IResult> WriteRecipeNumber(string recipeNumber)//Name:RecipeNameLast,Adress:DB 90 DBB 40,Data Type:String
        {
            _plcDal.Write(DataType.DataBlock, 90, 40, recipeNumber);
            return new SuccessResult();
        }

        public async Task<IDataResult<int>> ReadMachineSpeedActuel()//Name:MachineSpeedAct,Adress:DB 90 DBW 2
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 90, 2, VarType.Word, 1));
        }
        public async Task<IResult> WriteMachineSpeedActuel(int machineSpeedActuel)//Name:MachineSpeedAct,Adress:DB 90 DBW 2
        {
            _plcDal.Write(DataType.DataBlock, 90, 2, machineSpeedActuel);
            return new SuccessResult();
        }

        public async Task<IDataResult<int>> ReadMachineSpeedMaximum()//Name:MachineSpeedMax,Addres:DB 90 DBW 0,Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 90, 0, VarType.Int, 1));
        }
        public async Task<IResult> WriteMachineSpeedMaximum(int machineSpeedMaximum)//Name:MachineSpeedMax,Addres:DB 90 DBW 0,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 0, machineSpeedMaximum);
            return new SuccessResult();
        }
    }
}
