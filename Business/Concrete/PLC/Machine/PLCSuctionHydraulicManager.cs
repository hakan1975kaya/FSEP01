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

        public async Task<IDataResult<bool>> ReadStartCycleCentralLubrication()//Name:MachineFunctFlag1,Adress:DB 91 DBW 28,Data Type:short,Note:91.28.6 StartCycleCentrallubrication
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.DataBlock, 91, 28, VarType.Bit, 1, 6));
        }
        public async Task<IResult> WriteStartCycleCentralLubrication(bool startCycleCentralLubrication)//Name:MachineFunctFlag1,Adress:DB 91 DBW 28,Data Type:short,Note:91.28.6 StartCycleCentrallubrication
        {
            _plcDal.Write(DataType.DataBlock, 91, 28, startCycleCentralLubrication, 6);
            return new SuccessResult();
        }

        public async Task<IDataResult<bool>> ReadStartCycleCentralLubricationIsRunning()//Name:MachineFunctFlag1,Adress:DB 91 DBW 28,Data Type:short,Note:91.28.15 StartLubrication
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.DataBlock, 91, 28, VarType.Bit, 1, 15));
        }
        public async Task<IResult> WriteStartCycleCentralLubricationIsRunning(bool startCycleCentralLubricationIsRunning)//Name:MachineFunctFlag1,Adress:DB 91 DBW 28,Data Type:short,Note:91.28.15 StartLubrication
        {
            _plcDal.Write(DataType.DataBlock, 91, 28, startCycleCentralLubricationIsRunning, 15);
            return new SuccessResult();
        }

        public async Task<IDataResult<short>> ReadHydraulicTemperature()//Name:HydraulicTemperature,Addres:DB 90 DBW 28,Data Type:short,Note:90.28.6 :Start Cycle Central lubrication Button,90.28.15 :Cycle Central lubrication Lamp
        {
            return new SuccessDataResult<short>((short)_plcDal.Read(DataType.DataBlock, 90, 28, VarType.Int, 1));
        }
        public async Task<IResult> WriteHydraulicTemperature(short hydraulicTemperature)//Name:HydraulicTemperature,Addres:DB 90 DBW 28,Data Type:short
        {
            _plcDal.Write(DataType.DataBlock, 90, 28, hydraulicTemperature);
            return new SuccessResult();
        }

        public async Task<IDataResult<short>> ReadHydraulicLevel()//Name:HydraulicLevel,Addres:DB 90 DBW 662,Data Type:short
        {
            return new SuccessDataResult<short>((short)_plcDal.Read(DataType.DataBlock, 90, 662, VarType.Int, 1));
        }
        public async Task<IResult> WriteHydraulicLevel(short hydraulicTemperature)//Name:HydraulicLevel,Addres:DB 90 DBW 662,Data Type:short
        {
            _plcDal.Write(DataType.DataBlock, 90, 662, hydraulicTemperature);
            return new SuccessResult();
        }

        public async Task<IDataResult<short>> ReadHydraulicPressure()//Name:HydraulicPressure,Addres:DB 90 DBW 664, Data Type:short
        {
            return new SuccessDataResult<short>((short)_plcDal.Read(DataType.DataBlock, 90, 664, VarType.Int, 1));
        }
        public async Task<IResult> WriteHydraulicPressure(short hydraulicPressure)//Name:HydraulicPressure,Addres:DB 90 DBW 664, Data Type:short
        {
            _plcDal.Write(DataType.DataBlock, 90, 664, hydraulicPressure);
            return new SuccessResult();
        }

        public async Task<IDataResult<short>> ReadSuctionRPMSet()//Name:SuctionRPMSet,Addres:DB 91 DBW 690, Data Type:short
        {
            return new SuccessDataResult<short>((short)_plcDal.Read(DataType.DataBlock, 91, 690, VarType.Int, 1));
        }
        public async Task<IResult> WriteSuctionRPMSet(short suctionRPMSet)//Name:SuctionRPMSet,Addres:DB 91 DBW 690, Data Type:short
        {
            _plcDal.Write(DataType.DataBlock, 91, 690, suctionRPMSet);
            return new SuccessResult();
        }

        public async Task<IDataResult<short>> ReadSuctionRPMActuel()//Name:SuctionRPMSet,Addres:DB 90 DBW 690, Data Type:short
        {
            return new SuccessDataResult<short>((short)_plcDal.Read(DataType.DataBlock, 90, 690, VarType.Int, 1));
        }
        public async Task<IResult> WriteSuctionRPMActuel(short suctionRPMActuel)//Name:SuctionRPMSet,Addres:DB 90 DBW 690, Data Type:short
        {
            _plcDal.Write(DataType.DataBlock, 90, 690, suctionRPMActuel);
            return new SuccessResult();
        }

        public async Task<IDataResult<short>> ReadSuctionSpeedForMaximumRPM()//Name:SuctionSpeedForMaxRPM,Addres:DB 91 DBW 694, Data Type:short
        {
            return new SuccessDataResult<short>((short)_plcDal.Read(DataType.DataBlock, 91, 694, VarType.Int, 1));
        }
        public async Task<IResult> WriteSuctionSpeedForMaximumRPM(short suctionSpeedForMaximumRPM)//Name:SuctionSpeedForMaxRPM,Addres:DB 91 DBW 694, Data Type:short
        {
            _plcDal.Write(DataType.DataBlock, 91, 694, suctionSpeedForMaximumRPM);
            return new SuccessResult();
        }

        public async Task<IDataResult<short>> ReadMachineSpeedActuel()//Name:SuctionSpeedForMaxRPM,Addres:DB 90 DBW 2, Data Type:short
        {
            return new SuccessDataResult<short>((short)_plcDal.Read(DataType.DataBlock, 90, 2, VarType.Int, 1));
        }
        public async Task<IResult> WriteMachineSpeedActuel(short machineSpeedActuel)//Name:SuctionSpeedForMaxRPM,Addres:DB 90 DBW 2, Data Type:short
        {
            _plcDal.Write(DataType.DataBlock, 90, 2, machineSpeedActuel);
            return new SuccessResult();
        }

        public async Task<IDataResult<bool>> ReadBoosterIsRaedy()//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:short,Note:91.702.0
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.DataBlock, 91, 702, VarType.Bit, 1, 0));
        }
        public async Task<IResult> WriteBoosterIsRaedy(bool boosterIsRaedy)//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:short,Note:91.702.0
        {
            _plcDal.Write(DataType.DataBlock, 91, 702, boosterIsRaedy, 0);
            return new SuccessResult();
        }

        public async Task<IDataResult<bool>> ReadBoosterIsRunning()//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:short,Note:91.702.1
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.DataBlock, 91, 702, VarType.Bit, 1, 1));
        }
        public async Task<IResult> WriteBoosterIsRunning(bool boosterIsRunning)//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:short,Note:91.702.1
        {
            _plcDal.Write(DataType.DataBlock, 91, 702, boosterIsRunning, 1);
            return new SuccessResult();
        }

        public async Task<IDataResult<bool>> ReadSuctionExternFunctionSetOne()//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:short,Note:91.702.2
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.DataBlock, 91, 702, VarType.Bit, 1, 2));
        }
        public async Task<IResult> WriteSuctionExternFunctionSetOne(bool suctionExternFunctionSetOne)//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:short,Note:91.702.2
        {
            _plcDal.Write(DataType.DataBlock, 91, 702, suctionExternFunctionSetOne, 2);
            return new SuccessResult();
        }

        public async Task<IDataResult<bool>> ReadSuctionExternFunctionSetTwo()//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:short,Note:91.702.3
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.DataBlock, 91, 702, VarType.Bit, 1, 3));
        }
        public async Task<IResult> WriteSuctionExternFunctionSetTwo(bool suctionExternFunctionSetTwo)//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:short,Note:91.702.3
        {
            _plcDal.Write(DataType.DataBlock, 91, 702, suctionExternFunctionSetTwo, 3);
            return new SuccessResult();
        }

        public async Task<IDataResult<bool>> ReadSuctionExternFunctionSetThree()//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:short,Note:91.702.4
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.DataBlock, 91, 702, VarType.Bit, 1, 4));
        }
        public async Task<IResult> WriteSuctionExternFunctionSetThree(bool suctionExternFunctionSetThree)//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:short,Note:91.702.4
        {
            _plcDal.Write(DataType.DataBlock, 91, 702, suctionExternFunctionSetThree, 4);
            return new SuccessResult();
        }

        public async Task<IDataResult<bool>> ReadSuctionExternFunctionReady()//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:short,Note:91.702.5
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.DataBlock, 91, 702, VarType.Bit, 1, 5));
        }
        public async Task<IResult> WriteSuctionExternFunctionReady(bool suctionExternFunctionReady)//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:short,Note:91.702.5
        {
            _plcDal.Write(DataType.DataBlock, 91, 702, suctionExternFunctionReady, 5);
            return new SuccessResult();
        }

        public async Task<IDataResult<bool>> ReadSuctionExternFunctionIsRunning()//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:short,Note:91.702.6
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.DataBlock, 91, 702, VarType.Bit, 1, 6));
        }
        public async Task<IResult> WriteSuctionExternFunctionIsRunning(bool suctionExternFunctionIsRunning)//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:short,Note:91.702.6
        {
            _plcDal.Write(DataType.DataBlock, 91, 702, suctionExternFunctionIsRunning, 6);
            return new SuccessResult();
        }

        public async Task<IDataResult<bool>> ReadSuctionExternFunctionIsFault()//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:short,Note:91.702.6
        {
            return new SuccessDataResult<bool>((bool)_plcDal.Read(DataType.DataBlock, 91, 702, VarType.Bit, 1, 7));
        }
        public async Task<IResult> WriteSuctionExternFunctionIsFault(bool suctionExternFunctionIsFault)//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:short,Note:91.702.6
        {
            _plcDal.Write(DataType.DataBlock, 91, 702, suctionExternFunctionIsFault, 7);
            return new SuccessResult();
        }

        public async Task<IDataResult<short>> ReadSuctionLeakAirFlapOneSet()//Name:suction externFunktionFlag,Addres:DB 91 DBW 698, Data Type:short
        {
            return new SuccessDataResult<short>((short)_plcDal.Read(DataType.DataBlock, 91, 698, VarType.Int, 1));
        }
        public async Task<IResult> WriteSuctionLeakAirFlapOneSet(short suctionLeakAirFlapOneSet)//Name:suction externFunktionFlag,Addres:DB 91 DBW 698, Data Type:short
        {
            _plcDal.Write(DataType.DataBlock, 91, 698, suctionLeakAirFlapOneSet);
            return new SuccessResult();
        }

        public async Task<IDataResult<short>> ReadSuctionLeakAirFlapOneActuel()//Name:SuctionLeakAirFlap1Act,Addres:DB 91 DBW 698, Data Type:short
        {
            return new SuccessDataResult<short>((short)_plcDal.Read(DataType.DataBlock, 91, 698, VarType.Int, 1));
        }
        public async Task<IResult> WriteSuctionLeakAirFlapOneActuel(short suctionLeakAirFlapOneActuel)//Name:SuctionLeakAirFlap1Act,Addres:DB 91 DBW 698, Data Type:short
        {
            _plcDal.Write(DataType.DataBlock, 91, 698, suctionLeakAirFlapOneActuel);
            return new SuccessResult();
        }

        public async Task<IDataResult<short>> ReadSuctionLeakAirFlapTwoSet()//Name:SuctionLeakAirFlap2Set,Addres:DB 91 DBW 700, Data Type:short
        {
            return new SuccessDataResult<short>((short)_plcDal.Read(DataType.DataBlock, 91, 700, VarType.Int, 1));
        }
        public async Task<IResult> WriteSuctionLeakAirFlapTwoSet(short suctionLeakAirFlapTwoSet)//Name:SuctionLeakAirFlap2Set,Addres:DB 91 DBW 700, Data Type:short
        {
            _plcDal.Write(DataType.DataBlock, 91, 700, suctionLeakAirFlapTwoSet);
            return new SuccessResult();
        }

        public async Task<IDataResult<short>> ReadSuctionLeakAirFlapTwoActuel()//Name:SuctionLeakAirFlap2Act,Addres:DB 90 DBW 700, Data Type:short
        {
            return new SuccessDataResult<short>((short)_plcDal.Read(DataType.DataBlock, 90, 700, VarType.Int, 1));
        }
        public async Task<IResult> WriteSuctionLeakAirFlapTwoActuel(short suctionLeakAirFlapTwoActuel)//Name:SuctionLeakAirFlap2Act,Addres:DB 90 DBW 700, Data Type:short
        {
            _plcDal.Write(DataType.DataBlock, 90, 700, suctionLeakAirFlapTwoActuel);
            return new SuccessResult();
        }

    }
}
