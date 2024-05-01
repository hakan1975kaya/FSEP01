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
    public class PLCSuctionHydraulicManager : IPLCSuctionHydraulicService
    {
        private IPLCDal _plcDal;
        public PLCSuctionHydraulicManager(IPLCDal plcDal)
        {
            _plcDal = plcDal;
        }

        public async Task<IDataResult<int>> ReadMachineConditionFlagOne()//Name:MachineCondFlag1,Addres:DB 90 DBW 28,Data Type:Int,Note:90.28.6 :Start Cycle Central lubrication Button,90.28.15 :Cycle Central lubrication Lamp
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 90, 28, VarType.Int, 1));
        }
        public async Task<IResult> WriteMachineConditionFlagOne(int machineConditionFlagOne)//Name:MachineCondFlag1,Addres:DB 90 DBW 28,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 28, machineConditionFlagOne);
            return new SuccessResult();
        }

        public async Task<IDataResult<int>> ReadHydraulicTemperature()//Name:HydraulicTemperature,Addres:DB 90 DBW 28,Data Type:Int,Note:90.28.6 :Start Cycle Central lubrication Button,90.28.15 :Cycle Central lubrication Lamp
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 90, 28, VarType.Int, 1));
        }
        public async Task<IResult> WriteHydraulicTemperature(int hydraulicTemperature)//Name:HydraulicTemperature,Addres:DB 90 DBW 28,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 28, hydraulicTemperature);
            return new SuccessResult();
        }

        public async Task<IDataResult<int>> ReadHydraulicLevel()//Name:HydraulicLevel,Addres:DB 90 DBW 662,Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 90, 662, VarType.Int, 1));
        }
        public async Task<IResult> WriteHydraulicLevel(int hydraulicTemperature)//Name:HydraulicLevel,Addres:DB 90 DBW 662,Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 662, hydraulicTemperature);
            return new SuccessResult();
        }

        public async Task<IDataResult<int>> ReadHydraulicPressure()//Name:HydraulicPressure,Addres:DB 90 DBW 664, Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 90, 664, VarType.Int, 1));
        }
        public async Task<IResult> WriteHydraulicPressure(int hydraulicPressure)//Name:HydraulicPressure,Addres:DB 90 DBW 664, Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 664, hydraulicPressure);
            return new SuccessResult();
        }

        public async Task<IDataResult<int>> ReadSuctionRPMSet()//Name:SuctionRPMSet,Addres:DB 91 DBW 690, Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 91, 690, VarType.Int, 1));
        }
        public async Task<IResult> WriteSuctionRPMSet(int suctionRPMSet)//Name:SuctionRPMSet,Addres:DB 91 DBW 690, Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 690, suctionRPMSet);
            return new SuccessResult();
        }

        public async Task<IDataResult<int>> ReadSuctionRPMActuel()//Name:SuctionRPMSet,Addres:DB 90 DBW 690, Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 90, 690, VarType.Int, 1));
        }
        public async Task<IResult> WriteSuctionRPMActuel(int suctionRPMActuel)//Name:SuctionRPMSet,Addres:DB 90 DBW 690, Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 690, suctionRPMActuel);
            return new SuccessResult();
        }

        public async Task<IDataResult<int>> ReadSuctionSpeedForMaximumRPM()//Name:SuctionSpeedForMaxRPM,Addres:DB 91 DBW 694, Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 91, 694, VarType.Int, 1));
        }
        public async Task<IResult> WriteSuctionSpeedForMaximumRPM(int suctionSpeedForMaximumRPM)//Name:SuctionSpeedForMaxRPM,Addres:DB 91 DBW 694, Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 694, suctionSpeedForMaximumRPM);
            return new SuccessResult();
        }

        public async Task<IDataResult<int>> ReadMachineSpeedActuel()//Name:SuctionSpeedForMaxRPM,Addres:DB 90 DBW 2, Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 90, 2, VarType.Int, 1));
        }
        public async Task<IResult> WriteMachineSpeedActuel(int machineSpeedActuel)//Name:SuctionSpeedForMaxRPM,Addres:DB 90 DBW 2, Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 2, machineSpeedActuel);
            return new SuccessResult();
        }

        public async Task<IDataResult<int>> ReadSuctionExternFunctionFlag()//Name:suction externFunktionFlag,Addres:DB 91 DBW 702, Data Type:Int, Note:1 Button:91.72.2,2 Button:91.72.3,3 Button:91.72.4
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 91, 702, VarType.Int, 1));
        }
        public async Task<IResult> WriteSuctionExternFunctionFlag(int machineSpeedActuel)//Name:suction externFunktionFlag,Addres:DB 91 DBW 702, Data Type:Int, Note:1 Button:91.72.2,2 Button:91.72.3,3 Button:91.72.4
        {
            _plcDal.Write(DataType.DataBlock, 91, 702, machineSpeedActuel);
            return new SuccessResult();
        }

        public async Task<IDataResult<int>> ReadSuctionLeakAirFlapOneSet()//Name:suction externFunktionFlag,Addres:DB 91 DBW 698, Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 91, 698, VarType.Int, 1));
        }
        public async Task<IResult> WriteSuctionLeakAirFlapOneSet(int suctionLeakAirFlapOneSet)//Name:suction externFunktionFlag,Addres:DB 91 DBW 698, Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 698, suctionLeakAirFlapOneSet);
            return new SuccessResult();
        }

        public async Task<IDataResult<int>> ReadSuctionLeakAirFlapOneActuel()//Name:SuctionLeakAirFlap1Act,Addres:DB 91 DBW 698, Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 91, 698, VarType.Int, 1));
        }
        public async Task<IResult> WriteSuctionLeakAirFlapOneActuel(int suctionLeakAirFlapOneActuel)//Name:SuctionLeakAirFlap1Act,Addres:DB 91 DBW 698, Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 698, suctionLeakAirFlapOneActuel);
            return new SuccessResult();
        }

        public async Task<IDataResult<int>> ReadSuctionLeakAirFlapTwoSet()//Name:SuctionLeakAirFlap2Set,Addres:DB 91 DBW 700, Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 91, 700, VarType.Int, 1));
        }
        public async Task<IResult> WriteSuctionLeakAirFlapTwoSet(int suctionLeakAirFlapTwoSet)//Name:SuctionLeakAirFlap2Set,Addres:DB 91 DBW 700, Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 91, 700, suctionLeakAirFlapTwoSet);
            return new SuccessResult();
        }

        public async Task<IDataResult<int>> ReadSuctionLeakAirFlapTwoActuel()//Name:SuctionLeakAirFlap2Act,Addres:DB 90 DBW 700, Data Type:Int
        {
            return new SuccessDataResult<int>((int)_plcDal.Read(DataType.DataBlock, 90, 700, VarType.Int, 1));
        }
        public async Task<IResult> WriteSuctionLeakAirFlapTwoActuel(int suctionLeakAirFlapTwoActuel)//Name:SuctionLeakAirFlap2Act,Addres:DB 90 DBW 700, Data Type:Int
        {
            _plcDal.Write(DataType.DataBlock, 90, 700, suctionLeakAirFlapTwoActuel);
            return new SuccessResult();
        }


    }
}

