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
    public class PLCDensityManager : IPLCDensityService
    {
        private IPLCDal _plcDal;
        public PLCDensityManager(IPLCDal plcDal)
        {
            _plcDal = plcDal;
        }

        public async Task<IDataResult<int>> ReadRewinderOneDensityGraph()//Name:Rew1DensityGraph,Adress:DB 43 DBW 48,Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 43, 48, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderOneDensityGraph(int rewinderOneDensityGraph)//Name:Rew1DensityGraph,Adress:DB 43 DBW 48,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 43, 48, rewinderOneDensityGraph);
            return new SuccessResult();
        }

        public async Task<IDataResult<int>> ReadRewinderTwoDensityGraph()//Name:Rew2DensityGraph,Adress:DB 53 DBW 48,Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 53, 48, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderTwoDensityGraph(int rewinderTwoDensityGraph)//Name:Rew2DensityGraph,Adress:DB 53 DBW 48,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 53, 48, rewinderTwoDensityGraph);
            return new SuccessResult();
        }

        public async Task<IDataResult<int>> ReadMachineSpeedActArchive()//Name:MachineSpeedActArchive,Adress:DB 304 DBW 20,Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 304, 20, VarType.Int, 1));
        }
        public async Task<IResult> WriteMachineSpeedActArchive(int rewinderOneDensityGraph)//Name:MachineSpeedActArchive,Adress:DB 304 DBW 20,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 304, 20, rewinderOneDensityGraph);
            return new SuccessResult();
        }

        public async Task<IDataResult<int>> ReadRewinderOneDiameterActuel()//Name:Rew1DiaAct,Addres:DB 90 DBW 300,Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 90, 300, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderOneDiameterActuel(int rewinderOneDiameterActuel)//Name:Rew1DiaAct,Addres:DB 90 DBW 300,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 300, rewinderOneDiameterActuel);
            return new SuccessResult();
        }

        public async Task<IDataResult<int>> ReadRewinderOneLengthActuel()//Name:Rew1LengthAct,Adress:DB 90 DBD 306,Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 90, 306, VarType.DInt, 1));
        }
        public async Task<IResult> WriteRewinderOneLengthActuel(int rewinderOneLengthActuel)//Name:Rew1LengthAct,Adress:DB 90 DBD 306,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 306, rewinderOneLengthActuel);
            return new SuccessResult();
        }

        public async Task<IDataResult<int>> ReadRewinderTwoDiameterActuel()//Name:Rew2DiaAct,Adress:DB 90 DBW 400,Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 90, 400, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderTwoDiameterActuel(int rewinderTwoDiameterActuel)//Name:Rew2DiaAct,Adress:DB 90 DBW 400,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 400, rewinderTwoDiameterActuel);
            return new SuccessResult();
        }

        public async Task<IDataResult<long>> ReadRewinderTwoLengthActuel()//Name:Rew2LengthAct,Adress:DB 90 DBD 406,Data Type:DInt
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 90, 406, VarType.DInt, 1));
        }
        public async Task<IResult> WriteRewinderTwoLengthActuel(long rewinderTwoLengthActuel)//Name:Rew2LengthAct,Adress:DB 90 DBD 406,Data Type:DInt
        {
            _plcDal.Write(DataType.DataBlock, 90, 406, rewinderTwoLengthActuel);
            return new SuccessResult();
        }


    }
}
