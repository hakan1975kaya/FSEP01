using Business.Abstract.PLC.Recipes;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using PLC.Abstract;
using S7.Net;
using System.Text;

namespace Business.Concrete.PLC.Machines
{
    [LogAspect(typeof(DatabaseLogger), Priority = 1)]
    public class PLCIRecipeBasicDataManager : IPLCRecipeBasicDataService
    {
        private IPLCDal _plcDal;
        public PLCIRecipeBasicDataManager(IPLCDal plcDal)
        {
            _plcDal = plcDal;
        }
    
        public async Task<IDataResult<int>> ReadAcceleration()//Name:MachineTimeAccel,Addres:DB 91 DBW 8
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 91, 8, VarType.Int, 1));
        }
        public async Task<IResult> WriteAcceleration(int acceleration)//Name:MachineTimeAccel,Addres:DB 91 DBW 8
        {
            _plcDal.Write(DataType.DataBlock, 91, 8, acceleration);
            return new SuccessResult();
        }
        public async Task<IDataResult<int>> ReadDecelaration()//Name:MachineTimeDecel,Addres:DB 91 DBW 10
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 91, 10, VarType.Int, 1));
        }
        public async Task<IResult> WriteDecelaration(int decelaration)//Name:MachineTimeDecel,Addres:DB 91 DBW 10
        {
            _plcDal.Write(DataType.DataBlock, 91, 10, decelaration);
            return new SuccessResult();
        }
        public async Task<IDataResult<int>> ReadFastStop()//Name:MachineTimeFastStop,Addres:DB 91 DBW 12
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 91, 12, VarType.Int, 1));
        }
        public async Task<IResult> WriteFastStop(int fastStop)//Name:MachineTimeFastStop,Addres:DB 91 DBW 12
        {
            _plcDal.Write(DataType.DataBlock, 91, 12, fastStop);
            return new SuccessResult();
        }
        public async Task<IDataResult<int>> ReadJogSpeed()//Name:MachineSpeedJog,Addres:DB 91 DBW 4
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 91, 4, VarType.Int, 1));
        }
        public async Task<IResult> WriteJogSpeed(int jogSpeed)//Name:MachineSpeedJog,Addres:DB 91 DBW 4
        {
            _plcDal.Write(DataType.DataBlock, 91, 4, jogSpeed);
            return new SuccessResult();
        }
  
    }
}
