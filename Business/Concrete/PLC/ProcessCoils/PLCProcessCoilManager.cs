using Business.Abstract.PLC.ProcessCoils;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using PLC.Abstract;
using PLC.Concrete;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.PLC.ProcessCoils
{
    public class PLCProcessCoilManager:IPLCProcessCoilService
    {
        private IPLCDal _plcDal;
        public PLCProcessCoilManager(IPLCDal plcDal)
        {
            _plcDal = plcDal;
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

    }
}
