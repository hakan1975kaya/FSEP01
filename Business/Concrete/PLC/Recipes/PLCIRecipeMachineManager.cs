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
    public class PLCMRecipeMachineManager : IPLCRecipeMachineService
    {
        private IPLCDal _plcDal;
        public PLCMRecipeMachineManager(IPLCDal plcDal)
        {
            _plcDal = plcDal;
        }
        public async Task<IDataResult<int>> ReadMachineSpeedSet()//Name:MachineSpeedSet,Addres:DB 91 DBW 2
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 91, 2, VarType.Int, 1));
        }
        public async Task<IResult> WriteMachineSpeedSet(int machineSpeedSet)//Name:MachineSpeedSet,Addres:DB 91 DBW 2
        {
            _plcDal.Write(DataType.DataBlock, 91, 2, machineSpeedSet);
            return new SuccessResult();
        }

    }
}
