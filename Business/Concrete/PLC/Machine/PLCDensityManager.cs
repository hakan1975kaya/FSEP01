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

        //Read Only
        public async Task<IDataResult<int>> ReadRewinderOneDensityGraph()//Name:Rew1DensityGraph,Adress:DB 43 DBW 48,Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 43, 48, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderOneDensityGraph(int rewinderOneDensityGraph)//Name:Rew1DensityGraph,Adress:DB 43 DBW 48,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 43, 48, rewinderOneDensityGraph);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<int>> ReadRewinderTwoDensityGraph()//Name:Rew2DensityGraph,Adress:DB 53 DBW 48,Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 53, 48, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderTwoDensityGraph(int rewinderTwoDensityGraph)//Name:Rew2DensityGraph,Adress:DB 53 DBW 48,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 53, 48, rewinderTwoDensityGraph);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<int>> ReadMachineSpeedActuelArchive()//Name:MachineSpeedActArchive,Adress:DB 304 DBW 20,Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 304, 20, VarType.Int, 1));
        }
        public async Task<IResult> WriteMachineSpeedActuelArchive(int machineSpeedActuelArchive)//Name:MachineSpeedActArchive,Adress:DB 304 DBW 20,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 304, 20, machineSpeedActuelArchive);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<decimal>> ReadMaterialThickness()//Name:MaterialThickness,Adress:DB 91 DBW 36,Data Type:Int
        {
            return new SuccessDataResult<decimal>((decimal)_plcDal.Read(DataType.DataBlock, 91, 36, VarType.Int, 1));
        }
        public async Task<IResult> WriteMaterialThickness(decimal materialThickness)//Name:MaterialThickness,Adress:DB 91 DBW 36,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 36, materialThickness);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadRewinderOneDiameterActuel()//Name:Rew1DiaAct,Addres:DB 90 DBW 300,Data Type:Int
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 90, 300, VarType.Int, 1));
        }
        public async Task<IResult> WriteRewinderOneDiameterActuel(long rewinderOneDiameterActuel)//Name:Rew1DiaAct,Addres:DB 90 DBW 300,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 300, rewinderOneDiameterActuel);
            return new SuccessResult();
        }

        //Read Only
        public async Task<IDataResult<long>> ReadRewinderOneLengthActuel()//Name:Rew1LengthAct,Adress:DB 90 DBD 306,Data Type:Int
        {
            return new SuccessDataResult<long>((long)_plcDal.Read(DataType.DataBlock, 90, 306, VarType.DInt, 1));
        }
        public async Task<IResult> WriteRewinderOneLengthActuel(long rewinderOneLengthActuel)//Name:Rew1LengthAct,Adress:DB 90 DBD 306,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 306, rewinderOneLengthActuel);
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
