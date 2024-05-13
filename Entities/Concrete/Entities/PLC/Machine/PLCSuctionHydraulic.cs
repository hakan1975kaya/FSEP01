using Core.Entities.Abstract;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.PLC.Machine
{
    public class PLCSuctionHydraulic:IEntity
    {
        public Guid Id { get; set; }
        public Guid PLCGeneralId { get; set; }
        public bool StartCycleCentralLubrication { get; set; }//Name:MachineFunctFlag1,Adress:DB 91 DBW 28,Data Type:Int,Note:91.28.6 StartCycleCentrallubrication
        public bool StartCycleCentralLubricationIsRunning { get; set; }//Name:MachineFunctFlag1,Adress:DB 91 DBW 28,Data Type:Int,Note:91.28.15 StartLubrication
        public short HydraulicTemperature { get; set; }//Name:HydraulicTemperature,Adress:DB 90 DBW 660,Data Type:Int
        public short HydraulicLevel { get; set; }//Name:HydraulicLevel,Adress:DB 90 DBW 662,Data Type:Int
        public short HydraulicPressure { get; set; }//Name:HydraulicPressure,Adress:DB 90 DBW 664,Data Type:Int
        public short SuctionRPMSet { get; set; }//Name:SuctionRPMSet,Adress:DB 91 DBW 690,Data Type:Int
        public short SuctionRPMActuel { get; set; }//Name:SuctionRPMAct,Adress:DB 90 DBW 690,Data Type:Int
        public short SuctionSpeedForMaximumRPM { get; set; }//Name:SuctionSpeedForMaxRPM,Adress:DB 91 DBW 694,Data Type:Int
        public short MachineSpeedActuel { get; set; }//Name:MachineSpeedAct,Adress:DB 90 DBW 2,Data Type:Int
        public bool BoosterIsRaedy { get; set; }//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:Int,Note:91.702.0
        public bool BoosterIsRunning { get; set; }//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:Int,Note:91.702.1
        public bool SuctionExternFunctionSetOne { get; set; }//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:Int,Note:91.702.2
        public bool SuctionExternFunctionSetTwo { get; set; }//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:Int,Note:91.702.3
        public bool SuctionExternFunctionSetThree { get; set; }//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:Int,Note:91.702.4
        public bool SuctionExternFunctionReady { get; set; }//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:Int,Note:91.702.5
        public bool SuctionExternFunctionIsRunning { get; set; }//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:Int,Note:91.702.6
        public bool SuctionExternFunctionIsFault { get; set; }//Name:suction externFunktionFlag,Adress:DB 91 DBW 702,Data Type:Int,Note:91.702.7
        public short SuctionLeakAirFlapOneSet { get; set; }//Name:SuctionLeakAirFlap1Set,Adress:DB 91 DBW 698,Data Type:Int
        public short SuctionLeakAirFlapOneActuel { get; set; }//Name:SuctionLeakAirFlap1Act,Adress:DB 90 DBW 698,Data Type:Int
        public short SuctionLeakAirFlapTwoSet { get; set; }//Name:SuctionLeakAirFlap2Set,Adress:DB 91 DBW 700,Data Type:Int
        public short SuctionLeakAirFlapTwoActuel { get; set; }//Name:SuctionLeakAirFlap2Act,Adress:DB 90 DBW 700,Data Type:Int
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
