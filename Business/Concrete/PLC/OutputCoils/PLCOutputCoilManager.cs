using Business.Abstract.PLC.OutputCoils;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using PLC.Abstract;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.PLC.OutputCoils
{
    public class PLCOutputCoilManager:IPLCOutputCoilService
    {
        private IPLCDal _plcDal;
        public PLCOutputCoilManager(IPLCDal plcDal)
        {
            _plcDal = plcDal;
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
